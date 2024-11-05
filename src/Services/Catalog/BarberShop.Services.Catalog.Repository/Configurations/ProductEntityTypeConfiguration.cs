using BarberShop.Services.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberShop.Services.Catalog.Repository.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(product => product.Id);

            builder.Property(product => product.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(product => product.Description);

        }
    }
}