namespace BarberShop.Apps.Backoffice.Services.Catalog.Objects.Responses
{
    public class ProductTypeResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string? Description { get; set; }
    }
}
