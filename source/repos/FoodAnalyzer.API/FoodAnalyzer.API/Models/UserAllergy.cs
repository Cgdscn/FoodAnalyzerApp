namespace FoodAnalyzer.API.Models
{
    public class UserAllergy
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
