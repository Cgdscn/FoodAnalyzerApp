namespace FoodAnalyzer.API.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RiskLevel { get; set; }
        public string Description { get; set; }

        public ICollection<ProductIngredient> ProductIngredients { get; set; }
        public ICollection<UserAllergy> UserAllergies { get; set; }
    }
}
