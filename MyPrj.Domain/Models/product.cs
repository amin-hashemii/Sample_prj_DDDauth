

using MyPrj.Domain.Event;

namespace MyPrj.Domain.Models;

public class product:BaseEntity
{
    public product(string name, string description, string createdByUserId)
    {
        
        Name = name;
        Description = description;
        CreatedByUserId = createdByUserId;
        AddDomainEvent(new ProductCreatedEvent(this));
    }

    private product()
    {
        
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string CreatedByUserId { get; private  set; }
    
    
    public void Edit(string name, string description)
    {
        // اینجا می‌تونی validation هم انجام بدی (مثلاً اطمینان از خالی نبودن name)
        Name = name;
        Description = description;
    }
    public void SetCreatedBy(string userId)
    {
        CreatedByUserId = userId;
    }
    public static product Create(string name, string description, string userId)
    {
        var product = new product(name, description, userId);

        product.AddDomainEvent(new ProductCreatedEvent(product));

        return product;
    }
}