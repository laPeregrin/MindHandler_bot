using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotInitialConfig.Abstractions
{
    public interface ICommandService
    {
        List<TelegramCommand> Get();
    }
}
