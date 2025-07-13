using MediatR;
using MyPrj.Domain.Models;

namespace MyPrj.Application.Products.Query;

public class GetProductByIdQuery:IRequest<product>
{
    public int ProductId { get; set; }
}