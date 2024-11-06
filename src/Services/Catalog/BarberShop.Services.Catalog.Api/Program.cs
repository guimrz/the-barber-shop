using BarberShop.Services.Catalog.Application.Extensions;
using BarberShop.Services.Catalog.Repository.Extensions;
using NSwag;

namespace BarberShop.Services.Catalog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCatalogServiceApplication();
            builder.Services.AddCatalogServiceRepository(builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Could not retrieve the connection string."));

            builder.Services.AddControllers();
            builder.Services.AddOpenApiDocument(options =>
            {
                options.PostProcess = document =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Catalog API"
                    };
                };
            });

            builder.Services.AddHealthChecks();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseOpenApi();
                app.UseSwaggerUi();
                app.UseReDoc(options =>
                {
                    options.DocumentTitle = "Catalog API Documentation";
                    options.Path = "/docs";
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseHealthChecks("/health");

            app.MapControllers();

            app.UseCatalogServiceRepository();

            app.Run();
        }
    }
}
