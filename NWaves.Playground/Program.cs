using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using MatBlazor;
using Radzen;

namespace NWaves.Playground
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();
            builder.Services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomFullWidth;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 100;
                config.VisibleStateDuration = 10000;
            });

            await builder.Build().RunAsync();
        }
    }
}
