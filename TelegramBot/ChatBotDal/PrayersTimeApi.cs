using ChatBotDal.Entities;
using System.Text.Json;

namespace ChatBotDal;

public class PrayerTimesApi
{
    private readonly HttpClient _httpClient;

    public PrayerTimesApi()
    {
        _httpClient = new HttpClient();
    }

    public async Task<PrayerTimes?> GetPrayerTimesAsync(string city)
    {
        string url = $"https://api.aladhan.com/v1/timingsByCity?city={city}&country=Uzbekistan&method=2";

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(json);
            JsonElement timings = doc.RootElement.GetProperty("data").GetProperty("timings");

            return new PrayerTimes
            {
                City = city,
                Fajr = timings.GetProperty("Fajr").GetString() ?? "",
                Dhuhr = timings.GetProperty("Dhuhr").GetString() ?? "",
                Asr = timings.GetProperty("Asr").GetString() ?? "",
                Maghrib = timings.GetProperty("Maghrib").GetString() ?? "",
                Isha = timings.GetProperty("Isha").GetString() ?? ""
            };
        }
        catch (Exception)
        {
            return null;
        }
    }
}
