using MuslimSalat.BLL.Models.Prayers;

namespace MuslimSalat.BLL.Services.Interfaces;

public interface IPrayerTimeService
{
    public Task<PrayerTiming> GetPrayerTimeFromAddress(PrayerCalculationMethodParameter parameter);
}
