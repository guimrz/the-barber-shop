using System.ComponentModel.DataAnnotations;

namespace BarberShop.Apps.Backoffice.Models.Brands
{
    public class CreateBrandViewModel
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; } = default!;

        public string? Description { get; set; }
    }
}
