namespace BarberShop.Apps.Backoffice.Models.Brands
{
    public class BrandDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string? Description { get; set; }
    }
}
