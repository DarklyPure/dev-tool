namespace Pure.Library.Repository.Interfaces;

/// <summary>
/// Interface containing Repository update functionality..
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
public interface IRepositoryUpdate<T>
{
    /// <summary>
    /// Updates the entity, using the passed entity instance.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Task<Result<T?, Exception>> UpdateAsync(T data);

    /// <summary>
    /// Updates the entity, using the passed entity instance.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<T?, Exception> Update(T data);
}
