using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Pure.Library.SQLite.Extensions.Utilities;

/// <summary>
/// Database maintenance helper.
/// </summary>
/// <remarks>
/// This pro-actively backs up the database, then queries it to check if a version 
/// </remarks>
/// <typeparam name="T"></typeparam>
public abstract class Maintenance<TContext> where TContext : DbContext
{
    public Maintenance(TContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
        _source = new CancellationTokenSource();
        _context.Database.EnsureCreated();
    }

    protected readonly TContext _context;
    private readonly CancellationTokenSource _source;
    private readonly ILogger _logger;

    #region Create Statements
    protected void RefreshDatabase(Dictionary<string, Func<string>> tableCreateCommands)
    {
        // Get a list of all current entities
        string[] entities = [.. _context.Model.GetEntityTypes().Select(t => t.ClrType.Name)];

        // Get a list of all current tables
        string[] tables = ListAllTables();

        string[] newTables = [.. entities.Except(tables)];

        int i = 0;
        while (i < newTables.Length)
        {
            string tableName = newTables[i++];

            string commandText = tableCreateCommands[tableName].Invoke();

            CreateTable(commandText);
        }
    }

    private string[] ListAllTables() => [.. _context.Database.GetDbConnection().QueryTableNames()];

    private bool CreateTable(string commandText)
    {
        try
        {
            _context.Database.ExecuteSqlRaw(commandText);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred whilst creating a table.");
        }
        return false;
    }
    #endregion
}
