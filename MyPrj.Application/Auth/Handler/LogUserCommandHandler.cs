using MediatR;
using MyPrj.Application.Auth.Command;
using MyPrj.Application.Auth.PasswordHash;
using MyPrj.Domain.Interface;
using MyPrj.Domain.Repository;

namespace MyPrj.Application.Auth.Handler;

public class LogUserCommandHandler:IRequestHandler<LogUserCommand, string>
{
    
    private readonly IUserRepository _userRepository;
    private readonly IunitOfWork _unitOfWork;
   private readonly IPasswordHasher _passwordHasher;
   private readonly IJwtService _jwtService;

    public LogUserCommandHandler(IUserRepository userRepository, IunitOfWork unitOfWork, IPasswordHasher passwordHasher, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<string> Handle(LogUserCommand request, CancellationToken cancellationToken)
    {
        var user = await  _userRepository.GetUserByEmail(request.Email);
        if (user == null || !_passwordHasher.Verify(request.Password, user.Password))
            throw new UnauthorizedAccessException("Invalid credentials");

        return _jwtService.GenerateToken(user);
    }
}