using Microsoft.AspNetCore.Mvc;
using MuslimSalat.API.Mappers;
using MuslimSalat.API.Models.Users;
using MuslimSalat.BLL.Services;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult Login([FromBody] LoginFormDto form)
    {
        User user = _userService.Login(form.Username, form.Password);
        return NoContent();
    }

    [HttpPut]
    public ActionResult Register([FromBody] RegisterFormDto form)
    {
        _userService.Add(form.ToUser(), form.Password);
        return NoContent();
    }

    [HttpPost]
    public ActionResult Update([FromBody] RegisterFormDto form)
    {
        _userService.Update(form.ToUser());
        return NoContent();
    }

    [HttpDelete]
    public ActionResult DeleteAccount([FromRoute] int id)
    {
        _userService.Delete(id);
        return Accepted();
    }
}
