namespace OnlineVideoCourses.Data.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T?> GetByIdAsync(int id);
    IQueryable<T> GetAll();
}
