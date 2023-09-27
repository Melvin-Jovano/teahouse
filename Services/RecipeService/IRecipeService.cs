using teahouse.Dtos.Recipe;
using teahouse.Models;

namespace teahouse.Services.RecipeService {
    public interface IRecipeService {
        Task<List<GetRecipeDto>> GetAllRecipes();
        Task<ServiceResponse<GetRecipeDto>> GetRecipe(int id);
        Task<ServiceResponse<GetRecipeDto>> AddRecipe(AddRecipeDto recipe);
        Task<ServiceResponse<GetRecipeDto>> DeleteRecipe(int recipeId);
        Task<ServiceResponse<GetRecipeDto>> UpdateRecipe(UpdateRecipeDto recipe);
    }
}