namespace BarberShop.Apps.Backoffice.Services.Catalog.Objects.Request
{
    public class CreateBrandRequest
    {
        public string Name { get; set; } = default!;

        public string? Description { get; set; } = default!;
    }
}
