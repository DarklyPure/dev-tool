namespace Pure.Library.Coders.Toolbox.DAL.Interfaces;

/// <summary>
/// Interface for a Data Access Layer class.
/// </summary>
/// <typeparam name="TEntity">The entity.</typeparam>
public interface ICoreDal<TEntity> where TEntity : class, new()
{
    /// <summary>
    /// Gets the entity specified.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/>.</returns>
    public Task<Result<TEntity, Exception>> GetAsync(TEntity entity);

    /// <summary>
    /// Finds all entities matching the passed entity state.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/>.</returns>
    public Task<Result<List<TEntity>, Exception>> FindAsync(TEntity entity);

    /// <summary>
    /// Gets all entities from the store specified.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/>.</returns>
    public Task<Result<List<TEntity>, Exception>> AllAsync();

    /// <summary>
    /// Inserts or Updates the store using the entity passed.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/>.</returns>
    public Task<Result<TEntity, Exception>> UpsertAsync(TEntity entity);

    /// <summary>
    /// Deletes the passed entity from the store.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/>.</returns>
    public Task<Result<bool, Exception>> DeleteAsync(TEntity entity);

    /// <summary>
    /// Deletes all of the passed entities from the store.
    /// </summary>
    /// <param name="entities">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/>.</returns>
    public Task<Result<bool, Exception>> DeleteRangeAsync(TEntity[] entities);
}
