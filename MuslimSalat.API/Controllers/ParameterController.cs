using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuslimSalat.API.Mappers;
using MuslimSalat.API.Models.Parameters;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DL.Entities;
using MuslimSalat.DL.Enums;

namespace MuslimSalat.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParameterController : ControllerBase
{
    private readonly IParameterService _parameterService;

    public ParameterController(IParameterService parameterService)
    {
        _parameterService = parameterService;
    }

    [HttpGet("{idUser}")]
    [Authorize(Roles = $"{nameof(UserRole.Admin)}, ${nameof(UserRole.User)}")]
    public ActionResult GetParameter([FromRoute] int idUser)
    {
        ParameterDto parameterDto = _parameterService.GetParameter(idUser).ToParameterDto();
        return Ok(parameterDto);
    }

    [HttpPost]
    [Authorize(Roles = $"{nameof(UserRole.Admin)}, ${nameof(UserRole.User)}")]
    public ActionResult Add([FromBody] ParameterDto parameterDto)
    {
        _parameterService.Add(parameterDto.ToParameter());
        return NoContent();
    }

    [HttpPut("{id}")]
    [Authorize(Roles = $"{nameof(UserRole.Admin)}, ${nameof(UserRole.User)}")]
    public ActionResult Update([FromRoute] int id, [FromBody] ParameterDto parameterDto)
    {
        _parameterService.Update(id, parameterDto.ToParameter());
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = nameof(UserRole.Admin))]
    public ActionResult Delete([FromRoute] int id)
    {
        _parameterService.Delete(id);
        return Accepted();
    }
}
