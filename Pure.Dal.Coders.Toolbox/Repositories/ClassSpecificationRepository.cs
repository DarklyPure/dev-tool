using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pure.Dal.Coders.Toolbox.Entities;
using Pure.Library;
using Pure.Library.Repository.Interfaces;
using Pure.Library.SQLite.Extensions;

namespace Pure.Dal.Coders.Toolbox.Repositories;

/// <summary>
/// Repository managing interactions with <see cref="ClassSpecification"/> entities.
/// </summary>
/// <param name="context">The typed <see cref="DbContext"/>.</param>
/// <param name="keyManagerRepository">A <see cref="keyManagerRepository"/> instance.</param>
/// <param name="logger">An <see cref="ILogger"/> instance.</param>
/// <remarks>
/// Automatically copies inserts into the <see cref="KeyManagerRepository"/>.
/// </remarks>
public sealed class ClassSpecificationRepository(DeveloperToolboxContext context, ILogger logger) : RepositoryBase<DeveloperToolboxContext, ClassSpecification>(context, logger),
    IRepositoryRead<ClassSpecification>,
    IRepositoryDelete<ClassSpecification>,
    IRepositoryInsert<ClassSpecification>,
    IRepositoryUpdate<ClassSpecification>
{

    /// <summary>
    /// Deletes the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<bool, Exception> Delete(ClassSpecification data)
    {
        try
        {
            _context.Remove(data);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ClassSpecificationRepository), nameof(Delete));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<bool, Exception> Delete(ClassSpecification[] data)
    {
        try
        {
            _context.RemoveRange(data);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ClassSpecificationRepository), nameof(Delete));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<bool, Exception>> DeleteAsync(ClassSpecification data)
    {
        try
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ClassSpecificationRepository), nameof(DeleteAsync));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<bool, Exception>> DeleteAsync(ClassSpecification[] data)
    {
        try
        {
            _context.RemoveRange(data);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ClassSpecificationRepository), nameof(DeleteAsync));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<ClassSpecification?, Exception> Find(ClassSpecification filter)
    {
        try
        {
            ClassSpecification? data = _context.ClassSpecifications.Find(filter.Id);
            return Result<ClassSpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ClassSpecificationRepository), nameof(Find));
            return Result<ClassSpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<ClassSpecification?, Exception>> FindAsync(ClassSpecification filter)
    {
        try
        {
            ClassSpecification? data = await _context.ClassSpecifications.FindAsync(filter.Id);
            return Result<ClassSpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ClassSpecificationRepository), nameof(FindAsync));
            return Result<ClassSpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<ClassSpecification[], Exception> GetAll()
    {
        try
        {
            ClassSpecification[] entities = [.. _context.ClassSpecifications];
            return Result<ClassSpecification[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ClassSpecificationRepository), nameof(GetAll));
            return Result<ClassSpecification[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<ClassSpecification[], Exception>> GetAllAsync()
    {
        try
        {
            ClassSpecification[] entities = await _context.ClassSpecifications.ToArrayAsync();
            return Result<ClassSpecification[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ClassSpecificationRepository), nameof(GetAllAsync));
            return Result<ClassSpecification[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<ClassSpecification?, Exception> Insert(ClassSpecification data)
    {
        try
        {
            _context.ClassSpecifications.Add(data);
            _context.SaveChanges();


            return Result<ClassSpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ClassSpecificationRepository), nameof(Insert));
            return Result<ClassSpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<ClassSpecification[]?, Exception> Insert(ClassSpecification[] data)
    {
        try
        {
            _context.ClassSpecifications.AddRangeAsync(data);
            _context.SaveChanges();


            return Result<ClassSpecification[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(ClassSpecification), nameof(InsertAsync));
            return Result<ClassSpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<ClassSpecification?, Exception>> InsertAsync(ClassSpecification data)
    {
        try
        {
            await _context.ClassSpecifications.AddAsync(data);
            await _context.SaveChangesAsync();


            return Result<ClassSpecification?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ClassSpecificationRepository), nameof(InsertAsync));
            return Result<ClassSpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<ClassSpecification[]?, Exception>> InsertAsync(ClassSpecification[] data)
    {
        try
        {
            await _context.ClassSpecifications.AddRangeAsync(data);
            await _context.SaveChangesAsync();


            return Result<ClassSpecification[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(ClassSpecification), nameof(InsertAsync));
            return Result<ClassSpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<ClassSpecification[]?, Exception> Search(ClassSpecification filter)
    {
        try
        {
            ClassSpecification[] entities = [.. _context.ClassSpecifications.Where(f =>
                string.IsNullOrEmpty(filter.Name) || (f.Name == filter.Name &&
                string.IsNullOrEmpty(filter.Modifier)) || f.Modifier == filter.Modifier)];

            return Result<ClassSpecification[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ClassSpecificationRepository), nameof(Search));
            return Result<ClassSpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<ClassSpecification[]?, Exception>> SearchAsync(ClassSpecification filter)
    {
        try
        {
            ClassSpecification[] entities = await _context.ClassSpecifications.Where(f =>
                string.IsNullOrEmpty(filter.Name) || (f.Name == filter.Name &&
                string.IsNullOrEmpty(filter.Modifier)) || f.Modifier == filter.Modifier).ToArrayAsync();

            return Result<ClassSpecification[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ClassSpecificationRepository), nameof(SearchAsync));
            return Result<ClassSpecification[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Updates the entity, using the passed entity instance.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<ClassSpecification?, Exception> Update(ClassSpecification data)
    {
        try
        {
            ClassSpecification? entity = _context.ClassSpecifications.Find(data.Id);

            if (entity != null)
            {
                Map(ref entity, data);
                _context.SaveChanges();
            }

            return Result<ClassSpecification?, Exception>.GenerateResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ClassSpecificationRepository), nameof(Update));
            return Result<ClassSpecification?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Updates the entity, using the passed entity instance.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<ClassSpecification?, Exception>> UpdateAsync(ClassSpecification data)
    {
        try
        {
            ClassSpecification? entity = await _context.ClassSpecifications.FindAsync(data.Id);

            if (entity != null)
            {
                Map(ref entity, data);
                await _context.SaveChangesAsync();
            }

            return Result<ClassSpecification?, Exception>.GenerateResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(ClassSpecificationRepository), nameof(UpdateAsync));
            return Result<ClassSpecification?, Exception>.GenerateResult(ex);
        }
    }

    public override void Init() => base.Init(CreateCommandText());

    public override string CreateCommandText()
        => @"CREATE TABLE IF NOT EXISTS ClassSpecification (
                    Id INTEGER NOT NULL CONSTRAINT PK_ClassSpecifications PRIMARY KEY,
                    Name TEXT NOT NULL,
                    Modifier TEXT NOT NULL,
                    Note TEXT)";

    protected override void Map(ref ClassSpecification original, ClassSpecification updated)
    {
        original.Name = updated.Name;
        original.Modifier = updated.Modifier;
    }
}
