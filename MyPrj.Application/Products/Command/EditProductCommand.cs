using MediatR;

namespace MyPrj.Application.Products.Command;

public class EditProductCommand:IRequest
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
}