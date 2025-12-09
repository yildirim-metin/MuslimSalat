using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuslimSalat.API.Mappers;
using MuslimSalat.API.Models.Missions;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DL.Entities;
using MuslimSalat.DL.Enums;

namespace MuslimSalat.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MissionController : ControllerBase
{
    private readonly IMissionService _missionService;

    public MissionController(IMissionService missionService)
    {
        _missionService = missionService;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = $"{nameof(UserRole.Admin)}, {nameof(UserRole.User)}")]
    public ActionResult GetMission([FromRoute] int id)
    {
        Mission mission = _missionService.GetMission(id);
        return Ok(mission);
    }

    [HttpGet]
    [Authorize(Roles = $"{nameof(UserRole.Admin)}, {nameof(UserRole.User)}")]
    public ActionResult GetMissions()
    {
        return Ok(_missionService.GetMissions().ToMissionDtos());
    }
    
    [HttpPost]
    [Authorize(Roles = $"{nameof(UserRole.Admin)}, {nameof(UserRole.User)}")]
    public ActionResult Add([FromBody] MissionDto missionDto)
    {
        Mission mission = missionDto.ToMission();
        _missionService.Add(mission);
        return CreatedAtAction(nameof(GetMission), new { id = mission.Id }, mission.ToMissionDto());
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = $"{nameof(UserRole.Admin)}, {nameof(UserRole.User)}")]
    public ActionResult Update([FromRoute] int id, [FromBody] MissionDto missionDto)
    {
        Mission mission = _missionService.GetMission(id).CopyFromMissionDto(missionDto);
        _missionService.Update(mission);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = nameof(UserRole.Admin))]
    public ActionResult Delete([FromRoute] int id)
    {
        _missionService.Delete(id);
        return Accepted();
    }
}
