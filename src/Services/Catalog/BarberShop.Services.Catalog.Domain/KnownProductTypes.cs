namespace BarberShop.Services.Catalog.Domain
{
    public static class KnownProductTypes
    {
        public static ProductType Item = new ProductType(1, "Item", "A physical item.");

        public static ProductType Booking = new ProductType(2, "Booking", "A booking to an execution of a service.");

        public static ProductType Subscription = new ProductType(3, "Subscription", "A subscription to a service.");
    }
}
