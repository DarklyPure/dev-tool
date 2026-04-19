using System;
using System.Collections.Generic;
using System.Text;

namespace Pure.SQLiteRepository;

/// <summary>
/// <para>
/// Provides an abstracted base class for managing connection to
/// and specification of data tables in an Azure Storage Table environment.
/// </para>
/// </summary>
/// <typeparam name="DTO">The Data Transfer Object, this also acts as the Entity does in a SQL Entity Framework database</typeparam>
public abstract class RepositoryBase<DTO> where DTO : class, new()
{
    #region Internals
    /// <summary>
    /// The <see cref="Context"/> providing the connection string and <see cref="TableSet{DTO}"/> collections
    /// </summary>
    internal Context _Context;
    /// <summary>
    /// The <see cref="TableSet{DTO}"/> with it's data transfer object specified
    /// </summary>
    internal TableSet<DTO> _DBSet;
    #endregion

    #region Constructor
    /// <summary>
    /// Ctor takes context object
    /// </summary>
    /// <param name="context">The <see cref="Context"/>, specifying connection strings and <see cref="TableSet{DTO}"/> objects</param>
    public RepositoryBase(Context context)
    {
        _Context = context;
        _DBSet = context.Set<DTO>();
    }
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="context">The <see cref="Context"/>, specifying connection strings and <see cref="TableSet{DTO}"/> objects</param>
    /// <param name="partitionkey">The base <see cref="Microsoft.WindowsAzure.Storage.Table.ITableEntity.PartitionKey"/></param>
    public RepositoryBase(Context context, string partitionkey) : this(context) => _DBSet = context.Set<DTO>(partitionkey);
    #endregion

    #region Data Portal
    /// <summary>
    /// Performs a fetch against the database
    /// </summary>
    /// <param name="partitionkey">The partition key</param>
    /// <param name="rowkey">The row key</param>
    /// <returns>A single Data Transfer Object</returns>
    public virtual async Task<DTO> FetchAsync(string partitionkey, string rowkey) => await _DBSet.FetchAsync(partitionkey, rowkey);
    /// <summary>
    /// Performs a fetch against the database
    /// </summary>
    /// <param name="partitionkey">The partition key</param>
    /// <param name="takecount">The maximum count of records to take</param>
    /// <returns>A collection of Data Transfer Objects</returns>
    public virtual async Task<IList<DTO>> FetchAsync(string partitionkey, int takecount) => await _DBSet.FetchAsync(partitionkey, takecount);
    /// <summary>
    /// Performs a fetch against the database
    /// </summary>
    /// <returns>A collection of Data Transfer Objects</returns>
    public virtual async Task<IList<DTO>> FetchAsync() => await _DBSet.FetchAsync();
    /// <summary>
    /// Inserts the passed Data Transfer Object into the database
    /// </summary>
    /// <param name="dto">A Data Transfer Object</param>
    /// <returns>An updated Data Transfer object</returns>
    public virtual async Task<DTO> InsertAsync(DTO dto) => await _DBSet.InsertAsync(dto);
    /// <summary>
    /// Inserts the passed Data Transfer Object collection into the database
    /// </summary>
    /// <param name="dtos">A Data Transfer Object</param>
    /// <returns>An updated Data Transfer Object</returns>
    public virtual async Task<IList<DTO>> InsertAsync(IList<DTO> dtos) => await _DBSet.InsertAsync(dtos);
    /// <summary>
    /// Updates, Inserts or Replaces the Data Transfer Object in the database
    /// </summary>
    /// <param name="dto">A Data Transfer Object</param>
    /// <returns>An updated Data Transfer Object</returns>
    public virtual async Task<DTO> UpdateInsertOrReplaceAsync(DTO dto) => await _DBSet.UpdateInsertOrReplaceAsync(dto);
    /// <summary>
    /// Deletes the Data Transfer Object collection from the database
    /// </summary>
    /// <param name="dtos">A Data Transfer Object collection</param>
    /// <returns>True if successful, false if not</returns>
    public virtual async Task<bool> DeleteAsync(IList<DTO> dtos) => await _DBSet.DeleteAsync(dtos);
    /// <summary>
    /// Deletes the Data Transfer Object from the database
    /// </summary>
    /// <param name="dto">A Data Transfer Object</param>
    /// <returns>True if successful, false if not</returns>
    public virtual async Task<bool> DeleteAsync(DTO dto) => await _DBSet.DeleteAsync(dto);
    /// <summary>
    /// Backs up the complete contents of the <see cref="Microsoft.Azure.Cosmos.Table"/> to a file
    /// </summary>
    /// <param name="path">The fully qualified path to the file to back up to</param>
    /// <returns>True if successful, false if not</returns>
    public virtual async Task<bool> BackUpToFileAsync(string path) => await _DBSet.BackUpToFileAsync(path);
    #endregion
}
