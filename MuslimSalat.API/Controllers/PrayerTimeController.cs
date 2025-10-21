using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DL.Enums;

namespace MuslimSalat.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrayerTimeController : ControllerBase
{
    private readonly IPrayerTimeService _prayerTimeService;

    public PrayerTimeController(IPrayerTimeService prayerTimeService)
    {
        _prayerTimeService = prayerTimeService;
    }

    [HttpGet("{address}")]
    [Authorize(Roles = $"{nameof(UserRole.Admin)}, {nameof(UserRole.User)}")]
    public async Task<ActionResult> GetPrayerTimeFromAddress([FromRoute] string address)
    {
        string response = await _prayerTimeService.GetPrayerTimeFromAddress(address);
        return Ok(response);
    }
}
