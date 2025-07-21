using MediatR;
using MyPrj.Application.Products.Query;
using MyPrj.Domain.Interface;
using MyPrj.Domain.Models;

namespace MyPrj.Application.Products.Handler;

public class GetProductByIdQueryHandler:IRequestHandler<GetProductByIdQuery, product>
{
    private readonly IunitOfWork _context;

    public GetProductByIdQueryHandler(IunitOfWork context)
    {
        _context = context;
    }

    public async Task<product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product =await _context.ProductRepository.GetByIdAsync(request.ProductId);
        if (product == null)
            throw new Exception("Product not found");

        return await _context.ProductRepository.GetByIdAsync(request.ProductId);
     //   throw new Exception("این یک خطای تستی است");
    }
}