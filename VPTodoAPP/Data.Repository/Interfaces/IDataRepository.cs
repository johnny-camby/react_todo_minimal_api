namespace Data.Repository.Interfaces;

public interface IDataRepository
{}

public interface IDataRepository<T> : IDataRepository
   where T : class, new()
{ 
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> GetAsync();
    Task<T> GetAsync(int id);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<bool> IsExistingAsync(int id);
    Task<bool> SaveAsync();
}
