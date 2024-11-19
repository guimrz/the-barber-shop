using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace BarberShop.Gateway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration
                .AddJsonFile("ocelot.json")
                .AddJsonFile("ocelot.catalog.json");

            builder.Services.AddOcelot();


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            await app.UseOcelot();

            app.Run();
        }
    }
}
