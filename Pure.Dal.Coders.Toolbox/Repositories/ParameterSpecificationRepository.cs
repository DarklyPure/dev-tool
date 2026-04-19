using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pure.Dal.Coders.Toolbox.Entities;
using Pure.Library;
using Pure.Library.Repository.Interfaces;
using Pure.Library.SQLite.Extensions;

namespace Pure.Dal.Coders.Toolbox.Repositories;

/// <summary>
/// Repository managing interactions with <see cref="ParameterSpecification"/> entities.
/// </summary>
/// <param name="context">The typed <see cref="DbContext"/>.</param>
/// <param name="keyManagerRepository">A <see cref="keyManagerRepository"/> instance.</param>
/// <param name="logger">An <see cref="ILogger"/> instance.</param>
/// <remarks>
/// Automatically copies inserts into the <see cref="KeyManagerRepository"/>.
/// </remarks>
public sealed class ParameterSpecificationRepository(DeveloperToolboxContext context, ILogger logger) : RepositoryBase<DeveloperToolboxContext, ParameterSpecification>(context, logger),
    IRepositoryRead<ParameterSpecification>,
    IRepositoryDelete<ParameterSpecification>,
    IRepositoryInsert<ParameterSpecification>,
    IRepositoryUpdate<ParameterSpecification>
{
    public override void Init() => Init(CreateCommandText());

    /// <summary>
    /// Deletes the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<bool, Exception> Delete(ParameterSpecification data)
    {
        try
        {
            _context.Remove(data);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ParameterSpecificationRepository), nameof(Delete));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<bool, Exception> Delete(ParameterSpecification[] data)
    {
        try
        {
            _context.RemoveRange(data);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ParameterSpecificationRepository), nameof(Delete));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<bool, Exception>> DeleteAsync(ParameterSpecification data)
    {
        try
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ParameterSpecificationRepository), nameof(DeleteAsync));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<bool, Exception>> DeleteAsync(ParameterSpecification[] data)
    {
        try
        {
            _context.RemoveRange(data);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ParameterSpecificationRepository), nameof(DeleteAsync));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<ParameterSpecification?, Exception> Find(ParameterSpecification filter)
    {
        try
        {
            ParameterSpecification? data = _context.ParameterSpecifications.Find(filter.Name);
            return Result<ParameterSpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ParameterSpecificationRepository), nameof(Find));
            return Result<ParameterSpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<ParameterSpecification?, Exception>> FindAsync(ParameterSpecification filter)
    {
        try
        {
            ParameterSpecification? data = await _context.ParameterSpecifications.FindAsync(filter.Name);
            return Result<ParameterSpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ParameterSpecificationRepository), nameof(FindAsync));
            return Result<ParameterSpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<ParameterSpecification[], Exception> GetAll()
    {
        try
        {
            ParameterSpecification[] entities = [.. _context.ParameterSpecifications];
            return Result<ParameterSpecification[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ParameterSpecificationRepository), nameof(GetAll));
            return Result<ParameterSpecification[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<ParameterSpecification[], Exception>> GetAllAsync()
    {
        try
        {
            ParameterSpecification[] entities = await _context.ParameterSpecifications.ToArrayAsync();
            return Result<ParameterSpecification[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ParameterSpecificationRepository), nameof(GetAllAsync));
            return Result<ParameterSpecification[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<ParameterSpecification?, Exception> Insert(ParameterSpecification data)
    {
        try
        {
            _context.ParameterSpecifications.Add(data);
            _context.SaveChanges();

            return Result<ParameterSpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ParameterSpecificationRepository), nameof(Insert));
            return Result<ParameterSpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<ParameterSpecification[]?, Exception> Insert(ParameterSpecification[] data)
    {
        try
        {
            _context.ParameterSpecifications.AddRangeAsync(data);
            _context.SaveChanges();

            return Result<ParameterSpecification[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(ParameterSpecification), nameof(InsertAsync));
            return Result<ParameterSpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<ParameterSpecification?, Exception>> InsertAsync(ParameterSpecification data)
    {
        try
        {
            await _context.ParameterSpecifications.AddAsync(data);
            await _context.SaveChangesAsync();

            return Result<ParameterSpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ParameterSpecificationRepository), nameof(InsertAsync));
            return Result<ParameterSpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<ParameterSpecification[]?, Exception>> InsertAsync(ParameterSpecification[] data)
    {
        try
        {
            await _context.ParameterSpecifications.AddRangeAsync(data);
            await _context.SaveChangesAsync();

            return Result<ParameterSpecification[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(ParameterSpecification), nameof(InsertAsync));
            return Result<ParameterSpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<ParameterSpecification[]?, Exception> Search(ParameterSpecification filter)
    {
        try
        {
            ParameterSpecification[] entities = [.. _context.ParameterSpecifications.Where(f =>
                string.IsNullOrEmpty(filter.MethodId) || (f.MethodId == filter.MethodId &&
                string.IsNullOrEmpty(filter.Name)) || (f.Name == filter.Name &&
                string.IsNullOrEmpty(filter.Type)) || f.Type == filter.Type)];

            return Result<ParameterSpecification[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ParameterSpecificationRepository), nameof(Search));
            return Result<ParameterSpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<ParameterSpecification[]?, Exception>> SearchAsync(ParameterSpecification filter)
    {
        try
        {
            ParameterSpecification[] entities = await _context.ParameterSpecifications.Where(f =>
                string.IsNullOrEmpty(filter.MethodId) || (f.MethodId == filter.MethodId &&
                string.IsNullOrEmpty(filter.Name)) || (f.Name == filter.Name &&
                string.IsNullOrEmpty(filter.Type)) || f.Type == filter.Type).ToArrayAsync();

            return Result<ParameterSpecification[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ParameterSpecificationRepository), nameof(SearchAsync));
            return Result<ParameterSpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Updates the entity, using the passed entity instance.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<ParameterSpecification?, Exception> Update(ParameterSpecification data)
    {
        try
        {
            ParameterSpecification? entity = _context.ParameterSpecifications.Find(data.Id);

            if (entity != null)
            {
                Map(ref entity, data);
                _context.SaveChanges();
            }

            return Result<ParameterSpecification?, Exception>.GenerateResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ParameterSpecificationRepository), nameof(Update));
            return Result<ParameterSpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Updates the entity, using the passed entity instance.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<ParameterSpecification?, Exception>> UpdateAsync(ParameterSpecification data)
    {
        try
        {
            ParameterSpecification? entity = await _context.ParameterSpecifications.FindAsync(data.Id);

            if (entity != null)
            {
                Map(ref entity, data);
                await _context.SaveChangesAsync();
            }

            return Result<ParameterSpecification?, Exception>.GenerateResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ParameterSpecificationRepository), nameof(UpdateAsync));
            return Result<ParameterSpecification?, Exception>.GenerateResult(ex);
        }
    }
    public override string CreateCommandText()
        => @"CREATE TABLE IF NOT EXISTS ParameterSpecification (
                    Id INTEGER NOT NULL CONSTRAINT PK_ParameterSpecifications PRIMARY KEY,
                    ClassId INTEGER NOT NULL,
                    MethodId INTEGER NOT NULL,
                    Name TEXT NOT NULL,
                    Type TEXT NOT NULL,
                    ByRef INTEGER NOT NULL,
                    Note TEXT)";
    protected override void Map(ref ParameterSpecification original, ParameterSpecification updated)
    {
        original.Name = updated.Name;
        original.MethodId = updated.MethodId;
        original.Name = updated.Name;
        original.Type = updated.Type;
        original.ByRef = updated.ByRef;
    }
}
