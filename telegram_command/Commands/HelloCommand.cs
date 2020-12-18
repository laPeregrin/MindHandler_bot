using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using telegram_command.Abstractions;

namespace telegram_command.Commands
{
    public class HelloCommand : TelegramCommand
    {
        public override string Name => "start";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text) return false;
            return message.Text.Contains(Name);
        }

        public async override Task Execute(Message message, ITelegramBotClient botClient)
        {
          
            await botClient.SendTextMessageAsync(message.Chat.Id, " 'Write your mind' создан для того что бы вы записывали сюда свои мысли и тем самым структурировали всё внутри своей 'черпеной коробочки'. Так же не плохо помогает сконцетнрироваться и разгрузиться эмоционально"
               );
        }
    }
}
