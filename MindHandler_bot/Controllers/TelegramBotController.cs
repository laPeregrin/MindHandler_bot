using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotInitialConfig.Abstractions;

namespace MindHandler_bot.Controllers
{
    [ApiController]
    [Route("api/message/update")]
    public class TelegramBotController : Controller
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly ICommandService _commandService;

        public TelegramBotController(ITelegramBotClient telegramBotClient, ICommandService commandService)
        {
            _telegramBotClient = telegramBotClient;
            _commandService = commandService;
        }
    
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Started");
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            if (update == null) return Ok();

            var message = update.Message;

            foreach(var command in _commandService.Get())
            {
                if(command.Contains(message))
                {
                    await command.Execute(message, _telegramBotClient);
                    break;
                }
            }
            return Ok();
        }
    }
}
