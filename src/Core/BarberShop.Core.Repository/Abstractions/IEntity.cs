namespace BarberShop.Core.Repository.Abstractions
{
    public interface IEntity
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        void AddDomainEvent(IDomainEvent domainEvent);

        bool RemoveDomainEvent(IDomainEvent domainEvent);

        void ClearDomainEvents();
    }

    public interface IEntity<TIdentifier>
        where TIdentifier : struct
    {
        TIdentifier Id { get; }
    }
}
