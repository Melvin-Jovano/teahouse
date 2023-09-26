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
            return View(await _teaService.GetAllTeas());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetTeaDto>>> AddTea(AddTeaDto tea) {
            return Ok(await _teaService.AddTea(tea));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetTeaDto>>> DeleteTea(int id) {
            return Ok(await _teaService.DeleteTea(id));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetTeaDto>>> UpdateTea(UpdateTeaDto tea) {
            return Ok(await _teaService.UpdateTea(tea));
        }
    }
}