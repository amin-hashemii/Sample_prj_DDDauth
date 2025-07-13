using MediatR;
using MyPrj.Application.Products.Command;
using MyPrj.Domain.Interface;

namespace MyPrj.Application.Products.Handler;

public class EditProductCommandHandler:IRequestHandler<EditProductCommand>
{
    private readonly IunitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;
    private readonly ICurrentUserService _currentUserService;

    public EditProductCommandHandler(ICurrentUserService currentUserService, IunitOfWork unitOfWork, IJwtService jwtService)
    {
        _currentUserService = currentUserService;
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
    }

    public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId?.ToString()
            ?? throw new UnauthorizedAccessException("کاربر لاگین نشده است");
        
           var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);
           if (product == null)
           {
               throw new Exception("Product not found");
           }
           if (product.CreatedByUserId != userId)
               throw new UnauthorizedAccessException("شما مجاز به ویرایش این محصول نیستید");

           product.Name = request.ProductName;
           product.Description = request.ProductDescription;

           await _unitOfWork.SaveChangesAsync();

           return Unit.Value;
    }
}