using MediatR;

namespace Polaris.VE.Domain.SeedWork;

public abstract class AggregateRoot : Entity, IAggregateRoot
{
    public IEnumerable<INotification> DomainEvents => _domainEvents;

    private readonly List<INotification> _domainEvents = new List<INotification>();

    protected void AddEvent(INotification domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearEvents()
    {
        _domainEvents.Clear();
    }
}