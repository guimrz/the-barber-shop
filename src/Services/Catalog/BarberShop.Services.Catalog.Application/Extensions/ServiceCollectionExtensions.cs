using BarberShop.Services.Catalog.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BarberShop.Services.Catalog.Application.Extensions
{
    /// <summary>
    /// Defines extensions for <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCatalogServiceApplication(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.TryAddScoped<ICatalogService, CatalogService>();

            // Configure the auto mapper.
            services.AddAutoMapper(config =>
            {
                config.AddProfile<ProductMapProfile>();
            });

            return services;
        }
    }
}
