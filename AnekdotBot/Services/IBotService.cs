using Telegram.Bot;

namespace AnekdotBot.Services
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
    }
}
