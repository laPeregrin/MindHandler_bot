using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBotInitialConfig.Services;

namespace MindHandler_bot.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTelegramBotClient(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            var client = new TelegramBotClient(configuration["Token"]);
            var webHook = $"{configuration["Url"]}/api/message/update";
            client.SetWebhookAsync(webHook).Wait();

            return serviceCollection
                .AddTransient<ITelegramBotClient>(IServiceProvider => client);
        }
    }
}
