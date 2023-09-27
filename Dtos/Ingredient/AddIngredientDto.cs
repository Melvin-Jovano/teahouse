using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teahouse.Models;

namespace teahouse.Dtos.Ingredient {
    public class AddIngredientDto {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public ICollection<Models.Recipe> Recipes { get; } = new List<Models.Recipe>();
    }
}