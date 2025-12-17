using MuslimSalat.API.Models.Events;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.API.Mappers;

public static class EventMappers
{
    public static EventDto ToEventDto(this Event e)
    {
        return new()
        {
            Id = e.Id,
            Name = e.Name,
            IdUserResponsible = e.IdUserResponsible
        };
    }

    public static IEnumerable<EventDto> ToEventDto(this IEnumerable<Event> events)
    {
        return events.Select(e => e.ToEventDto());
    }

    public static Event ToEvent(this EventDto dto)
    {
        return new()
        {
            Id = dto.Id ?? 0,
            Name = dto.Name,
            IdUserResponsible = dto.IdUserResponsible
        };
    }

    public static Event CopyFromEventDto(this Event e, EventDto dto)
    {
        e.Id = dto.Id ?? throw new ArgumentException("Event ID is required.");
        e.Name = dto.Name;
        e.IdUserResponsible = dto.IdUserResponsible;
        return e;
    }
}