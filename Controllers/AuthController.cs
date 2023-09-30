using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
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
        var result = await _authService.Login(userCreds);

        if(result.Message == ServiceResponseEnum.Success) {
            HttpContext.Session.SetInt32("UserId", result.Data!.Id);
        }

        return Ok(result);
    }

    [HttpDelete]
    public ActionResult<ServiceResponse<bool>> LogoutUser() {
        HttpContext.Session.Clear();
        return Ok(new ServiceResponse<bool>(Data: true));
    }
}
