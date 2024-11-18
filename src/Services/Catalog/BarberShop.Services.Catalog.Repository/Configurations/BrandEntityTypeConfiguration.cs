using BarberShop.Services.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberShop.Services.Catalog.Repository.Configurations
{
    public class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands")
                .HasKey(brand => brand.Id);

            builder.Property(brand => brand.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(brand => brand.Description);
        }
    }
}
