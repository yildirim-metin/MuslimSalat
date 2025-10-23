namespace MuslimSalat.API.Models.Missions;

public record class MissionDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Level { get; set; } = null!;
}
