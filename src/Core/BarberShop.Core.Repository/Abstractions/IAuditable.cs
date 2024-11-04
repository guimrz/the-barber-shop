namespace BarberShop.Core.Repository.Abstractions
{
    public interface IAuditable
    {
        DateTimeOffset CreationDate { get; }

        DateTimeOffset? UpdateDate { get; protected set; }
    }
}
