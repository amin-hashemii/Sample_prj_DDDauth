using MediatR;

namespace MyPrj.Domain.Common;

public interface IDomainEvent: INotification
{
    DateTime OccurredOn { get; }
}