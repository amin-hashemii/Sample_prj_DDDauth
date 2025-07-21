using AutoMapper;
using MediatR;
using MyPrj.Application.Products.Command;
using MyPrj.Application.ViewModel;
using MyPrj.Domain.Factories;
using MyPrj.Domain.Interface;
using MyPrj.Domain.Models;

namespace MyPrj.Application.Products.Handler;

public class AddProductCommandHandler:IRequestHandler<AddProductCommand>
{
    private readonly IunitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public AddProductCommandHandler(IunitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId ?? throw new UnauthorizedAccessException();

        var product = ProductFactory.Create(request.Name, request.Description, userId.ToString());

        product.SetCreatedBy(userId.ToString());

        await _unitOfWork.ProductRepository.AddAsyn(product);
        await _unitOfWork.SaveChangesAsync();
    
        return Unit.Value;
    }
}