using MuslimSalat.API.Models.Prayers;

namespace MuslimSalat.BLL.Services.Interfaces;

public interface IPrayerTimeService
{
    public Task<string> GetPrayerTimeFromAddress(PrayerCalculationMethodParameter address);
}
