using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotInitialConfig.Abstractions;
using TelegramBotInitialConfig.Commands;

namespace TelegramBotInitialConfig.Services
{
    public class CommandService : ICommandService
    {
        private readonly List<TelegramCommand> _commands;

        public CommandService(List<TelegramCommand> commands)
        {
            _commands = new List<TelegramCommand>
            {
                new StartCommand(),
                new HelpCommand(this)
            };
        }

        public List<TelegramCommand> Get() => _commands;
       
    }
}
