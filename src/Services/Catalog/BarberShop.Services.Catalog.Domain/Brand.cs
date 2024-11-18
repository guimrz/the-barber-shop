using BarberShop.Core.Repository;

namespace BarberShop.Services.Catalog.Domain
{
    public class Brand : EntityBase<Guid>
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public Brand(string name, string? description)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }
    }
}
