using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuslimSalat.API.Mappers;
using MuslimSalat.API.Models.Events;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DL.Entities;
using MuslimSalat.DL.Enums;

namespace MuslimSalat.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = $"{nameof(UserRole.Admin)}, {nameof(UserRole.User)}")]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<EventDto>> GetEvents()
    {
        return Ok(_eventService.GetEvents().ToEventDto());
    }

    [HttpGet("{id}")]
    public ActionResult<EventDto> GetEvent(int id)
    {
        Event e = _eventService.GetEvent(id);
        return Ok(e.ToEventDto());
    }

    [HttpPost]
    public ActionResult<EventDto> Add([FromBody] EventDto eventDto)
    {
        Event e = eventDto.ToEvent();
        _eventService.Add(e);
        return CreatedAtAction(nameof(GetEvent), new { id = e.Id }, e.ToEventDto());
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromRoute] int id, [FromBody] EventDto eventDto)
    {
        Event e = _eventService.GetEvent(id).CopyFromEventDto(eventDto);
        _eventService.Update(e);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _eventService.Delete(id);
        return Accepted();
    }
}