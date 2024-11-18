using BarberShop.Core.Repository;

namespace BarberShop.Services.Catalog.Domain
{
    public class Product : EntityBase<Guid>
    {
        public string Name { get; }

        public string? Description { get; }

        public decimal Price { get; }

        public Brand Brand { get; }

        public ProductType Type { get; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        protected Product() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        public Product(string name, string? description, decimal price, Brand brand, ProductType type)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentNullException.ThrowIfNull(brand);
            ArgumentNullException.ThrowIfNull(type);
            ArgumentOutOfRangeException.ThrowIfNegative(price);

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Brand = brand;
            Type = type;
        }
    }
}
