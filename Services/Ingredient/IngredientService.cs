using AutoMapper;
using teahouse.Dtos.Ingredient;
using teahouse.Dtos.Tea;
using teahouse.Models;

namespace teahouse.Services.IngredientService {
    public class IngredientService : IIngredientService {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public IngredientService(IMapper mapper, DataContext context) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetIngredientDto>> BuyIngredient(BuyIngredientDto ingredientDto) {
            try {
                var ingredient = await _context.Ingredients.FirstOrDefaultAsync<Ingredient>(c => c.Id == ingredientDto.Id);
                if (ingredient != null) {
                    ingredient.Stock += ingredientDto.Stock;
                    await _context.SaveChangesAsync();
                };
                return new ServiceResponse<GetIngredientDto>(Data: _mapper.Map<GetIngredientDto>(ingredient));
            } catch (System.Exception) {
                return new ServiceResponse<GetIngredientDto>(Message: ServiceResponseEnum.Error);
            }
        }

        public async Task<List<GetIngredientDto>> GetAllIngredients() {
            try {
                var ingredients = await _context.Ingredients.ToListAsync();
                return ingredients.Select(c => _mapper.Map<GetIngredientDto>(c)).ToList();
            } catch (System.Exception) {
                return new();
            }
        }
    }
}