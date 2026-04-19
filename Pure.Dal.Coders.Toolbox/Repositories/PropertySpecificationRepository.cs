using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pure.Dal.Coders.Toolbox.Entities;
using Pure.Library;
using Pure.Library.Repository.Interfaces;
using Pure.Library.SQLite.Extensions;

namespace Pure.Dal.Coders.Toolbox.Repositories;

/// <summary>
/// Repository managing interactions with <see cref="PropertySpecification"/> entities.
/// </summary>
/// <param name="context">The typed <see cref="DbContext"/>.</param>
/// <param name="logger">An <see cref="ILogger"/> instance.</param>
/// <remarks>
/// Automatically copies inserts into the <see cref="KeyManagerRepository"/>.
/// </remarks>
public sealed class PropertySpecificationRepository(DeveloperToolboxContext context, ILogger logger) : RepositoryBase<DeveloperToolboxContext, PropertySpecification>(context, logger),
    IRepositoryRead<PropertySpecification>,
    IRepositoryDelete<PropertySpecification>,
    IRepositoryInsert<PropertySpecification>,
    IRepositoryUpdate<PropertySpecification>
{

    public override void Init() => Init(CreateCommandText());

    /// <summary>
    /// Deletes the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<bool, Exception> Delete(PropertySpecification data)
    {
        try
        {
            _context.Remove(data);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationRepository), nameof(Delete));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<bool, Exception> Delete(PropertySpecification[] data)
    {
        try
        {
            _context.RemoveRange(data);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationRepository), nameof(Delete));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<bool, Exception>> DeleteAsync(PropertySpecification data)
    {
        try
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationRepository), nameof(DeleteAsync));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<bool, Exception>> DeleteAsync(PropertySpecification[] data)
    {
        try
        {
            _context.RemoveRange(data);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationRepository), nameof(DeleteAsync));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<PropertySpecification?, Exception> Find(PropertySpecification filter)
    {
        try
        {
            PropertySpecification? data = _context.PropertySpecifications.Find(filter.Name);
            return Result<PropertySpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationRepository), nameof(Find));
            return Result<PropertySpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<PropertySpecification?, Exception>> FindAsync(PropertySpecification filter)
    {
        try
        {
            PropertySpecification? data = await _context.PropertySpecifications.FindAsync(filter.Name);
            return Result<PropertySpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationRepository), nameof(FindAsync));
            return Result<PropertySpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<PropertySpecification[], Exception> GetAll()
    {
        try
        {
            PropertySpecification[] entities = [.. _context.PropertySpecifications];
            return Result<PropertySpecification[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationRepository), nameof(GetAll));
            return Result<PropertySpecification[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<PropertySpecification[], Exception>> GetAllAsync()
    {
        try
        {
            PropertySpecification[] entities = await _context.PropertySpecifications.ToArrayAsync();
            return Result<PropertySpecification[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationRepository), nameof(GetAllAsync));
            return Result<PropertySpecification[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<PropertySpecification?, Exception> Insert(PropertySpecification data)
    {
        try
        {
            _context.PropertySpecifications.Add(data);
            _context.SaveChanges();

            return Result<PropertySpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationRepository), nameof(Insert));
            return Result<PropertySpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<PropertySpecification[]?, Exception> Insert(PropertySpecification[] data)
    {
        try
        {
            _context.PropertySpecifications.AddRangeAsync(data);
            _context.SaveChanges();

            return Result<PropertySpecification[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(PropertySpecification), nameof(InsertAsync));
            return Result<PropertySpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<PropertySpecification?, Exception>> InsertAsync(PropertySpecification data)
    {
        try
        {
            await _context.PropertySpecifications.AddAsync(data);
            await _context.SaveChangesAsync();

            return Result<PropertySpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationRepository), nameof(InsertAsync));
            return Result<PropertySpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<PropertySpecification[]?, Exception>> InsertAsync(PropertySpecification[] data)
    {
        try
        {
            await _context.PropertySpecifications.AddRangeAsync(data);
            await _context.SaveChangesAsync();

            return Result<PropertySpecification[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(PropertySpecification), nameof(InsertAsync));
            return Result<PropertySpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<PropertySpecification[]?, Exception> Search(PropertySpecification filter)
    {
        try
        {
            PropertySpecification[] entities = [.. _context.PropertySpecifications.Where(f =>
                string.IsNullOrEmpty(filter.ClassId) || (f.ClassId == filter.ClassId &&
                string.IsNullOrEmpty(filter.Name)) || (f.Name == filter.Name &&
                string.IsNullOrEmpty(filter.Type)) || f.Type == filter.Type)];

            return Result<PropertySpecification[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationRepository), nameof(Search));
            return Result<PropertySpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<PropertySpecification[]?, Exception>> SearchAsync(PropertySpecification filter)
    {
        try
        {
            PropertySpecification[] entities = await _context.PropertySpecifications.Where(f =>
                string.IsNullOrEmpty(filter.ClassId) || (f.ClassId == filter.ClassId &&
                string.IsNullOrEmpty(filter.Name)) || (f.Name == filter.Name &&
                string.IsNullOrEmpty(filter.Type)) || f.Type == filter.Type).ToArrayAsync();

            return Result<PropertySpecification[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationRepository), nameof(SearchAsync));
            return Result<PropertySpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Updates the entity, using the passed entity instance.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<PropertySpecification?, Exception> Update(PropertySpecification data)
    {
        try
        {
            PropertySpecification? entity = _context.PropertySpecifications.Find(data.Id);

            if (entity != null)
            {
                Map(ref entity, data);
                _context.SaveChanges();
            }

            return Result<PropertySpecification?, Exception>.GenerateResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationRepository), nameof(Update));
            return Result<PropertySpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Updates the entity, using the passed entity instance.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<PropertySpecification?, Exception>> UpdateAsync(PropertySpecification data)
    {
        try
        {
            PropertySpecification? entity = await _context.PropertySpecifications.FindAsync(data.Id);

            if (entity != null)
            {
                Map(ref entity, data);
                await _context.SaveChangesAsync();
            }

            return Result<PropertySpecification?, Exception>.GenerateResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(PropertySpecificationRepository), nameof(UpdateAsync));
            return Result<PropertySpecification?, Exception>.GenerateResult(ex);
        }
    }

    public override string CreateCommandText()
        => @"CREATE TABLE IF NOT EXISTS PropertySpecification (
                    Id INTEGER NOT NULL CONSTRAINT PK_PropertySpecifications PRIMARY KEY,
                    ClassId Integer NOT NULL,
                    Name TEXT NOT NULL,
                    Type TEXT NOT NULL,
                    Note TEXT)";

    protected override void Map(ref PropertySpecification original, PropertySpecification updated)
    {
        original.Name = updated.Name;
        original.ClassId = updated.ClassId;
        original.Name = updated.Name;
        original.Type = updated.Type;
    }
}
