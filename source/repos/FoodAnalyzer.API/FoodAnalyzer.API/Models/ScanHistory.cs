namespace FoodAnalyzer.API.Models
{
    public class ScanHistory
    {
        public int Id { get; set; }
        public DateTime ScanDate { get; set; }
        public int CalculatedHealthScore { get; set; } // 0-100 arası sistemin verdiği puan

        // İlişkiler (1 Kullanıcı -> N Tarama, 1 Ürün -> N Tarama)
        public int UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
