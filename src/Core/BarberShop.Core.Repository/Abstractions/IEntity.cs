namespace BarberShop.Core.Repository.Abstractions
{
    public interface IEntity<TIdentifier>
    {
        TIdentifier Id { get; }
    }
}
