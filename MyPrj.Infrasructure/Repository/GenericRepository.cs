using Microsoft.EntityFrameworkCore;
using MyPrj.Domain.Interface;
using MyPrj.Domain.Models;
using MyPrj.Domain.Repository;
using MyPrj.Infrasructure.Cotext;

namespace MyPrj.Infrasructure.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsyn(T  entity)
    {
      await  _context.AddAsync(entity);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> GetByGuIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
}