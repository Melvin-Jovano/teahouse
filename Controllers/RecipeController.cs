using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using teahouse.Models;

namespace teahouse.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeService _recipeService;
        private readonly ITeaService _teaService;
        private readonly IIngredientService _ingredientService;

        public RecipeController(
            ILogger<RecipeController> logger, 
            IRecipeService recipeService,
            ITeaService teaService,
            IIngredientService ingredientService
        )
        {
            this._recipeService = recipeService;
            this._ingredientService = ingredientService;
            this._teaService = teaService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.AllTeas = await _teaService.GetAllTeas();
            ViewBag.AllIngredients = await _ingredientService.GetAllIngredients();
            return View(await _recipeService.GetAllRecipes());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> AddRecipe(AddRecipeDto recipe) {
            return Ok(await _recipeService.AddRecipe(recipe));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> DeleteRecipe(int id) {
            return Ok(await _recipeService.DeleteRecipe(id));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> UpdateRecipe(UpdateRecipeDto recipe) {
            return Ok(await _recipeService.UpdateRecipe(recipe));
        }
    }
}