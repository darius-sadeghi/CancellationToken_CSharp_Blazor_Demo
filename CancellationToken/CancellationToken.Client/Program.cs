using CancellationToken.Client.Components;
using CancellationToken.Shared.Interfaces;
using CancellationToken.Shared.Proxies;

namespace CancellationToken.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddHttpClient();


            builder.Services.AddScoped<IWeatherForecastExchange, WeatherForecastProxy>();
            builder.Services.AddScoped<IWeatherForecastExchangeWithCancellation, WeatherForecastProxyWithCancellation>();
            builder.Services.AddScoped(sp => new HttpClient()
            {
                BaseAddress =
            new Uri("https://localhost:7264")
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
