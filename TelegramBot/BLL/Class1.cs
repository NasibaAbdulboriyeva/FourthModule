using System.Threading.Tasks;
using ChatBotDal.Entities;
using ChatBotDal;

namespace ChatBotBll
{
    public class PrayerTimesService
    {
        private readonly PrayerTimesApi _api;

        public PrayerTimesService()
        {
            _api = new PrayerTimesApi();
        }

        public async Task<string> GetFormattedPrayerTimes(string city)
        {
            PrayerTimes? timings = await _api.GetPrayerTimesAsync(city);
            if (timings == null)
                return "❌ Xatolik: Namoz vaqtlari olinmadi. Shahar nomini to‘g‘ri kiriting!";

            return $"🌙 Bugungi namoz vaqtlari ({timings.City}):\n" +
                   $"- Bomdod: {timings.Fajr}\n" +
                   $"- Peshin: {timings.Dhuhr}\n" +
                   $"- Asr: {timings.Asr}\n" +
                   $"- Shom: {timings.Maghrib}\n" +
                   $"- Xufton: {timings.Isha}";
        }
    }
}
