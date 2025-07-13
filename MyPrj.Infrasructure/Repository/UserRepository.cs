using Microsoft.EntityFrameworkCore;
using MyPrj.Domain.Models;
using MyPrj.Domain.Repository;
using MyPrj.Infrasructure.Cotext;

namespace MyPrj.Infrasructure.Repository;

public class UserRepository: IUserRepository
{
    
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
      return  await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}