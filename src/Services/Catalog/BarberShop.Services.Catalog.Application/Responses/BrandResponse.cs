namespace BarberShop.Services.Catalog.Application.Responses
{
    public record BrandResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string? Description { get; set; }
    }
}
