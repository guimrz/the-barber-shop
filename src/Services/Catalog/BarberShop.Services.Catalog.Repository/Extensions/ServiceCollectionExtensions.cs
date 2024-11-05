using BarberShop.Core.Repository.EntityFramework.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BarberShop.Services.Catalog.Repository.Extensions
{
    /// <summary>
    /// Defines extensions for <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the products service repository and its dependencies to the services collection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>The <paramref name="services"/> for fluent chainning.</returns>
        public static IServiceCollection AddCatalogServiceRepository(this IServiceCollection services, string connectionString)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.TryAddScoped<ICatalogServiceRepository, CatalogServiceRepository>();
            services.AddSqlServerDbContext<CatalogServiceDbContext>(connectionString);

            return services;
        }
    }
}