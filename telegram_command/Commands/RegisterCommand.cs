using EfDbLayer.EfDbContexts;
using EfDbLayer.Repository.ProxyRepos.IndividReps;
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
    public class RegisterCommand : TelegramCommand
    {
        private readonly ExplicitUser _service;

        public RegisterCommand(ExplicitUser service)
        {
            _service = service;
        }

        public override string Name => "зарегаться";

        public async override Task Execute(Message message, ITelegramBotClient botClient)
        {
            try
            {
                var you = new DTOObjects.DataObjects.User()
                {
                    UserId = message.Chat.Id.ToString(),
                    FirstName = message.Chat.FirstName,
                    LastName = message.Chat.LastName,
                    Username = message.Chat.Username,
                    ChatId = message.Chat.Id.GetHashCode().ToString()
                };
                var user = await _service.GetUserById(you.UserId);
                if (user != null)
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Ты и так уже часть команды, забыл чтоли? А я для чего? записывай скорее.");
                else
                {
                    await _service.Add(you);
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Поздравляю, теперь ты часть команды часть корабля. И запятых не будет.");
                }
            }
            catch (Exception e)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Вышла накладочка похоже что у меня проблемы с памятью или я уже тебя видел?");
                throw;
            }
        }

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text) return false;
            return message.Text.ToLower().Contains(Name);
        }
    }
}
