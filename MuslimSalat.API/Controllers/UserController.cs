using Microsoft.AspNetCore.Mvc;
using MuslimSalat.API.Mappers;
using MuslimSalat.API.Models.Users;
using MuslimSalat.BLL.Services;

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

    [HttpPut]
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
