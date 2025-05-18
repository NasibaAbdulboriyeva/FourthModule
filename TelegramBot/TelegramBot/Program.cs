using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using ChatBotBll;

class Program
{
    static string token = "7623605198:AAG4Kfomx-6S8XwxjuIKh-8V3gPAnY9VCjE"; // Bot tokeningizni qo'ying
    static ITelegramBotClient botClient = new TelegramBotClient(token);
    static PrayerTimesService prayerService = new PrayerTimesService();

    static async Task Main()
    {
        Console.WriteLine("Namoz vaqti boti ishga tushdi...");

        using var cts = new CancellationTokenSource();
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = new[] { UpdateType.Message }
        };

        botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            errorHandler: HandleErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );

        Console.ReadLine();
        cts.Cancel();
    }

    static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message || message.Text is not { } messageText)
            return;

        long chatId = message.Chat.Id;
        Console.WriteLine($"Yangi xabar: {messageText}");

        string response;
        if (messageText.StartsWith("/namoz"))
        {
            string city = messageText.Replace("/namoz", "").Trim();
            if (string.IsNullOrEmpty(city)) city = "Tashkent"; // Default shahar
            response = await prayerService.GetFormattedPrayerTimes(city);
        }
        else
        {
            response = "✅ Namoz vaqtlarini bilish uchun: `/namoz Toshkent` yoki `/namoz Andijon` deb yozing.";
        }

        await bot.SendTextMessageAsync(chatId, response, cancellationToken: cancellationToken);
    }

    static Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Xatolik: {exception.Message}");
        return Task.CompletedTask;
    }
}
