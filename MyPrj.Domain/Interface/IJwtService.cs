using MyPrj.Domain.Models;

namespace MyPrj.Domain.Interface;

public interface IJwtService
{
    string GenerateToken(User user);
}