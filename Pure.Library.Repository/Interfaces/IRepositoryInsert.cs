namespace Pure.Library.Repository.Interfaces;

/// <summary>
/// Interface containing Repository insert functionality..
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
public interface IRepositoryInsert<T>
{
    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Task<Result<T?, Exception>> InsertAsync(T data);

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Task<Result<T[]?, Exception>> InsertAsync(T[] data);

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<T?, Exception> Insert(T data);

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<T[]?, Exception> Insert(T[] data);
}
