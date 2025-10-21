using Microsoft.AspNetCore.Mvc;
using MuslimSalat.API.Mappers;
using MuslimSalat.API.Models.Users;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public AuthController(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    [HttpPost]
    public ActionResult Register([FromBody] RegisterFormDto registerForm)
    {
        if (registerForm is null || !ModelState.IsValid)
        {
            return BadRequest();
        }

        User newUser = registerForm.ToUser();
        _userService.Register(newUser, registerForm.Password);

        return Created();
    }

    [HttpGet]
    public ActionResult Login([FromBody] LoginFormDto loginForm)
    {
        if (loginForm is null || !ModelState.IsValid)
        {
            return BadRequest();
        }

        User user = _userService.Login(loginForm.EmailOrUsername, loginForm.Password);

        string token = _authService.GenerateToken(user);

        return Ok(new { token });
    }
}