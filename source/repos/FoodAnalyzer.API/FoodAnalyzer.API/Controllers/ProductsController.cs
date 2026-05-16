using FoodAnalyzer.API.Data;
using FoodAnalyzer.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodAnalyzer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("barcode/{barcode}")]
        public async Task<IActionResult> GetProductByBarcode(string barcode)
        {
            var product = await _context.Products
                .Include(p => p.ProductIngredients)
                    .ThenInclude(pi => pi.Ingredient)
                .FirstOrDefaultAsync(p => p.Barcode == barcode);

            if (product == null)
            {
                return NotFound(new { Mesaj = "Bu barkoda ait ürün veritabanında bulunamadı!" });
            }

            return Ok(product);
        }

        // --- YENİ EKLENEN API UCU (YAPAY ZEKA İÇİN RİSK SÖZLÜĞÜ) ---
        [HttpGet("ingredients")]
        public async Task<IActionResult> GetAllIngredients()
        {
            // Veritabanındaki tüm içerik/madde listesini getirir
            var ingredients = await _context.Ingredients.ToListAsync();
            return Ok(ingredients);
        }

        [HttpPost("seed")]
        public async Task<IActionResult> SeedDatabase()
        {
            if (await _context.Products.AnyAsync())
            {
                return BadRequest("Veritabanında zaten veri var!");
            }

            var seker = new Ingredient { Name = "Şeker", RiskLevel = "Orta", Description = "Yüksek kalori, kan şekerini hızlı yükseltir." };
            var palmYagi = new Ingredient { Name = "Palm Yağı", RiskLevel = "Yüksek", Description = "Doymuş yağ oranı yüksektir, damar tıkanıklığı riski." };
            var e102 = new Ingredient { Name = "E102 (Tartrazin)", RiskLevel = "Kritik", Description = "Renklendiricidir, çocuklarda hiperaktivite yapabilir." };

            var urun = new Product
            {
                Barcode = "8691234567890",
                Name = "Sütlü Çikolatalı Gofret",
                Brand = "Örnek Marka",
                // --- YENİ EKLENEN RESİM LİNKİ ---
                ImageUrl = "https://images.unsplash.com/photo-1621939514649-280e2ee25f60?q=80&w=500"
            };

            urun.ProductIngredients = new List<ProductIngredient>
            {
                new ProductIngredient { Ingredient = seker },
                new ProductIngredient { Ingredient = palmYagi },
                new ProductIngredient { Ingredient = e102 }
            };

            _context.Products.Add(urun);
            await _context.SaveChangesAsync();

            return Ok("Örnek çikolata, içerikleri ve FOTOĞRAFI başarıyla eklendi!");
        }
    }
}