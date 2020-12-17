using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegram_command.Abstractions
{
    public interface ICommandService
    {
        IEnumerable<TelegramCommand> Get();
    }
}
