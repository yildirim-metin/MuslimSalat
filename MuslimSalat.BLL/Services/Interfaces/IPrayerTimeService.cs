namespace MuslimSalat.BLL.Services.Interfaces;

public interface IPrayerTimeService
{
    public Task<string> GetPrayerTimeFromAddress(string address);
}
