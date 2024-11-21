namespace BarberShop.Apps.Backoffice.Models.ProductTypes
{
    public class ProductTypeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string? Description { get; set; }
    }
}
