using System.Text.Json;
using Microsoft.Extensions.Configuration;
using MuslimSalat.BLL.Models.Prayers;
using MuslimSalat.BLL.Services.Interfaces;

namespace MuslimSalat.BLL.Services;

public class PrayerTimeService : IPrayerTimeService
{
    private readonly HttpClient _httpClient;

    public PrayerTimeService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClient = httpClientFactory.CreateClient(configuration["PrayerTimesApi:Title"]!);
    }

    public async Task<PrayerTiming> GetPrayerTimeFromAddress(PrayerCalculationMethodParameter parameter)
    {
        if (parameter.Address is null)
        {
            throw new NullReferenceException(nameof(parameter.Address));
        }

        string date = DateTime.UtcNow.ToString("dd-MM-yyyy");
        string url = $"{_httpClient.BaseAddress}/timingsByAddress/{date}"
                     + $"?address={Uri.EscapeDataString(parameter.Address)}"
                     + $"&method={parameter.Method}"
                     + $"&shafaq={parameter.Shafaq}"
                     + $"&school={parameter.School}"
                     + $"&midnightMode={parameter.MidnightMode}"
                     + $"&calendarMethod={parameter.CalendarMethod}";

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(json);
        JsonElement timingElements = doc.RootElement.GetProperty("data").GetProperty("timings");

        PrayerTiming timings = JsonSerializer.Deserialize<PrayerTiming>(timingElements)!;

        return timings;
    }
}