using MediatR;

namespace MyPrj.Application.Products.Command;

public class AddProductCommand:IRequest
{
    
    public string Name { get; set; }
    public string Description { get; set; }
    
    
}