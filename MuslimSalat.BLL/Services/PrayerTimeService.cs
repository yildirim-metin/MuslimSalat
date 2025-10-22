using Microsoft.Extensions.Configuration;
using MuslimSalat.BLL.Services.Interfaces;

namespace MuslimSalat.BLL.Services;

public class PrayerTimeService : IPrayerTimeService
{
    private readonly HttpClient _httpClient;

    public PrayerTimeService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClient = httpClientFactory.CreateClient(configuration["PrayerTimesApi:Title"]!);
    }

    public async Task<string> GetPrayerTimeFromAddress(string address)
    {
        string date = DateTime.UtcNow.ToString("dd-MM-yyyy");
        string url = $"{_httpClient.BaseAddress}/timingsByAddress/{date}?address={Uri.EscapeDataString(address)}";

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

        return responseBody;
    }
}