using Pure.Library;

namespace Pure.SQLiteRepository;

public interface IRepository<T>
{
    public Task<Result<List<T>,Exception>> ListAsync();
    public Task<Result<T, Exception>> GetAsync(T entity);
    public Task<Result<List<T>, Exception>> FindAsync(T entity);
    public Task<Result<T, Exception>> InsertAsync(T entity);
    public Task<List<Result<List<T>, Exception>>> InsertAsync(List<T> entities);
    public Task<Result<T,Exception>> UpdateAsync(T entity);
    public Task<Result<List<T>,Exception>> UpdateAsync(List<T> entities);
    public Task<Result<bool,Exception>> DeleteAsync(T entity);
    public Task<Result<bool,Exception>> DeleteAsync(List<T> entities);
}
