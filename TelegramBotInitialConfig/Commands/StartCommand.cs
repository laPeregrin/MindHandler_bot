using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotInitialConfig.Abstractions;

namespace TelegramBotInitialConfig.Commands
{
    public class StartCommand : TelegramCommand
    {
        public override string Name => "greeting";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            await client.SendTextMessageAsync(chatId, "Привет, ", ParseMode.Html);
        }
    }
}
