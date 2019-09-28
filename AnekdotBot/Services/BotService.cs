using AnekdotBot.Models;
using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace AnekdotBot.Services
{
    public class BotService : IBotService
    {
        public TelegramBotClient Client { get; }
        private readonly BotConfiguration _config;

        public BotService(IOptions<BotConfiguration> config)
        {
            _config = config.Value;
            Client = new TelegramBotClient(_config.Key);

        }
    }
}