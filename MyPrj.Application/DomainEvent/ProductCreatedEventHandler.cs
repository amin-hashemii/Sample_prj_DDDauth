using MediatR;
using MyPrj.Application.ViewModel;
using MyPrj.Domain.Event;

namespace MyPrj.Application.DomainEvent;

public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
{
    public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
    {
        var product = notification.Product;
        // مثلاً ارسال لاگ یا ایمیل
        Console.WriteLine($"✅ Product created: {product.Name}");

        return Task.CompletedTask;
    }
}