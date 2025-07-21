using MediatR;
using MyPrj.Domain.Common;
using MyPrj.Domain.Event;

namespace MyPrj.Domain.Models;

public abstract class BaseEntity: IHasDomainEvents
{
    private List<INotification>? _domainEvents;

    public List<INotification> DomainEvents => _domainEvents ??= new List<INotification>();

    public void AddDomainEvent(INotification domainEvent)
    {
        DomainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
}