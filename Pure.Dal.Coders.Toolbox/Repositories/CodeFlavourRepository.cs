using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pure.Dal.Coders.Toolbox.Entities;
using Pure.Library;
using Pure.Library.Repository.Interfaces;
using Pure.Library.SQLite.Extensions;

namespace Pure.Dal.Coders.Toolbox.Repositories;

/// <summary>
/// Repository managing interactions with <see cref="CodeFlavour"/> entities.
/// </summary>
/// <param name="context">The typed <see cref="DbContext"/>.</param>
/// <param name="keyManagerRepository">A <see cref="keyManagerRepository"/> instance.</param>
/// <param name="logger">An <see cref="ILogger"/> instance.</param>
/// <remarks>
/// Automatically copies inserts into the <see cref="KeyManagerRepository"/>.
/// </remarks>
public class CodeFlavourRepository(DeveloperToolboxContext context, ILogger logger) : RepositoryBase<DeveloperToolboxContext, CodeFlavour>(context, logger),
    IRepositoryRead<CodeFlavour>,
    IRepositoryInsert<CodeFlavour>
{


    public override void Init() => Init(CreateCommandText());

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<CodeFlavour?, Exception> Find(CodeFlavour filter)
    {
        try
        {
            CodeFlavour? data = _context.CodeFlavours.Find(filter.Name);
            return Result<CodeFlavour?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeFlavourRepository), nameof(Find));
            return Result<CodeFlavour?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<CodeFlavour?, Exception>> FindAsync(CodeFlavour filter)
    {
        try
        {
            CodeFlavour? data = await _context.CodeFlavours.FindAsync(filter.Name);
            return Result<CodeFlavour?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeFlavourRepository), nameof(FindAsync));
            return Result<CodeFlavour?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<CodeFlavour[], Exception> GetAll()
    {
        try
        {
            CodeFlavour[] entities = [.. _context.CodeFlavours];
            return Result<CodeFlavour[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeFlavourRepository), nameof(GetAll));
            return Result<CodeFlavour[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<CodeFlavour[], Exception>> GetAllAsync()
    {
        try
        {
            CodeFlavour[] entities = await _context.CodeFlavours.ToArrayAsync();
            return Result<CodeFlavour[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeFlavourRepository), nameof(GetAllAsync));
            return Result<CodeFlavour[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<CodeFlavour?, Exception> Insert(CodeFlavour data)
    {
        try
        {
            CodeFlavour? entity = _context.CodeFlavours.Find(data.Name);

            if (entity == null)
            {
                _context.CodeFlavours.Add(data);
                _context.SaveChanges();

            }
            return Result<CodeFlavour?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeFlavourRepository), nameof(Insert));
            return Result<CodeFlavour?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<CodeFlavour[]?, Exception> Insert(CodeFlavour[] data)
    {
        try
        {
            _context.CodeFlavours.AddRangeAsync(data);
            _context.SaveChanges();


            return Result<CodeFlavour[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(CodeFlavour), nameof(InsertAsync));
            return Result<CodeFlavour[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<CodeFlavour?, Exception>> InsertAsync(CodeFlavour data)
    {
        try
        {
            await _context.CodeFlavours.AddAsync(data);
            await _context.SaveChangesAsync();


            return Result<CodeFlavour?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeFlavourRepository), nameof(InsertAsync));
            return Result<CodeFlavour?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<CodeFlavour[]?, Exception>> InsertAsync(CodeFlavour[] data)
    {
        try
        {
            await _context.CodeFlavours.AddRangeAsync(data);
            await _context.SaveChangesAsync();


            return Result<CodeFlavour[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(CodeFlavour), nameof(InsertAsync));
            return Result<CodeFlavour[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<CodeFlavour[]?, Exception> Search(CodeFlavour filter)
    {
        try
        {
            CodeFlavour[] entities = [.. _context.CodeFlavours.Where(f =>
                string.IsNullOrEmpty(filter.Name) || (f.Name == filter.Name &&
                string.IsNullOrEmpty(filter.Extensions)) || f.Extensions == filter.Extensions)];

            return Result<CodeFlavour[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeFlavourRepository), nameof(Search));
            return Result<CodeFlavour[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<CodeFlavour[]?, Exception>> SearchAsync(CodeFlavour filter)
    {
        try
        {
            CodeFlavour[] entities = await _context.CodeFlavours.Where(f =>
                string.IsNullOrEmpty(filter.Name) || (f.Name == filter.Name &&
                string.IsNullOrEmpty(filter.Extensions)) || f.Extensions == filter.Extensions).ToArrayAsync();

            return Result<CodeFlavour[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeFlavourRepository), nameof(SearchAsync));
            return Result<CodeFlavour[]?, Exception>.GenerateResult(ex);
        }
    }

    public override string CreateCommandText()
        => @"CREATE TABLE IF NOT EXISTS CodeFlavour (
                        Name TEXT NOT NULL CONSTRAINT PK_CodeFlavours PRIMARY KEY,
                        Extensions TEXT NOT NULL,
                        Description TEXT NOT NULL)";
}
