using BarberShop.Core.Mediator.Extensions;
using BarberShop.Services.Catalog.Application.Mapping;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

            // Configure the mediator.
            services.AddMediator(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            // Configure the auto mapper.
            services.AddAutoMapper(config =>
            {
                config.AddProfile<ProductMapProfile>();
            });

            // Registers the validators defined in this assembly.
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
