using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pure.SQLiteRepository;

/// <summary>
/// Context base
/// </summary>
public abstract class Context
{
    #region Constructors
    private Context() => _InternalContext = new List<ITableSet>();
    private Context(ILogger logger) : this() => _Logger = logger;
    protected Context(ILogger logger, string connectionstring) : this(logger) => ConnectionString = connectionstring;
    public Context(ILogger logger, string connectionstring, string tablename) : this(logger, connectionstring) => TableName = tablename;
    #endregion

    #region Private Properties
    private ILogger _Logger;
    public string TableName { get; set; }
    public string ConnectionString { get; set; }
    #endregion

    private IList<ITableSet> _InternalContext { get; set; }
    public virtual TableSet<T> Set<T>(string partitionkey) where T : class, new()
    {
        TableSet<T> set = new TableSet<T>(_Logger, ConnectionString, TableName, partitionkey);
        _InternalContext.Add(set);
        return set;
    }
    public virtual TableSet<T> Set<T>() where T : class, new()
    {
        TableSet<T> set = new TableSet<T>(_Logger, ConnectionString, TableName);
        _InternalContext.Add(set);
        return set;
    }
}
