using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teahouse.Models;

namespace teahouse.Dtos.Ingredient {
    public class BuyIngredientDto {
        public int Id { get; set; }
        public int Stock { get; set; }
    }
}