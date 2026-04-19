using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Pure.Library.SQLite.Extensions;

/// <summary>
/// A collection of extensions extending the <see cref="DbContext"/> object.
/// </summary>
public static class DbContextExtensions
{
    /// <summary>
    /// Refreshes the <see cref="DbContext.Database"/> adding new tables.
    /// </summary>
    /// <param name="context">A <see cref="DbContext"/> instance.</param>
    /// <param name="tableCreateCommands">A dictionary containing create commands for new tables.</param>
    /// <param name="logger">An <see cref="ILogger"/> instance.</param>
    public static void RefreshDatabase(this DbContext context, Dictionary<string, string> tableCreateCommands, ILogger logger)
    {
        // Get a list of all the current entities
        string[] entities = context.AllEntities();

        // Get a list of all of the current tables
        string[] tables = context.AllTables();

        // Get a list of new entities, i.e. tables that haven't yet been created.
        string[] newTables = [.. entities.Except(tables)];

        // Iterate all new tables, creating them where they don't exist
        int i = 0;
        while (i < newTables.Length)
        {
            string tableName = newTables[i++];

            string commandText = tableCreateCommands[tableName];

            context.CreateTable(commandText, logger);
        }
    }

    /// <summary>
    /// Creates a table using the raw sql.
    /// </summary>
    /// <param name="context">The <see cref="DbContext"/> instance.</param>
    /// <param name="commandText">The raw sql for the table creation.</param>
    /// <param name="logger">An <see cref="ILogger"/> instance.</param>
    /// <returns>True if successful.</returns>
    /// <remarks>
    /// Use this in lieu of using Database migrations to add new tables.
    /// </remarks>
    public static bool CreateTable(this DbContext context, string commandText, ILogger logger)
    {
        try
        {
            context.Database.ExecuteSqlRaw(commandText);
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred whilst creating a table.");
        }
        return false;
    }

    /// <summary>
    /// List all current entities available on this <see cref="DbContext"/>.
    /// </summary>
    /// <param name="context">The <see cref="DbContext"/>.</param>
    /// <returns>A list of the table names.</returns>
    /// <remarks>
    /// Note: This is not necessarily the same as the number of tables.
    /// If any of these entities don't exist they can be created using the <see cref="DbContext"/> extensions.
    /// </remarks>
    private static string[] AllEntities(this DbContext context) => [.. context.Model.GetEntityTypes().Select(t => t.ClrType.Name)];

    /// <summary>
    /// List all tables on the <see cref="DbContext.Database"/>.
    /// </summary>
    /// <param name="context">The <see cref="DbContext"/> instance.</param>
    /// <returns>A list of all the current tables.</returns>
    private static string[] AllTables(this DbContext context) => [.. context.Database.GetDbConnection().QueryTableNames()];
}
