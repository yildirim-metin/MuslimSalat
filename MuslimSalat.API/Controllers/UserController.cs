using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuslimSalat.API.Mappers;
using MuslimSalat.API.Models.Users;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DL.Entities;
using MuslimSalat.DL.Enums;

namespace MuslimSalat.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = nameof(UserRole.Admin))]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserFormDto>> GetAll()
    {
        return Ok(_userService.GetAll().ToUserFormDto());
    }
    
    [HttpPost]
    public ActionResult Register([FromBody] UserFormDto form)
    {
        User user = form.ToUser();
        _userService.Add(user);
        return Ok(user);
    }
    
    [HttpPut("{id}")]
    public ActionResult Update([FromRoute] int id, [FromBody] UserFormDto form)
    {
        User user = _userService.GetUser(id).CopyFromUserFormDto(form);
        _userService.Update(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAccount([FromRoute] int id)
    {
        _userService.Delete(id);
        return Accepted();
    }
}