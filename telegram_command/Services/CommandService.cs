using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using telegram_command.Abstractions;
using telegram_command.Commands;

namespace telegram_command.Services
{
    public class CommandService : ICommandService
    {
        private readonly IEnumerable<TelegramCommand> commands;

        public CommandService()
        {
            commands = new List<TelegramCommand>()
            {
                new HelloCommand()
            };
        }

        public IEnumerable<TelegramCommand> Get()
        {
            return commands;
        }
    }
}
