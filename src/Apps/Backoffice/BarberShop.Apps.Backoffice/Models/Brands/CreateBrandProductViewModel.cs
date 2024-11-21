using BarberShop.Apps.Backoffice.Models.ProductTypes;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.Apps.Backoffice.Models.Brands
{
    public class CreateBrandProductViewModel
    {
        public IEnumerable<ProductTypeViewModel> ProductTypes { get; set; } = default!;

        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        public string ProductName { get; set; } = default!;

        public string? ProductDescription { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public Guid BrandId { get; set; }

        [Required]
        public int ProductTypeId { get; set; }
    }
}
