using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teahouse.Models;

namespace teahouse.Dtos.Tea {
    public class UpdateTeaDto {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Img { get; set; }
        public string? Description { get; set; }
        public DrinkType? DrinkType { get; set; }
        public int Price { get; set; }
        public ICollection<Models.Recipe> Recipes {get; set;} = new List<Models.Recipe>();
        public List<Bartender> Bartenders { get; } = new();
    }
}