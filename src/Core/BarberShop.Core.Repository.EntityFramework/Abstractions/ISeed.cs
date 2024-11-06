using Microsoft.EntityFrameworkCore;

namespace BarberShop.Core.Repository.EntityFramework.Abstractions
{
    public interface ISeed<TContext>
        where TContext : DbContext
    {
        Task SeedAsync(CancellationToken cancellationToken = default);
    }
}
