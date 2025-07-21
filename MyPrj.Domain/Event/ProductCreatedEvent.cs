using MediatR;
using MyPrj.Domain.Common;
using MyPrj.Domain.Models;

namespace MyPrj.Domain.Event;

public class ProductCreatedEvent: IDomainEvent
{
    public ProductCreatedEvent(product product)
    {
        Product = product;
    }

    public product Product { get; set; }
    public DateTime OccurredOn { get; }= DateTime.UtcNow;
}