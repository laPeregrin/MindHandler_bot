using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using telegram_command.Abstractions;

namespace telegram_command.Commands
{
    public class DetailsCommand : TelegramCommand
    {
        public override string Name => "подробности";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text) return false;
            return message.Text.ToLower().Contains(Name);
        }

        public async override Task Execute(Message message, ITelegramBotClient botClient)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id," 'start' это бессполезное приветсвие, 'зарегаться' название говорит само за себя, вы регестрируетесь и у вас появляется возможность сейвить свои мысли в базе, но тут не все так просто", ParseMode.Default, false, false, message.MessageId);
        }
    }
}
