using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Pure.Library.SQLite.Extensions;

/// <summary>
/// Abstract repository base.
/// </summary>
/// <typeparam name="TContext">The <see cref="Type"/> of the <see cref="DbContext"/>.</typeparam>
/// <param name="context">The <see cref="DbContext"/>.</param>
/// <param name="logger">The <see cref="ILogger"/> instance.</param>
public abstract class RepositoryBase<TContext, TEntity>(TContext context, ILogger logger) where TContext : notnull, DbContext where TEntity : class
{
    protected readonly TContext _context = context;
    protected readonly ILogger _logger = logger;
    private bool _exists;

    public virtual Task InitAsync() { return Task.Delay(100); }
    /// <summary>
    /// Checks if the table exists in the database, creates if not and marks as present.
    /// </summary>
    /// <param name="commandText">The create command text.</param>
    /// <returns><see cref="Task"/>.</returns>
    /// <remarks>
    /// This is only run once on application startup.
    /// There is a synchronous version of this whereby you need this table created
    /// before proceeding.
    /// </remarks>
    protected async Task InitAsync(string commandText)
    {
        if (!_exists)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(commandText);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred whilst creating a table.");
            }
            _exists = true;
        }
    }

    public virtual void Init() { }
    /// <summary>
    /// Checks if the table exists in the database, creates if not and marks as present.
    /// </summary>
    /// <param name="commandText">The create command text.</param>
    /// <returns><see cref="Task"/>.</returns>
    /// <remarks>
    /// This is only run once on application startup.
    /// </remarks>
    protected void Init(string commandText)
    {
        if (!_exists && !string.IsNullOrEmpty(commandText))
        {
            try
            {
                _context.Database.ExecuteSqlRaw(commandText);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred whilst creating a table.");
            }
            _exists = true;
        }
    }

    /// <summary>
    /// Maps the data from the updated (passed) entity into the found entity.
    /// </summary>
    /// <param name="original">The original entity. Pulled from the table using the primary key.</param>
    /// <param name="updated">The updated entity. Passed for updating.</param>
    /// <remarks>
    /// This is done by ref and preserves the change tracking.
    /// </remarks>
    protected virtual void Map(ref TEntity original, TEntity updated) { }

    public abstract string CreateCommandText();
}
