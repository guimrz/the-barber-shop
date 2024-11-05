using BarberShop.Core.Repository.EntityFramework.Extensions;
using BarberShop.Services.Catalog.Repository;
using Microsoft.AspNetCore.Builder;

namespace BarberShop.Services.Catalog.Repository.Extensions
{
    /// <summary>
    /// Defines extensions for <see cref="IApplicationBuilder"/>
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCatalogServiceRepository(this IApplicationBuilder applicationBuilder)
        {
            ArgumentNullException.ThrowIfNull(applicationBuilder);

            applicationBuilder.MigrateDatabase<CatalogServiceDbContext>();

            return applicationBuilder;
        }
    }
}
