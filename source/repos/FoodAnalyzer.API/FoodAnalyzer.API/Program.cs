using FoodAnalyzer.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer; // Bunu ekledik
using Microsoft.IdentityModel.Tokens; // Bunu ekledik
using System.Text; // Bunu ekledik

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. JWT Kimlik Doðrulama Servislerini Kaydetme
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Sonsuz döngüleri (Object Cycle) görmezden gelmesini saðlar
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS ayarý: Mobil uygulamanýn API'ye eriþebilmesi için
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});



var app = builder.Build();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 3. Sýralama ÇOK Önemli: Önce Kimlik Doðrula (Authentication), Sonra Yetkilendir (Authorization)
app.UseAuthentication(); // Bunu ekledik
app.UseAuthorization();

app.MapControllers();
// --- UYGULAMA BAÞLARKEN VERÝTABANINI OTOMATÝK GÜNCELLE VE TOHUMLARI EK (SEED) ---
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FoodAnalyzer.API.Data.AppDbContext>();
    // Bekleyen tüm migration'larý (10 maddelik tohumlar dahil) veritabanýna uygular.
    //dbContext.Database.EnsureDeleted();
    dbContext.Database.Migrate();
}

app.Run();
