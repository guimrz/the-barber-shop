using BarberShop.Services.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberShop.Services.Catalog.Repository.Configurations
{
    public class ProductTypeEntityTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductTypes")
                .HasKey(productType => productType.Id);

            builder.Property(productType => productType.Id)
                .ValueGeneratedNever();

            builder.Property(productType => productType.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(productType => productType.Description)
                .HasMaxLength(256);

            builder.HasData(
                [                    
                    KnownProductTypes.Booking,
                    KnownProductTypes.Item,
                    KnownProductTypes.Subscription
                ]);

        }
    }
}
