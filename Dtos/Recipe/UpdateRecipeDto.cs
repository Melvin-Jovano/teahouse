using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teahouse.Models;

namespace teahouse.Dtos.Recipe {
    public class UpdateRecipeDto {
        public int Id { get; set; }
        public int TeaId { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; }
    }
}