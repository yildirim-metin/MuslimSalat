
using Microsoft.AspNetCore.Mvc;
using MuslimSalat.API.Mappers;
using MuslimSalat.API.Models.Users;
using MuslimSalat.BLL.Services;
using MuslimSalat.DL.Entities;



[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;
    private readonly AuthService _authService;


    public AuthController(UserService userService, AuthService authService)

    {
        _userService = userService;
        _authService = authService;
    }

    [HttpPost("register")]

     public ActionResult Register([FromBody] RegisterFormDto registerForm )
        {
            if (registerForm is null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            User newUser = registerForm.ToUser();
            _userService.Register(newUser, registerForm.Password);

            return Created();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginFormDto loginForm)
        {
            if (loginForm is null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            User user = _userService.Login(loginForm.Username, loginForm.Password);

               string token = _authService.GenerateToken(user);

            return Ok(new { token });
        }

}