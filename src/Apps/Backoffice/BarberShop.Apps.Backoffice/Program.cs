using BarberShop.Apps.Backoffice.Services.Catalog;
using Microsoft.Extensions.DependencyInjection;

namespace BarberShop.Apps.Backoffice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add services
            builder.Services.AddHttpClient(nameof(CatalogService), (httpClient) =>
            {
                // TODO: Add some validations.
                httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("Services:Catalog:BaseUrl").Value);
            });
            builder.Services.AddScoped<CatalogService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
