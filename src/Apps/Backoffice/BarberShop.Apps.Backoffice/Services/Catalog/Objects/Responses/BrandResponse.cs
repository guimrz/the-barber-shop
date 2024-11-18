namespace BarberShop.Apps.Backoffice.Services.Catalog.Objects.Responses
{
    public class BrandResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string? Description { get; set; }
    }
}
