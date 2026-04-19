using System.Data.Common;

namespace Pure.Library.SQLite.Extensions;

/// <summary>
/// Extensions based around the <see cref="DbConnection"/> object.
/// </summary>
public static class DbConnectionExtensions
{
    /// <summary>
    /// Produces a query for getting all of the table names.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/> instance.</param>
    /// <returns>A list of table names.</returns>
    public static List<string> QueryTableNames(this DbConnection connection)
    {
        List<string> tables = [];

        // Ensure connection is open
        if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }

        using DbCommand command = connection.CreateCommand();
        command.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%';";

        using DbDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            tables.Add(reader.GetString(0));
        }

        return tables;
    }
}
