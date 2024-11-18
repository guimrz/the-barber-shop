using BarberShop.Services.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberShop.Services.Catalog.Repository.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products")
                .HasKey(product => product.Id);

            builder.Property(product => product.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(product => product.Description);

            builder.Property(product => product.Price)
                .IsRequired();

            builder.HasOne(product => product.Brand)
                .WithMany()
                .HasForeignKey("BrandId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(product => product.Type)
                .WithMany()
                .HasForeignKey("ProductTypeId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}