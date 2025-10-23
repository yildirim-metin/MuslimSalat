using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuslimSalat.API.Mappers;
using MuslimSalat.API.Models.Prayers;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DL.Entities;
using MuslimSalat.DL.Enums;

namespace MuslimSalat.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrayerController : ControllerBase
{
    private readonly IPrayerService _prayerService;

    public PrayerController(IPrayerService prayerService)
    {
        _prayerService = prayerService;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = $"{nameof(UserRole.Admin)}, {nameof(UserRole.User)}")]
    public ActionResult GetPrayer([FromRoute] int id)
    {
        Prayer prayer = _prayerService.GetPrayer(id);
        return Ok(prayer);
    }

    [HttpPost]
    [Authorize(Roles = $"{nameof(UserRole.Admin)}, {nameof(UserRole.User)}")]
    public ActionResult Add([FromBody] PrayerDto prayerDto)
    {
        _prayerService.Add(prayerDto.ToPrayer());
        return NoContent();
    }

    [HttpPut]
    [Authorize(Roles = $"{nameof(UserRole.Admin)}, {nameof(UserRole.User)}")]
    public ActionResult Update([FromBody] PrayerDto prayerDto)
    {
        _prayerService.Update(prayerDto.ToPrayer());
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = nameof(UserRole.Admin))]
    public ActionResult Delete([FromRoute] int id)
    {
        _prayerService.Delete(id);
        return Accepted();
    }
}
