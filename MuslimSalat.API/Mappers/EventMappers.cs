using MuslimSalat.API.Models.Events;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.API.Mappers;

public static class EventMappers
{
    public static RegisterEventDto ToRegisterEventDto(this Event e)
    {
        return new()
        {
            Id = e.Id,
            Name = e.Name,
            IdUserResponsible = e.IdUserResponsible
        };
    }

    public static IEnumerable<RegisterEventDto> ToRegisterEventDto(this IEnumerable<Event> events)
    {
        return events.Select(e => e.ToRegisterEventDto());
    }

    public static Event ToEvent(this RegisterEventDto dto)
    {
        return new()
        {
            Id = dto.Id ?? 0,
            Name = dto.Name,
            IdUserResponsible = dto.IdUserResponsible
        };
    }

    public static Event CopyFromEventDto(this Event e, RegisterEventDto dto)
    {
        e.Id = dto.Id ?? throw new ArgumentException("Event ID is required.");
        e.Name = dto.Name;
        e.IdUserResponsible = dto.IdUserResponsible;
        return e;
    }

    public static EventDto ToEventDto(this Event e)
    {
        return new()
        {
            Id = e.Id,
            Name = e.Name,
            IdUserResponsible = e.IdUserResponsible,
            Responsible = e.IdUserResponsibleNavigation.Username ?? "",
        };
    }

    public static IEnumerable<EventDto> ToEventDto(this IEnumerable<Event> events)
    {
        return events.Select(e => e.ToEventDto());
    }
}