using MuslimSalat.BLL.Services.Interfaces;

namespace MuslimSalat.BLL.Services;

public class PrayerTimeService : IPrayerTimeService
{
    public async Task<string> GetPrayerTimeFromAddress(string address)
    {
        HttpClient httpClient = new();

        string date = DateTime.UtcNow.ToString("dd-MM-yyyy");
        string url = $"https://api.aladhan.com/v1/timingsByAddress/{date}?address=";

        url += Uri.EscapeDataString(address);

        HttpResponseMessage response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

        return responseBody;
    }
}