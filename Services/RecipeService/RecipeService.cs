using AutoMapper;
using teahouse.Dtos.Recipe;
using teahouse.Dtos.Tea;
using teahouse.Models;

namespace teahouse.Services.RecipeService {
    public class RecipeService : IRecipeService {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RecipeService(IMapper mapper, DataContext context) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetRecipeDto>> AddRecipe(AddRecipeDto recipe) {
            try {
                Recipe newRecipe = _mapper.Map<Recipe>(recipe);
                await _context.Recipes.AddAsync(newRecipe);
                _context.SaveChanges();
                return new ServiceResponse<GetRecipeDto>(Data: _mapper.Map<GetRecipeDto>(newRecipe));
            } catch (System.Exception) {
                return new ServiceResponse<GetRecipeDto>(Message: ServiceResponseEnum.Error);
            }
        }

        public async Task<ServiceResponse<GetRecipeDto>> DeleteRecipe(int recipeId) {
            try {
                var recipe = await _context.Recipes.FindAsync(recipeId);
                if (recipe != null) {
                    _context.Recipes.Remove(recipe);
                    await _context.SaveChangesAsync();
                };
                return new ServiceResponse<GetRecipeDto>(Data: _mapper.Map<GetRecipeDto>(recipe));
            } catch (System.Exception) {
                return new ServiceResponse<GetRecipeDto>(Message: ServiceResponseEnum.Error);
            }
        }

        public async Task<ServiceResponse<GetRecipeDto>> UpdateRecipe(UpdateRecipeDto updatedRecipe) {
            try {
                var recipe = await _context.Recipes.FirstOrDefaultAsync<Recipe>(c => c.Id == updatedRecipe.Id);
                if (recipe != null) {
                    recipe.IngredientId = updatedRecipe.IngredientId;
                    recipe.TeaId = updatedRecipe.TeaId;
                    recipe.Quantity = updatedRecipe.Quantity;
                    await _context.SaveChangesAsync();
                };
                return new ServiceResponse<GetRecipeDto>(Data: _mapper.Map<GetRecipeDto>(recipe));
            } catch (System.Exception) {
                return new ServiceResponse<GetRecipeDto>(Message: ServiceResponseEnum.Error);
            }
        }

        public async Task<List<GetRecipeDto>> GetAllRecipes() {
            try {
                var recipes = await _context.Recipes
                    .Include(c => c.Tea)
                    .Include(c => c.Ingredient)
                    .OrderBy(r => r.TeaId)
                    .ToListAsync();
                return recipes.Select(c => _mapper.Map<GetRecipeDto>(c)).ToList();
            } catch (System.Exception) {
                return new();
            }
        }

        public async Task<ServiceResponse<GetRecipeDto>> GetRecipe(int id) {
            try {
                var recipe = await _context.Recipes.FirstOrDefaultAsync(t => t.Id == id);
                return new ServiceResponse<GetRecipeDto>(Data: _mapper.Map<GetRecipeDto>(recipe));
            } catch (System.Exception) {
                return new ServiceResponse<GetRecipeDto>(Message: ServiceResponseEnum.Error);
            }
        }
    }
}