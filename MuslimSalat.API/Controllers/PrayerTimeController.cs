using Microsoft.AspNetCore.Mvc;
using MuslimSalat.BLL.Services.Interfaces;

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
    public async Task<ActionResult> GetPrayerTimeFromAddress([FromRoute] string address)
    {
        string response = await _prayerTimeService.GetPrayerTimeFromAddress(address);
        return Ok(response);
    }
}
