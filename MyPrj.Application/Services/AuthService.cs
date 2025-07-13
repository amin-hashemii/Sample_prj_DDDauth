using MyPrj.Domain.Interface;
using MyPrj.Domain.Models;
using MyPrj.Domain.Repository;

namespace MyPrj.Application.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;
   private readonly IunitOfWork _unitOfWork;
    private readonly  IJwtService _jwtService;

    public AuthService( IJwtService jwtService, IUserRepository userRepository, IunitOfWork unitOfWork)
    {
     
        _jwtService = jwtService;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetUserByEmail(email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            throw new UnauthorizedAccessException("Invalid credentials");

        return _jwtService.GenerateToken(user);
    }

    public async Task RegisterAsync(string email, string password)
    {
        var user = await _userRepository.GetUserByEmail(email);
        if (user != null)
            throw new Exception("email already exists");

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

        var newuser = new User
        {
            Email = email,
            Password = passwordHash,
        };

        _unitOfWork.GenericRepository.AddAsyn(newuser);
         
    }

}
