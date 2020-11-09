using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MindHandler_bot.Extensions;
using TelegramBotInitialConfig.Abstractions;
using TelegramBotInitialConfig.Services;

namespace MindHandler_bot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private readonly IConfiguration _configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            services
            .AddScoped<ICommandService, CommandService>()
            .AddTelegramBotClient(_configuration)
            .AddControllers();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseHsts();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
