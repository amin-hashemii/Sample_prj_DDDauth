using MediatR;
using MyPrj.Application.Products.Command;
using MyPrj.Domain.Interface;
using MyPrj.Domain.Models;

namespace MyPrj.Application.Products.Handler;

public class AddProductCommandHandler:IRequestHandler<AddProductCommand>
{
    private readonly IunitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public AddProductCommandHandler(IunitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId ?? throw new UnauthorizedAccessException();

        var product = new product
        {
            Name = request.Name,
            Description = request.Description,
            CreatedByUserId = userId.ToString(),
        };
        await _unitOfWork.ProductRepository.AddAsyn(product);
        await _unitOfWork.SaveChangesAsync();
        return Unit.Value;
    }
}