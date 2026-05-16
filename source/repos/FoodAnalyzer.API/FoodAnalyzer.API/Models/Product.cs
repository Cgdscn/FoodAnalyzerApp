namespace FoodAnalyzer.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<ProductIngredient> ProductIngredients { get; set; }
        public ICollection<ScanHistory> Scans { get; set; }
    }
}
