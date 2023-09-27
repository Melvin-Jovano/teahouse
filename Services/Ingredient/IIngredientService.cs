using teahouse.Dtos.Ingredient;
using teahouse.Dtos.Tea;
using teahouse.Models;

namespace teahouse.Services.IngredientService {
    public interface IIngredientService {
        Task<List<GetIngredientDto>> GetAllIngredients();
        Task<ServiceResponse<GetIngredientDto>> BuyIngredient(BuyIngredientDto ingredientDto);
    }
}