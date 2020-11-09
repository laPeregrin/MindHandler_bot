using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotInitialConfig.Abstractions;

namespace TelegramBotInitialConfig.Commands
{
    public class HelpCommand : TelegramCommand
    {
        private readonly ICommandService _service;
        public HelpCommand(ICommandService service)
        {
           _service = service;
        }

        public override string Name => "help";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;
            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var commandsContainer = _service.Get(); 
            foreach(var command in commandsContainer)
            {
                await client.SendTextMessageAsync(chatId, $"/{command.Name}", ParseMode.Html);
            }
        }
    }
}
