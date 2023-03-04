using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Sotsera.Blazor.Toaster.Core.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientSide
{ 
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddToaster(config =>
            {
                config.PositionClass = Defaults.Classes.Position.TopRight;
                config.ToastTitleClass = $"{Defaults.Classes.ToastTitle} {Defaults.Classes.TextPosition.Left}";
                config.ToastMessageClass = $"{Defaults.Classes.ToastMessage} {Defaults.Classes.TextPosition.Left}";
                config.PreventDuplicates = true;
                config.NewestOnTop = false;
            });

            await builder.Build().RunAsync();
        }
    }
}


 