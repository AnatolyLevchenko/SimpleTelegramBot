﻿using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace AnekdotBot.Services
{
    public interface IUpdateService
    {
        Task EchoAsync(Update update);
    }
}
