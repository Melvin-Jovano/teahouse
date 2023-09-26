namespace teahouse.Models {
    public class Ingredient {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public ICollection<Recipe> Recipes { get; } = new List<Recipe>();
    }
}
