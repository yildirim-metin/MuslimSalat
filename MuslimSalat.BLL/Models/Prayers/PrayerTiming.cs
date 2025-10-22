namespace MuslimSalat.BLL.Models.Prayers;

public record class PrayerTiming
{
    public TimeOnly Imsak { get; set; }
    public TimeOnly Fajr { get; set; }
    public TimeOnly Sunrise { get; set; }
    public TimeOnly Dhuhr { get; set; }
    public TimeOnly Asr { get; set; }
    public TimeOnly Sunset { get; set; }
    public TimeOnly Maghrib { get; set; }
    public TimeOnly Isha { get; set; }
}
