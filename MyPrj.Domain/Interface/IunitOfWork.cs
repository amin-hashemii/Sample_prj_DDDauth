using MyPrj.Domain.Models;
using MyPrj.Domain.Repository;

namespace MyPrj.Domain.Interface;

public interface IunitOfWork
{
     IGenericRepository<User> GenericRepository { get; }
     IGenericRepository<product> ProductRepository { get; }

    Task<int> SaveChangesAsync();
}