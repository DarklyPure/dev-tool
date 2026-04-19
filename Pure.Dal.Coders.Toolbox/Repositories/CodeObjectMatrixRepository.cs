using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pure.Dal.Coders.Toolbox.Entities;
using Pure.Library;
using Pure.Library.Repository.Interfaces;
using Pure.Library.SQLite.Extensions;

namespace Pure.Dal.Coders.Toolbox.Repositories;

/// <summary>
/// Repository managing interactions with <see cref="CodeObjectMatrix"/> entities.
/// </summary>
/// <param name="context">The typed <see cref="DbContext"/>.</param>
/// <param name="keyManagerRepository">A <see cref="keyManagerRepository"/> instance.</param>
/// <param name="logger">An <see cref="ILogger"/> instance.</param>
/// <remarks>
/// Automatically copies inserts into the <see cref="KeyManagerRepository"/>.
/// </remarks>
public class CodeObjectMatrixRepository(DeveloperToolboxContext context, ILogger logger) : RepositoryBase<DeveloperToolboxContext, CodeObjectMatrix>(context, logger),
    IRepositoryRead<CodeObjectMatrix>,
    IRepositoryInsert<CodeObjectMatrix>,
    IRepositoryUpdate<CodeObjectMatrix>,
    IRepositoryDelete<CodeObjectMatrix>
{

    public override void Init() => Init(CreateCommandText());
    #region Data Access

    /// <summary>
    /// Deletes the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<bool, Exception> Delete(CodeObjectMatrix data)
    {
        try
        {
            _context.Remove(data);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeObjectMatrixRepository), nameof(Delete));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<bool, Exception> Delete(CodeObjectMatrix[] data)
    {
        try
        {
            _context.RemoveRange(data);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeObjectMatrixRepository), nameof(Delete));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<bool, Exception>> DeleteAsync(CodeObjectMatrix data)
    {
        try
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeObjectMatrixRepository), nameof(DeleteAsync));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Deletes the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<bool, Exception>> DeleteAsync(CodeObjectMatrix[] data)
    {
        try
        {
            _context.RemoveRange(data);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeObjectMatrixRepository), nameof(DeleteAsync));
            return Result<bool, Exception>.GenerateResult(ex);
        }
        return Result<bool, Exception>.GenerateResult(true);
    }

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<CodeObjectMatrix?, Exception> Find(CodeObjectMatrix filter)
    {
        try
        {
            CodeObjectMatrix? data = _context.CodeObjectMatrices.Find(filter.CodeFlavour, filter.InputType, filter.CodeObject);
            return Result<CodeObjectMatrix?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeObjectMatrixRepository), nameof(Find));
            return Result<CodeObjectMatrix?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Finds the entity with the passed primary key.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<CodeObjectMatrix?, Exception>> FindAsync(CodeObjectMatrix filter)
    {
        try
        {
            CodeObjectMatrix? data = await _context.CodeObjectMatrices.FindAsync(filter.CodeFlavour, filter.InputType, filter.CodeObject);
            return Result<CodeObjectMatrix?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeObjectMatrixRepository), nameof(FindAsync));
            return Result<CodeObjectMatrix?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<CodeObjectMatrix[], Exception> GetAll()
    {
        try
        {
            CodeObjectMatrix[] entities = [.. _context.CodeObjectMatrices];
            return Result<CodeObjectMatrix[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeObjectMatrixRepository), nameof(GetAll));
            return Result<CodeObjectMatrix[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<CodeObjectMatrix[], Exception>> GetAllAsync()
    {
        try
        {
            CodeObjectMatrix[] entities = await _context.CodeObjectMatrices.ToArrayAsync();
            return Result<CodeObjectMatrix[], Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeObjectMatrixRepository), nameof(GetAllAsync));
            return Result<CodeObjectMatrix[], Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<CodeObjectMatrix?, Exception> Insert(CodeObjectMatrix data)
    {
        try
        {
            _context.CodeObjectMatrices.Add(data);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
            {
                SqliteException? innerException = (SqliteException)ex.InnerException;

                if (innerException.SqliteErrorCode != 19)
                {
                    _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeObjectMatrixRepository), nameof(Insert));
                    return Result<CodeObjectMatrix?, Exception>.GenerateResult(ex);
                }
            }
        }

        return Result<CodeObjectMatrix?, Exception>.GenerateResult(data);
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<CodeObjectMatrix[]?, Exception> Insert(CodeObjectMatrix[] data)
    {
        try
        {
            _context.CodeObjectMatrices.AddRangeAsync(data);
            _context.SaveChanges();

            return Result<CodeObjectMatrix[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(CodeObjectMatrix), nameof(InsertAsync));
            return Result<CodeObjectMatrix[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entity.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<CodeObjectMatrix?, Exception>> InsertAsync(CodeObjectMatrix data)
    {
        try
        {
            await _context.CodeObjectMatrices.AddAsync(data);
            await _context.SaveChangesAsync();

            return Result<CodeObjectMatrix?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeObjectMatrixRepository), nameof(InsertAsync));
            return Result<CodeObjectMatrix?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Inserts the passed entities.
    /// </summary>
    /// <param name="data">The entities.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<CodeObjectMatrix[]?, Exception>> InsertAsync(CodeObjectMatrix[] data)
    {
        try
        {
            await _context.CodeObjectMatrices.AddRangeAsync(data);
            await _context.SaveChangesAsync();

            return Result<CodeObjectMatrix[]?, Exception>.GenerateResult(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured at {classname} => {methodname}", nameof(CodeObjectMatrix), nameof(InsertAsync));
            return Result<CodeObjectMatrix[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<CodeObjectMatrix[]?, Exception> Search(CodeObjectMatrix filter)
    {
        try
        {
            CodeObjectMatrix[] entities = [.. _context.CodeObjectMatrices.Where(f =>
                string.IsNullOrEmpty(filter.CodeFlavour) || (f.CodeFlavour == filter.CodeFlavour &&
                string.IsNullOrEmpty(filter.InputType)) || (f.InputType == filter.InputType &&
                string.IsNullOrEmpty(filter.CodeObject)) || f.CodeObject == filter.CodeObject)];

            return Result<CodeObjectMatrix[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeObjectMatrixRepository), nameof(Search));
            return Result<CodeObjectMatrix[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Searches for entities with the passed entity's properties.
    /// </summary>
    /// <param name="filter">An entity instance.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<CodeObjectMatrix[]?, Exception>> SearchAsync(CodeObjectMatrix filter)
    {
        try
        {
            CodeObjectMatrix[] entities = await _context.CodeObjectMatrices.Where(f =>
                string.IsNullOrEmpty(filter.CodeFlavour) || (f.CodeFlavour == filter.CodeFlavour &&
                string.IsNullOrEmpty(filter.InputType)) || (f.InputType == filter.InputType &&
                string.IsNullOrEmpty(filter.CodeObject)) || f.CodeObject == filter.CodeObject).ToArrayAsync();

            return Result<CodeObjectMatrix[]?, Exception>.GenerateResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeObjectMatrixRepository), nameof(SearchAsync));
            return Result<CodeObjectMatrix[]?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Updates the entity, using the passed entity instance.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public Result<CodeObjectMatrix?, Exception> Update(CodeObjectMatrix data)
    {
        try
        {
            CodeObjectMatrix? entity = _context.CodeObjectMatrices.Find(data.CodeObject, data.CodeFlavour, data.InputType);

            if (entity != null)
            {
                Map(ref entity, data);
                _context.SaveChanges();
            }

            return Result<CodeObjectMatrix?, Exception>.GenerateResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeObjectMatrixRepository), nameof(Update));
            return Result<CodeObjectMatrix?, Exception>.GenerateResult(ex);
        }
    }

    /// <summary>
    /// Updates the entity, using the passed entity instance.
    /// </summary>
    /// <param name="data">The entity.</param>
    /// <returns>A <see cref="Result{TResult, TException}"/> instance.</returns>
    public async Task<Result<CodeObjectMatrix?, Exception>> UpdateAsync(CodeObjectMatrix data)
    {
        try
        {
            CodeObjectMatrix? entity = await _context.CodeObjectMatrices.FindAsync(data.CodeObject, data.CodeFlavour, data.InputType);

            if (entity != null)
            {
                Map(ref entity, data);
                await _context.SaveChangesAsync();
            }

            return Result<CodeObjectMatrix?, Exception>.GenerateResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred at => {classname} => {methodname}", nameof(CodeObjectMatrixRepository), nameof(UpdateAsync));
            return Result<CodeObjectMatrix?, Exception>.GenerateResult(ex);
        }
    }

    protected override void Map(ref CodeObjectMatrix original, CodeObjectMatrix updated)
    {
        original.CodeFlavour = updated.CodeFlavour;
        original.InputType = updated.InputType;
        original.CodeObject = updated.CodeObject;
    }

    public override string CreateCommandText()
        => @"CREATE TABLE IF NOT EXISTS CodeObjectMatrix (
                        CodeFlavour TEXT NOT NULL,
                        InputType TEXT NOT NULL,
                        CodeObject TEXT NOT NULL,
                        CONSTRAINT PK_CodeObjectMappings PRIMARY KEY (CodeFlavour, InputType, CodeObject))";
    #endregion
}
