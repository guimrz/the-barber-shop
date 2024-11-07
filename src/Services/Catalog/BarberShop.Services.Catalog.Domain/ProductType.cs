using BarberShop.Core.Repository;

namespace BarberShop.Services.Catalog.Domain
{
    public class ProductType : EntityBase<int>
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public ProductType(int id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
