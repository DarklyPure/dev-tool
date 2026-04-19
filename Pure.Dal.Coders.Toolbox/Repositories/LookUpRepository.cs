using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pure.Dal.Coders.Toolbox.Entities;
using Pure.Library;
using Pure.Library.Repository.Interfaces;
using Pure.Library.SQLite.Extensions;

namespace Pure.Dal.Coders.Toolbox.Repositories;

/// <summary>
/// Repository managing interactions with <see cref="LookUp"/> entities.
/// </summary>
/// <param name="context">The typed <see cref="DbContext"/>.</param>
/// <param name="keyManagerRepository">A <see cref="keyManagerRepository"/> instance.</param>
/// <param name="logger">An <see cref="ILogger"/> instance.</param>
/// <remarks>
/// Automatically copies inserts into the <see cref="KeyManagerRepository"/>.
/// </remarks>
public class LookUpRepository(DeveloperToolboxContext context, ILogger logger) : RepositoryBase<DeveloperToolboxContext, LookUp>(context, logger),
    IRepositoryRead<LookUp>,
    IRepositoryInsert<LookUp>
{
    public override void Init() => Init(CreateCommandText());

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<LookUp?, Exception> Find(LookUp filter)
    {
        try
        {
            LookUp? data = _context.LookUps.Find(filter.Name);
            return Result<LookUp?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(LookUpRepository), nameof(Find));
            return Result<LookUp?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<LookUp?, Exception>> FindAsync(LookUp filter)
    {
        try
        {
            LookUp? data = await _context.LookUps.FindAsync(filter.Name);
            return Result<LookUp?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(LookUpRepository), nameof(FindAsync));
            return Result<LookUp?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<LookUp[], Exception> GetAll()
    {
        try
        {
            LookUp[] entities = [.. _context.LookUps];
            return Result<LookUp[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(LookUpRepository), nameof(GetAll));
            return Result<LookUp[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<LookUp[], Exception>> GetAllAsync()
    {
        try
        {
            LookUp[] entities = await _context.LookUps.ToArrayAsync();
            return Result<LookUp[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(LookUpRepository), nameof(GetAllAsync));
            return Result<LookUp[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<LookUp?, Exception> Insert(LookUp data)
    {
        try
        {
            _context.LookUps.Add(data);
            _context.SaveChanges();

            return Result<LookUp?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(LookUpRepository), nameof(Insert));
            return Result<LookUp?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<LookUp[]?, Exception> Insert(LookUp[] data)
    {
        try
        {
            _context.LookUps.AddRangeAsync(data);
            _context.SaveChanges();

            return Result<LookUp[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(LookUp), nameof(InsertAsync));
            return Result<LookUp[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<LookUp?, Exception>> InsertAsync(LookUp data)
    {
        try
        {
            await _context.LookUps.AddAsync(data);
            await _context.SaveChangesAsync();

            return Result<LookUp?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(LookUpRepository), nameof(InsertAsync));
            return Result<LookUp?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<LookUp[]?, Exception>> InsertAsync(LookUp[] data)
    {
        try
        {
            await _context.LookUps.AddRangeAsync(data);
            await _context.SaveChangesAsync();

            return Result<LookUp[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(LookUp), nameof(InsertAsync));
            return Result<LookUp[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<LookUp[]?, Exception> Search(LookUp filter)
    {
        try
        {
            LookUp[] entities = [.. _context.LookUps.Where(f =>
                filter.ParentId>-1 || (f.ParentId == filter.Id &&
                string.IsNullOrEmpty(filter.Name)) || (f.Name == filter.Name &&
                string.IsNullOrEmpty(filter.Value)) || (f.Value == filter.Value &&
                string.IsNullOrEmpty(filter.Text)) || f.Text == filter.Text)];

            return Result<LookUp[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(LookUpRepository), nameof(Search));
            return Result<LookUp[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<LookUp[]?, Exception>> SearchAsync(LookUp filter)
    {
        try
        {
            LookUp[] entities = await _context.LookUps.Where(f =>
                filter.ParentId > -1 || (f.ParentId == filter.Id &&
                string.IsNullOrEmpty(filter.Name)) || (f.Name == filter.Name &&
                string.IsNullOrEmpty(filter.Value)) || (f.Value == filter.Value &&
                string.IsNullOrEmpty(filter.Text)) || f.Text == filter.Text).ToArrayAsync();

            return Result<LookUp[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(LookUpRepository), nameof(SearchAsync));
            return Result<LookUp[]?, Exception>.GenerateResult(ex);
        }
    }
    public override string CreateCommandText()
        => @"CREATE TABLE IF NOT EXISTS LookUp (
                        Id INTEGER NOT NULL CONSTRAINT PK_LookUps PRIMARY KEY,
                        ParentId INTEGER NOT NULL,
                        Name TEXT NOT NULL,
                        Value TEXT NULL,
                        Text TEXT NOT NULL,
                        Note TEXT NULL,
                        Archive INTEGER NOT NULL)";
}
