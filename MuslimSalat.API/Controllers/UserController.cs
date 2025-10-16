using Microsoft.AspNetCore.Authorization;
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

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult Update([FromRoute] int id, [FromBody] RegisterFormDto form)
    {
        User user = _userService.GetUser(id).CopyFromRegisterFormDto(form);
        _userService.Update(user);
        return NoContent();
    }

    [HttpDelete]
    [Authorize]
    public ActionResult DeleteAccount([FromRoute] int id)
    {
        _userService.Delete(id);
        return Accepted();
    }
}
