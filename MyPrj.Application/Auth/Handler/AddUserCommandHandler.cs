using MediatR;
using MyPrj.Application.Auth.Command;
using MyPrj.Application.Auth.PasswordHash;
using MyPrj.Domain.Interface;
using MyPrj.Domain.Models;
using MyPrj.Domain.Repository;

namespace MyPrj.Application.Auth.Handler;

public class AddUserCommandHandler:IRequestHandler<AddUserCommand>
{
    
   private readonly IunitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    

    public AddUserCommandHandler( IunitOfWork unitOfWork, IPasswordHasher passwordHasher, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
    }


    public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var usergmail = await _userRepository.GetUserByEmail(request.Gmail);
        if (usergmail != null)
        {
            throw new Exception("User already exists");
        }
        var hashedPassword = _passwordHasher.HashPassword(request.Password);

        var newuser = new User()
        {
            Email = request.Gmail,
            Password = hashedPassword
        };
        await _unitOfWork.GenericRepository.AddAsyn(newuser);
        await _unitOfWork.SaveChangesAsync();
        return Unit.Value;
        
    }
}