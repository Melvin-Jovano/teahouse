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
    public class TeaController : Controller
    {
        private readonly ILogger<TeaController> _logger;
        private readonly ITeaService _teaService;

        public TeaController(ILogger<TeaController> logger, ITeaService teaService)
        {
            this._teaService = teaService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var teas = await _teaService.GetAllTeas();
            ViewBag.Teas = teas;
            return View();
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<ServiceResponse<GetTeaDto>>> GetTea(int id) {
        //     return Ok(await _teaService.GetTea(id));
        // }

        // [HttpPost]
        // public async Task<ActionResult<ServiceResponse<GetTeaDto>>> AddTea(AddTeaDto tea) {
        //     return Ok(await _teaService.AddTea(tea));
        // }
    }
}