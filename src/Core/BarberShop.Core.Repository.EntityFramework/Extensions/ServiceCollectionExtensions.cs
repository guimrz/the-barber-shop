using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BarberShop.Core.Repository.EntityFramework.Extensions
{
    /// <summary>
    /// Defines extensions for <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the SQL Server db context.
        /// </summary>
        /// <param name="services">The services collection.</param>
        /// <param name="connectionString">The connection string</param>
        /// <returns>The <paramref name="services"/> for fluent chainning.</returns>
        public static IServiceCollection AddSqlServerDbContext<TContext>(this IServiceCollection services, string connectionString)
            where TContext : DbContext
        {
            ArgumentNullException.ThrowIfNull(services);
            ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);

            services.AddDbContext<TContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(15), errorNumbersToAdd: null);
                });
            });

            return services;
        }
    }
}
