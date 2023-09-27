using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teahouse.Models;

namespace teahouse.Dtos.Recipe {
    public class GetRecipeDto {
        public int Id { get; set; }
        public int TeaId { get; set; }
        public Models.Tea Tea { get; set; } = null!;
        public int IngredientId { get; set; }
        public Models.Ingredient Ingredient { get; set; } = null!;
        public int Quantity { get; set; }
    }
}