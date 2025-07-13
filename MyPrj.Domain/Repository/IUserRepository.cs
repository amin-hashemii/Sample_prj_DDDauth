using MyPrj.Domain.Models;

namespace MyPrj.Domain.Repository;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
}