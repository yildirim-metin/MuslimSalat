namespace MuslimSalat.API.Models.Parameters;

public record class ParameterDto
{
    public int Id { get; set; }
    public byte PrayerReminderMinutes { get; set; }
    public bool CalculationStrategy { get; set; }
    public int IdUser { get; set; }
}
