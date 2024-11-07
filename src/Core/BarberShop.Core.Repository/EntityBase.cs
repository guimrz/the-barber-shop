using BarberShop.Core.Repository.Abstractions;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Core.Repository
{
    public abstract class EntityBase<TIdentifier> : IEntity<TIdentifier>
        where TIdentifier : struct
    {
        private readonly IList<INotification> _domainEvents = new List<INotification>();

        public TIdentifier Id { get; protected set; }

        [NotMapped]
        public IReadOnlyCollection<INotification> DomainEvents { get => _domainEvents.AsReadOnly(); }

        public void AddDomainEvent(INotification domainEvent)
        {
            ArgumentNullException.ThrowIfNull(domainEvent);

            _domainEvents.Add(domainEvent);
        }

        public bool RemoveDomainEvent(INotification domainEvent)
        {
            return _domainEvents.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
