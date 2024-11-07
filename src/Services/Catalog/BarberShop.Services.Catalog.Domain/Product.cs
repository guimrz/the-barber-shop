using BarberShop.Core.Repository;

namespace BarberShop.Services.Catalog.Domain
{
    public class Product : EntityBase<Guid>
    {
        public string Name { get; }

        public string? Description { get; }

        public Product(string name, string? description = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }

    }
}
