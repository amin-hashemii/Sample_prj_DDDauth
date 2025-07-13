namespace MyPrj.Domain.Repository;

public interface IGenericRepository<T> where T : class
{
    
    Task AddAsyn(T entity);
    Task<T> GetByIdAsync(int id);
    Task<T> GetByGuIdAsync(Guid id);
    
    Task<List<T>> GetAllAsync();
}