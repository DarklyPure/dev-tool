using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pure.Dal.Coders.Toolbox.Entities;
using Pure.Library;
using Pure.Library.Repository.Interfaces;
using Pure.Library.SQLite.Extensions;

namespace Pure.Dal.Coders.Toolbox.Repositories;

/// <summary>
/// Repository managing interactions with <see cref="PropertySpecificationCodeImplementation"/> entities.
/// </summary>
/// <param name="context">The typed <see cref="DbContext"/>.</param>
/// <param name="logger">An <see cref="ILogger"/> instance.</param>
/// <remarks>
/// Automatically copies inserts into the <see cref="KeyManagerRepository"/>.
/// </remarks>
public sealed class PropertySpecificationCodeImplementationRepository(DeveloperToolboxContext context, ILogger logger) : RepositoryBase<DeveloperToolboxContext, PropertySpecificationCodeImplementation>(context, logger),
    IRepositoryRead<PropertySpecificationCodeImplementation>,
    IRepositoryDelete<PropertySpecificationCodeImplementation>,
    IRepositoryInsert<PropertySpecificationCodeImplementation>
{

    public override void Init() => Init(CreateCommandText());

    /// <summary>
    /// Deletes the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<bool, Exception> Delete(PropertySpecificationCodeImplementation data)
    {
        try
        {
            _context.Remove(data);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationCodeImplementationRepository), nameof(Delete));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<bool, Exception> Delete(PropertySpecificationCodeImplementation[] data)
    {
        try
        {
            _context.RemoveRange(data);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationCodeImplementationRepository), nameof(Delete));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<bool, Exception>> DeleteAsync(PropertySpecificationCodeImplementation data)
    {
        try
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationCodeImplementationRepository), nameof(DeleteAsync));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<bool, Exception>> DeleteAsync(PropertySpecificationCodeImplementation[] data)
    {
        try
        {
            _context.RemoveRange(data);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationCodeImplementationRepository), nameof(DeleteAsync));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<PropertySpecificationCodeImplementation?, Exception> Find(PropertySpecificationCodeImplementation filter)
    {
        try
        {
            PropertySpecificationCodeImplementation? data = _context.PropertySpecificationCodeImplementations.Find(filter.Id);
            return Result<PropertySpecificationCodeImplementation?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationCodeImplementationRepository), nameof(Find));
            return Result<PropertySpecificationCodeImplementation?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<PropertySpecificationCodeImplementation?, Exception>> FindAsync(PropertySpecificationCodeImplementation filter)
    {
        try
        {
            PropertySpecificationCodeImplementation? data = await _context.PropertySpecificationCodeImplementations.FindAsync(filter.Id);
            return Result<PropertySpecificationCodeImplementation?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationCodeImplementationRepository), nameof(FindAsync));
            return Result<PropertySpecificationCodeImplementation?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<PropertySpecificationCodeImplementation[], Exception> GetAll()
    {
        try
        {
            PropertySpecificationCodeImplementation[] entities = [.. _context.PropertySpecificationCodeImplementations];
            return Result<PropertySpecificationCodeImplementation[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationCodeImplementationRepository), nameof(GetAll));
            return Result<PropertySpecificationCodeImplementation[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<PropertySpecificationCodeImplementation[], Exception>> GetAllAsync()
    {
        try
        {
            PropertySpecificationCodeImplementation[] entities = await _context.PropertySpecificationCodeImplementations.ToArrayAsync();
            return Result<PropertySpecificationCodeImplementation[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationCodeImplementationRepository), nameof(GetAllAsync));
            return Result<PropertySpecificationCodeImplementation[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<PropertySpecificationCodeImplementation?, Exception> Insert(PropertySpecificationCodeImplementation data)
    {
        try
        {
            _context.PropertySpecificationCodeImplementations.Add(data);
            _context.SaveChanges();

            return Result<PropertySpecificationCodeImplementation?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationCodeImplementationRepository), nameof(Insert));
            return Result<PropertySpecificationCodeImplementation?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<PropertySpecificationCodeImplementation[]?, Exception> Insert(PropertySpecificationCodeImplementation[] data)
    {
        try
        {
            _context.PropertySpecificationCodeImplementations.AddRangeAsync(data);
            _context.SaveChanges();

            return Result<PropertySpecificationCodeImplementation[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(PropertySpecificationCodeImplementation), nameof(InsertAsync));
            return Result<PropertySpecificationCodeImplementation[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<PropertySpecificationCodeImplementation?, Exception>> InsertAsync(PropertySpecificationCodeImplementation data)
    {
        try
        {
            await _context.PropertySpecificationCodeImplementations.AddAsync(data);
            await _context.SaveChangesAsync();

            return Result<PropertySpecificationCodeImplementation?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationCodeImplementationRepository), nameof(InsertAsync));
            return Result<PropertySpecificationCodeImplementation?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<PropertySpecificationCodeImplementation[]?, Exception>> InsertAsync(PropertySpecificationCodeImplementation[] data)
    {
        try
        {
            await _context.PropertySpecificationCodeImplementations.AddRangeAsync(data);
            await _context.SaveChangesAsync();

            return Result<PropertySpecificationCodeImplementation[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(PropertySpecificationCodeImplementation), nameof(InsertAsync));
            return Result<PropertySpecificationCodeImplementation[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<PropertySpecificationCodeImplementation[]?, Exception> Search(PropertySpecificationCodeImplementation filter)
    {
        try
        {
            PropertySpecificationCodeImplementation[] entities = [.. _context.PropertySpecificationCodeImplementations.Where(f =>
                string.IsNullOrEmpty(filter.PropertySpecificationId) || (f.PropertySpecificationId == filter.PropertySpecificationId &&
                string.IsNullOrEmpty(filter.Language)) || (f.Language == filter.Language &&
                string.IsNullOrEmpty(filter.ImplementationType)) || (f.ImplementationType == filter.ImplementationType &&
                f.Lock == filter.Lock))];

            return Result<PropertySpecificationCodeImplementation[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationCodeImplementationRepository), nameof(Search));
            return Result<PropertySpecificationCodeImplementation[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<PropertySpecificationCodeImplementation[]?, Exception>> SearchAsync(PropertySpecificationCodeImplementation filter)
    {
        try
        {
            PropertySpecificationCodeImplementation[] entities = await _context.PropertySpecificationCodeImplementations.Where(f =>
                string.IsNullOrEmpty(filter.PropertySpecificationId) || (f.PropertySpecificationId == filter.PropertySpecificationId &&
                string.IsNullOrEmpty(filter.Language)) || (f.Language == filter.Language &&
                string.IsNullOrEmpty(filter.ImplementationType)) || (f.ImplementationType == filter.ImplementationType &&
                f.Lock == filter.Lock)).ToArrayAsync();

            return Result<PropertySpecificationCodeImplementation[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationCodeImplementationRepository), nameof(SearchAsync));
            return Result<PropertySpecificationCodeImplementation[]?, Exception>.GenerateResult(ex);
        }
    }

    public override string CreateCommandText()
        => @"CREATE TABLE IF NOT EXISTS PropertySpecificationCodeImplementation (
                    Id INTEGER NOT NULL CONSTRAINT PK_PropertySpecificationCodeImplementations PRIMARY KEY,
                    ClassId Integer NOT NULL,
                    Name TEXT NOT NULL,
                    Type TEXT NOT NULL,
                    Note TEXT)";
}
