using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace telegram_command.Abstractions
{
    public abstract class TelegramCommand
    {
        public abstract string Name{ get;}

        public abstract Task Execute(Message message, ITelegramBotClient botClient);

        public abstract bool Contains(Message message);
    }
}
