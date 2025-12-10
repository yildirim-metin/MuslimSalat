namespace MuslimSalat.BLL.Models.Prayers;

public record class PrayerCalculationMethodParameter
{
    public required DateTime Date { get; set; }
    public required string Address { get; set; }
    public int Method { get; set; }
    public Shafaq Shafaq { get; set; }
    public int School { get; set; }
    public int MidnightMode { get; set; }
    public CalendarMethod CalendarMethod { get; set; }
}
