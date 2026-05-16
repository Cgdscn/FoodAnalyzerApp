using FoodAnalyzer.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodAnalyzer.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ScanHistory> Scans { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ara tabloların birincil anahtarlarını (Primary Key) belirliyoruz
            modelBuilder.Entity<ProductIngredient>().HasKey(pi => new { pi.ProductId, pi.IngredientId });
            modelBuilder.Entity<UserAllergy>().HasKey(ua => new { ua.UserId, ua.IngredientId });

            // --- DATA SEEDING (Veri Tohumlama) KISMI BAŞLANGICI ---
            // Not: Property isimlerini (Name, Risk, Desc) kendi Ingredient modelindeki isimlere göre düzenleyebilirsin.
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Glikoz Şurubu", RiskLevel = "Orta", Description = "Kan şekerini hızla yükseltir, obezite ve diyabet riskini artırır." },
                new Ingredient { Id = 2, Name = "Monosodyum Glutamat", RiskLevel = "Kritik", Description = "Lezzet artırıcıdır (MSG). Çarpıntı, baş ağrısı ve nörolojik hassasiyet yapabilir." },
                new Ingredient { Id = 3, Name = "Sodyum Nitrit", RiskLevel = "Kritik", Description = "Koruyucu maddedir (E250). Özellikle işlenmiş etlerde bulunur, kanserojen potansiyeli vardır." },
                new Ingredient { Id = 4, Name = "Aspartam", RiskLevel = "Kritik", Description = "Yapay tatlandırıcıdır. Uzun vadede sinir sistemi üzerinde olumsuz etkileri tartışılmaktadır." },
                new Ingredient { Id = 5, Name = "Titanyum Dioksit", RiskLevel = "Kritik", Description = "Beyaz renklendiricidir (E171). Avrupa'da gıda takviyelerinde ve ürünlerinde kullanımı yasaklanmıştır." },
                new Ingredient { Id = 6, Name = "Tartrazin", RiskLevel = "Kritik", Description = "Sarı renklendiricidir (E102). Çocuklarda hiperaktiviteye ve alerjik reaksiyonlara neden olabilir." },
                new Ingredient { Id = 7, Name = "Karragenan", RiskLevel = "Orta", Description = "Kıvam artırıcıdır (E407). Sindirim sistemi rahatsızlıklarına ve bağırsak enflamasyonuna yol açabilir." },
                new Ingredient { Id = 8, Name = "Palm Yağı", RiskLevel = "Orta", Description = "Yüksek oranda doymuş yağ içerir. Kalp ve damar sağlığını olumsuz etkileyebilir." },
                new Ingredient { Id = 9, Name = "Yüksek Fruktozlu Mısır Şurubu", RiskLevel= "Kritik", Description = "Karaciğer yağlanmasına ve insülin direncine yol açan oldukça tehlikeli bir tatlandırıcıdır." },
                new Ingredient { Id = 10, Name = "Sodyum Benzoat", RiskLevel = "Orta", Description = "Koruyucudur (E211). C vitamini ile birleştiğinde kanserojen olan benzene dönüşebilir." }
            );
            // --- DATA SEEDING KISMI BİTİŞİ ---
        }
    }
}