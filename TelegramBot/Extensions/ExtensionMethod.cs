using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot.Extensions
{
    public static class ExtensionMethod
    {
        public static IServiceCollection AddTelegramBotClient(this IServiceCollection services, IConfiguration configuration)
        {
            var webhook = $"{configuration["Url"]}api/message/update";

            var botClient = new TelegramBotClient(configuration["Token"]);
            botClient.SetWebhookAsync(webhook);
            return services.AddTransient<ITelegramBotClient>(x=>botClient);
        }
    }
}
