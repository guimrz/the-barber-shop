using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BarberShop.Core.Repository.EntityFramework.Extensions
{
    /// <summary>
    /// Defines extensions for <see cref="IApplicationBuilder"/>.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Applies all the pending migrations for the <typeparamref name="TContext"/> to the database. 
        /// </summary>
        /// <typeparam name="TContext">The context type.</typeparam>
        /// <param name="applicationBuilder">The application builder.</param>
        /// <returns>The <paramref name="applicationBuilder"/> for fluent chainning.</returns>
        public static async Task<IApplicationBuilder> MigrateDatabaseAsync<TContext>(this IApplicationBuilder applicationBuilder)
            where TContext : DbContext
        {
            ArgumentNullException.ThrowIfNull(applicationBuilder);

            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<TContext>();

            await context.Database.MigrateAsync();

            return applicationBuilder;
        }

        /// <summary>
        /// Applies all the pending migrations for the <typeparamref name="TContext"/> to the database. 
        /// </summary>
        /// <typeparam name="TContext">The context type.</typeparam>
        /// <param name="applicationBuilder">The application builder.</param>
        /// <returns>The <paramref name="applicationBuilder"/> for fluent chainning.</returns>
        public static IApplicationBuilder MigrateDatabase<TContext>(this IApplicationBuilder applicationBuilder)
            where TContext : DbContext
        {
            ArgumentNullException.ThrowIfNull(applicationBuilder);

            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<TContext>();

            context.Database.Migrate();

            return applicationBuilder;
        }
    }
}
