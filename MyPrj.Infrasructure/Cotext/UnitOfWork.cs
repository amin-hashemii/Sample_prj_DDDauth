using MyPrj.Domain.Interface;
using MyPrj.Domain.Models;
using MyPrj.Domain.Repository;
using MyPrj.Infrasructure.Repository;

namespace MyPrj.Infrasructure.Cotext;

public class UnitOfWork:IunitOfWork
{
    
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        GenericRepository = new GenericRepository<User >(_context);
        ProductRepository = new GenericRepository<product>(_context);
    }


    public IGenericRepository<User> GenericRepository { get; }
    public IGenericRepository<product> ProductRepository { get; }

    public async Task<int> SaveChangesAsync()
    {
     return await _context.SaveChangesAsync();
    }
}