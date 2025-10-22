using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuslimSalat.BLL.Models.Prayers;
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

    [HttpGet]
    [Authorize(Roles = $"{nameof(UserRole.Admin)}, {nameof(UserRole.User)}")]
    public async Task<ActionResult> GetPrayerTimeFromAddress([FromBody] PrayerCalculationMethodParameter parameter)
    {
        PrayerTiming timings = await _prayerTimeService.GetPrayerTimeFromAddress(parameter);
        return Ok(timings);
    }
}
