using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using teahouse.Dtos.Ingredient;
using teahouse.Models;
using teahouse.Services.IngredientService;

namespace teahouse.Controllers
{
    public class IngredientController : Controller
    {
        private readonly ILogger<IngredientController> _logger;
        private readonly IIngredientService _ingredientService;

        public IngredientController(ILogger<IngredientController> logger, IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _ingredientService.GetAllIngredients());
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetIngredientDto>>> BuyIngredient(BuyIngredientDto ingredientDto) {
            return Ok(await _ingredientService.BuyIngredient(ingredientDto));
        }
    }
}