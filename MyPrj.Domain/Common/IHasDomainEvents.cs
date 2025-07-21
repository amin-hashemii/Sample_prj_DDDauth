using MediatR;

namespace MyPrj.Domain.Common;

public interface IHasDomainEvents
{
    List<INotification> DomainEvents { get; }

    void AddDomainEvent(INotification domainEvent);
    void ClearDomainEvents();
}