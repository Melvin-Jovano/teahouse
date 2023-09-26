namespace teahouse.Models {
    public class Tea {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Img { get; set; }
        public string? Description { get; set; }
        public DrinkType? DrinkType { get; set; }
        public int Price { get; set; }
        public ICollection<Recipe> Recipes { get; } = new List<Recipe>();
        public List<Bartender> Bartenders { get; } = new();
    }
}
