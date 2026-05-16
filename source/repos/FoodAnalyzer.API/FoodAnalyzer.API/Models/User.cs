namespace FoodAnalyzer.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<ScanHistory> Scans { get; set; }
        public ICollection<UserAllergy> UserAllergies { get; set; }
    }
}
