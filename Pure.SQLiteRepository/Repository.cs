using Pure.Library;

namespace Pure.SQLiteRepository;

public abstract class Repository<T> : IRepository<T>
{
    public abstract Task<Result<bool, Exception>> DeleteAsync(T entity);

    public abstract Task<Result<bool, Exception>> DeleteAsync(List<T> entities);

    public abstract Task<Result<List<T>, Exception>> FindAsync(T entity);

    public abstract Task<Result<T, Exception>> GetAsync(T entity);

    public abstract Task<Result<T, Exception>> InsertAsync(T entity);

    public abstract Task<List<Result<List<T>, Exception>>> InsertAsync(List<T> entities);

    public abstract Task<Result<List<T>, Exception>> ListAsync();

    public abstract Task<Result<T, Exception>> UpdateAsync(T entity);

    public abstract Task<Result<List<T>, Exception>> UpdateAsync(List<T> entities);
}
