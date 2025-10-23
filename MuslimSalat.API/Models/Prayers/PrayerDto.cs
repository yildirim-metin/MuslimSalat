namespace MuslimSalat.API.Models.Prayers;

public record class PrayerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime Datetime { get; set; }
    public bool Done { get; set; }
}
