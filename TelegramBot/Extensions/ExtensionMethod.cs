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
            var webhook = $"{configuration["Url"]}/api/messageUpdate";
            var webhookTest = "https://48486f7d744b.ngrok.io/api/messageUpdate";
            var botClient = new TelegramBotClient(configuration["Token"]);
            botClient.SetWebhookAsync(webhookTest);
            return services.AddTransient<ITelegramBotClient>(x=>botClient);
        }
    }
}
