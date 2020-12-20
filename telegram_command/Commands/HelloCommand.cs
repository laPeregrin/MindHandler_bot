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
          
            await botClient.SendTextMessageAsync(message.Chat.Id, " Команда 'записать свои мысли' создана для того что бы вы разгружали ваши мысли и переживания сюда и тем самым структурировали всё внутри своей 'черепной коробочки'. Так же не плохо помогает сконцетнрироваться и перезагрузиться эмоционально. А еще мой создатель не любит запятые) Напиши 'подроности' если хочешь больше узнать про команды"
               );
        }
    }
}
