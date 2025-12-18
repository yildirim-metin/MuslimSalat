namespace MuslimSalat.API.Models.Events;

public record class RegisterEventDto
{
    public int? Id { get; set; }

    public required string Name { get; set; }

    public int IdUserResponsible { get; set; }
}
