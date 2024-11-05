namespace BarberShop.Services.Catalog.Application.Objects.Requests
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = default!;

        public string? Description { get; set; }
    }
}
