using Microsoft.Extensions.DependencyInjection;

namespace BarberShop.Core.Mediator.Extensions
{
    /// <summary>
    /// Defines extensions for <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, Action<MediatRServiceConfiguration>? configAction = null)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddMediatR(config =>
            {
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));

                configAction?.Invoke(config);
            });

            return services;
        }
    }
}
