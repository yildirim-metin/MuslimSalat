namespace MuslimSalat.API.Models.Events;

public record class EventDto
{
    public int? Id { get; set; }

    public required string Name { get; set; }

    public int IdUserResponsible { get; set; }
}
