namespace teahouse.Models {
    public class Bartender {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Experience { get; set; } = 0;
        public List<Tea> Teas { get; } = new();
    }
}
