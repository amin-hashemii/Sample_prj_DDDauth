using MyPrj.Domain.Common;

namespace MyPrj.Infrasructure.Event;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IEnumerable<IDomainEvent> events);
}