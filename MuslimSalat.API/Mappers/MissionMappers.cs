using MuslimSalat.API.Models.Missions;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.API.Mappers;

public static class MissionMappers
{
    public static Mission ToMission(this MissionDto missionDto)
    {
        return new()
        {
            Id = missionDto.Id,
            Name = missionDto.Name,
            Description = missionDto.Description,
            Level = missionDto.Level,
        };
    }

    public static Mission CopyFromMissionDto(this Mission mission, MissionDto missionDto)
    {
        mission.Name = missionDto.Name;
        mission.Description = missionDto.Description;
        mission.Level = missionDto.Level;
        return mission;
    }
}
