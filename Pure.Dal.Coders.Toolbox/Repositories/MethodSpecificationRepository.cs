using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pure.Dal.Coders.Toolbox.Entities;
using Pure.Library;
using Pure.Library.Repository.Interfaces;
using Pure.Library.SQLite.Extensions;

namespace Pure.Dal.Coders.Toolbox.Repositories;

/// <summary>
/// Repository managing interactions with <see cref="MethodSpecification"/> entities.
/// </summary>
/// <param name="context">The typed <see cref="DbContext"/>.</param>
/// <param name="keyManagerRepository">A <see cref="keyManagerRepository"/> instance.</param>
/// <param name="logger">An <see cref="ILogger"/> instance.</param>
/// <remarks>
/// Automatically copies inserts into the <see cref="KeyManagerRepository"/>.
/// </remarks>
public sealed class MethodSpecificationRepository(DeveloperToolboxContext context, ILogger logger) : RepositoryBase<DeveloperToolboxContext, MethodSpecification>(context, logger),
    IRepositoryRead<MethodSpecification>,
    IRepositoryDelete<MethodSpecification>,
    IRepositoryInsert<MethodSpecification>,
    IRepositoryUpdate<MethodSpecification>
{
    public override void Init() => Init(CreateCommandText());

    /// <summary>
    /// Deletes the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<bool, Exception> Delete(MethodSpecification data)
    {
        try
        {
            _context.Remove(data);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(MethodSpecificationRepository), nameof(Delete));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<bool, Exception> Delete(MethodSpecification[] data)
    {
        try
        {
            _context.RemoveRange(data);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(MethodSpecificationRepository), nameof(Delete));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<bool, Exception>> DeleteAsync(MethodSpecification data)
    {
        try
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(MethodSpecificationRepository), nameof(DeleteAsync));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<bool, Exception>> DeleteAsync(MethodSpecification[] data)
    {
        try
        {
            _context.RemoveRange(data);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(MethodSpecificationRepository), nameof(DeleteAsync));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<MethodSpecification?, Exception> Find(MethodSpecification filter)
    {
        try
        {
            MethodSpecification? data = _context.MethodSpecifications.Find(filter.Name);
            return Result<MethodSpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(MethodSpecificationRepository), nameof(Find));
            return Result<MethodSpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<MethodSpecification?, Exception>> FindAsync(MethodSpecification filter)
    {
        try
        {
            MethodSpecification? data = await _context.MethodSpecifications.FindAsync(filter.Name);
            return Result<MethodSpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(MethodSpecificationRepository), nameof(FindAsync));
            return Result<MethodSpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<MethodSpecification[], Exception> GetAll()
    {
        try
        {
            MethodSpecification[] entities = [.. _context.MethodSpecifications];
            return Result<MethodSpecification[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(MethodSpecificationRepository), nameof(GetAll));
            return Result<MethodSpecification[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<MethodSpecification[], Exception>> GetAllAsync()
    {
        try
        {
            MethodSpecification[] entities = await _context.MethodSpecifications.ToArrayAsync();
            return Result<MethodSpecification[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(MethodSpecificationRepository), nameof(GetAllAsync));
            return Result<MethodSpecification[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<MethodSpecification?, Exception> Insert(MethodSpecification data)
    {
        try
        {
            _context.MethodSpecifications.Add(data);
            _context.SaveChanges();

            return Result<MethodSpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(MethodSpecificationRepository), nameof(Insert));
            return Result<MethodSpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<MethodSpecification[]?, Exception> Insert(MethodSpecification[] data)
    {
        try
        {
            _context.MethodSpecifications.AddRangeAsync(data);
            _context.SaveChanges();

            return Result<MethodSpecification[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(MethodSpecification), nameof(InsertAsync));
            return Result<MethodSpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<MethodSpecification?, Exception>> InsertAsync(MethodSpecification data)
    {
        try
        {
            await _context.MethodSpecifications.AddAsync(data);
            await _context.SaveChangesAsync();

            return Result<MethodSpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(MethodSpecificationRepository), nameof(InsertAsync));
            return Result<MethodSpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<MethodSpecification[]?, Exception>> InsertAsync(MethodSpecification[] data)
    {
        try
        {
            await _context.MethodSpecifications.AddRangeAsync(data);
            await _context.SaveChangesAsync();

            return Result<MethodSpecification[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(MethodSpecification), nameof(InsertAsync));
            return Result<MethodSpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<MethodSpecification[]?, Exception> Search(MethodSpecification filter)
    {
        try
        {
            MethodSpecification[] entities = [.. _context.MethodSpecifications.Where(f =>
                string.IsNullOrEmpty(filter.ClassId) || (f.ClassId == filter.ClassId &&
                string.IsNullOrEmpty(filter.Modifier)) || (f.Modifier == filter.Modifier &&
                string.IsNullOrEmpty(filter.Name)) || (f.Name == filter.Name &&
                string.IsNullOrEmpty(filter.ReturnType)) || f.ReturnType == filter.ReturnType)];

            return Result<MethodSpecification[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(MethodSpecificationRepository), nameof(Search));
            return Result<MethodSpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<MethodSpecification[]?, Exception>> SearchAsync(MethodSpecification filter)
    {
        try
        {
            MethodSpecification[] entities = await _context.MethodSpecifications.Where(f =>
                string.IsNullOrEmpty(filter.ClassId) || (f.ClassId == filter.ClassId &&
                string.IsNullOrEmpty(filter.Modifier)) || (f.Modifier == filter.Modifier &&
                string.IsNullOrEmpty(filter.Name)) || (f.Name == filter.Name &&
                string.IsNullOrEmpty(filter.ReturnType)) || f.ReturnType == filter.ReturnType).ToArrayAsync();

            return Result<MethodSpecification[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(MethodSpecificationRepository), nameof(SearchAsync));
            return Result<MethodSpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Updates the entity, using the passed entity instance.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<MethodSpecification?, Exception> Update(MethodSpecification data)
    {
        try
        {
            MethodSpecification? entity = _context.MethodSpecifications.Find(data.Id);

            if (entity != null)
            {
                Map(ref entity, data);
                _context.SaveChanges();
            }

            return Result<MethodSpecification?, Exception>.GenerateResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(MethodSpecificationRepository), nameof(Update));
            return Result<MethodSpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Updates the entity, using the passed entity instance.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<MethodSpecification?, Exception>> UpdateAsync(MethodSpecification data)
    {
        try
        {
            MethodSpecification? entity = await _context.MethodSpecifications.FindAsync(data.Id);

            if (entity != null)
            {
                Map(ref entity, data);
                await _context.SaveChangesAsync();
            }

            return Result<MethodSpecification?, Exception>.GenerateResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(MethodSpecificationRepository), nameof(UpdateAsync));
            return Result<MethodSpecification?, Exception>.GenerateResult(ex);
        }
    }

    public override string CreateCommandText()
        => @"CREATE TABLE IF NOT EXISTS MethodSpecification (
                    Id INTEGER NOT NULL CONSTRAINT PK_MethodSpecifications PRIMARY KEY,
                    ClassId INTEGER NOT NULL,
                    Modifier TEXT NOT NULL,
                    Name TEXT NOT NULL,
                    ReturnType TEXT NOT NULL,
                    Note TEXT)";
    protected override void Map(ref MethodSpecification original, MethodSpecification updated)
    {
        original.Name = updated.Name;
        original.ClassId = updated.ClassId;
        original.Name = updated.Name;
        original.Modifier = updated.Modifier;
        original.ReturnType = updated.ReturnType;
    }
}
