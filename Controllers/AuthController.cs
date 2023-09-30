using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using teahouse.Models;
using teahouse.Services.AuthService;

namespace teahouse.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService authService)
    {
        _authService = authService;
        _logger = logger;
    }

    public IActionResult Login() {
        return View();
    }

    public IActionResult Register() {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetUserDto>>> RegisterUser(RegisterDto newUser) {
        return Ok(await _authService.Register(newUser));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetUserDto>>> LoginUser(LoginDto userCreds) {
        return Ok(await _authService.Login(userCreds));
    }
}
