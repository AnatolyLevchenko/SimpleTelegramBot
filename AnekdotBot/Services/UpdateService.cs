using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AnekdotBot.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IBotService _botService;
        private readonly ILogger<UpdateService> _logger;
        private readonly IJoke _joke;

        public UpdateService(IBotService botService, ILogger<UpdateService> logger, IJoke joke)
        {
            _botService = botService;
            _logger = logger;
            _joke = joke;
        }

        public async Task EchoAsync(Update update)
        {
            if (update.Type != UpdateType.Message)
            {
                return;
            }

            var text = update.Message.Text;

            string joke;
            if (text.Contains("/an"))
                joke = await _joke.Get(Category.an);
            else if (text.Contains("/af"))
                joke = await _joke.Get(Category.af);
            else if (text.Contains("/an18"))
                joke = await _joke.Get(Category.an18);
            else if(text.Contains("/ra"))
                joke= await _joke.Get(Category.ra);
            else if (text.Contains("/st"))
                joke = await _joke.Get(Category.st);
            else if (text.Contains("/to"))
                joke = await _joke.Get(Category.to);
            else joke = await _joke.Get(Category.an);


            await _botService.Client.SendTextMessageAsync(update.Message.Chat.Id, joke);


            //update.Type==

            //var message = update.Message;

            //_logger.LogInformation("Received Message from {0}", message.Chat.Id);

            //if (message.Type == MessageType.Text)
            //{
            //    // Echo each Message
            //    await _botService.Client.SendTextMessageAsync(message.Chat.Id, message.Text);
            //}
            //else if (message.Type == MessageType.Photo)
            //{
            //    // Download Photo
            //    var fileId = message.Photo.LastOrDefault()?.FileId;
            //    var file = await _botService.Client.GetFileAsync(fileId);

            //    var filename = file.FileId + "." + file.FilePath.Split('.').Last();

            //    using (var saveImageStream = System.IO.File.Open(filename, FileMode.Create))
            //    {
            //        await _botService.Client.DownloadFileAsync(file.FilePath, saveImageStream);
            //    }

            //    await _botService.Client.SendTextMessageAsync(message.Chat.Id, "Thx for the Pics");
            //       }
        }
    }
}
