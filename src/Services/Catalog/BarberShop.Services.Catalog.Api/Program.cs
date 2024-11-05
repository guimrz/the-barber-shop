using BarberShop.Services.Catalog.Application.Extensions;
using BarberShop.Services.Catalog.Repository.Extensions;

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
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseCatalogServiceRepository();

            app.Run();
        }
    }
}
