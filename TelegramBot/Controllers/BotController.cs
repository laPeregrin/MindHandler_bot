using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using telegram_command.Abstractions;

namespace TelegramBot.Controllers
{

    [ApiController]
    [Route("api/messageUpdate")]
    public class BotController : Controller
    {
        private readonly ILogger<BotController> _logger;
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly ICommandService _commandService;

        public BotController(ITelegramBotClient telegramBotClient, ICommandService commandService, ILogger<BotController> logger)
        {
            _telegramBotClient = telegramBotClient;
            _commandService = commandService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> TestWorking()
        {
            return Ok("Sooo... it is work, hope other all too");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            try
            {
                if (update == null)
                {
                    _logger.LogWarning("update is null");
                    return Ok();
                }
                var message = update.Message;
                foreach (var command in _commandService.Get())
                {
                    if (command.Contains(message))
                    {
                        await command.Execute(message, _telegramBotClient);
                        break;
                    }
                }
                _logger.LogInformation("worked with {e}", update.Message.Chat.Id);
                return Ok();
            }
            catch(Exception e)
            {
                _logger.LogWarning("exception with command", e);
                return Ok();
            }
        }
    }
}
