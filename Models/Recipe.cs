namespace teahouse.Models {
    public class Recipe {
        public int Id { get; set; }
        public int TeaId { get; set; }
        public Tea Tea { get; set; } = null!;
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
