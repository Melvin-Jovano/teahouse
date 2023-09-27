using AutoMapper;
using teahouse.Models;

namespace teahouse {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            CreateMap<Tea, GetTeaDto>();
            CreateMap<AddTeaDto, Tea>();

            CreateMap<Ingredient, GetIngredientDto>();
            CreateMap<AddIngredientDto, Ingredient>();

            CreateMap<Recipe, GetRecipeDto>();
            CreateMap<AddRecipeDto, Recipe>();
        }
    }
}