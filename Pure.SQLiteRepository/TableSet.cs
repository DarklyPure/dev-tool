using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Pure.SQLiteRepository;

/// <summary>
/// <para>
/// A Table Set, like an Entity Set from the Entity Framework but based on the underlying
/// Data Transfer Object
/// </para>
/// </summary>
/// <typeparam name="DTO">The Data Transfer Object the Entity is based on</typeparam>
/// <remarks>
/// <para>
/// ********************
/// * REMEMBER *********
/// ********************
/// The minimum DateTime value you can have with Table Storage is: Jan 1, 1601
/// </para>
/// </remarks>
public class TableSet<DTO>(ILogger logger, string connectionString, string tableName) : ITableSet where DTO : class, new()
{
    #region Variables
    // internal List<DTO> _MappedList = new List<DTO>();
    internal List<TableEntityDto> _InternalList = new List<TableEntityDto>();
    /// <summary>
    /// Serilog Logger instance
    /// </summary>
    private readonly ILogger _Logger = logger;
    private readonly string _connectionString = connectionString;
    private readonly string _tableName = tableName;
    #endregion

    #region Properties
    public Exception Error { get; set; }
    public string TableName { get; private set; }
    #endregion

    #region Data Portal
    /// <summary>
    /// Asynchronous - Performs a fetch for a <see cref="TableEntity"/> object that matches the parameters passed.
    /// </summary>
    /// <param name="partitionkey">The required <see cref="TableEntity.PartitionKey"/></param>
    /// <param name="rowkey">The required <see cref="TableEntity.RowKey"/></param>
    /// <returns>A single instance of the T <see cref="TableEntity"/> matching the parameters passed.</returns>
    public async Task<DTO> FetchAsync(string partitionkey, string rowkey)
    {
        TableResult retrievedResult = null;

        try
        {

            _Logger.Information($"Creating the retrieve operation");
            // Create the retrieve operation using type T. Passing the partition key and the row key.
            TableOperation retrieveOperation = TableOperation.Retrieve(partitionkey, rowkey);

            // Do an async fetch, returning whatever result to the Table Result object.
            try
            {
                _Logger.Information($"Querying the table");

                // Run the retrieve
                retrievedResult = await _CloudTable.ExecuteAsync(retrieveOperation);

            }
            catch (Exception ex)
            {
                // Derive the location
                string location = $"TableSet<{new DTO().GetType().Name}>.FetchAsync";
                // Log inner exception if it exists
                _Logger.Error($"Location: {location}{Environment.NewLine}{ex}");
                throw;
            }

            // Pass the retrieved result back casting it to a T instance.
            return new TableEntityDto().ToDTO<DTO>((DynamicTableEntity)retrievedResult.Result);
        }
        catch (Exception ex)
        {
            // Derive the location
            string location = $"TableSet<{new DTO().GetType().Name}>.FetchAsync";
            // Log inner exception if it exists
            _Logger.Error($"Location: {location}{Environment.NewLine}{ex}");
            throw;
        }
    }
    /// <summary>
    /// Asynchronous - Performs a fetch for a maximum of collection of <see cref="TableEntity"/> objects, up to the value of the number specified, that match the parameter passed.
    /// </summary>
    /// <param name="partitionkey">The required <see cref="TableEntity.PartitionKey"/></param>
    /// <param name="takecount">The maximum number of matching records to take/return</param>
    /// <returns>An IEnumerable IList of <see cref="TableEntity"/> objects that match the parameter passed.</returns>
    public async Task<IList<DTO>> FetchAsync(string partitionkey, int takecount)
    {
        try
        {
            // Create a new result list
            List<DynamicTableEntity> result = new List<DynamicTableEntity>();

            // Create a new data transfer object return list
            IList<DTO> returnresults = new List<DTO>();

            // Create a new table query
            TableQuery query = new TableQuery().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionkey));

            // Set the take count
            query.TakeCount = takecount;

            // Create a tablee continuation token
            TableContinuationToken tablecontinuationtoken = null;

            // While the table continuation token is not null
            do
            {
                // Execute the query
                TableQuerySegment<DynamicTableEntity> queryResponse = await _CloudTable.ExecuteQuerySegmentedAsync(query, tablecontinuationtoken);

                // Load the table continuation token
                tablecontinuationtoken = queryResponse.ContinuationToken;

                // Add the results collection to the result collection
                result.AddRange(queryResponse.Results);

            } while (tablecontinuationtoken != null);

            // Iterate the result collection, converting to a data transfer object as you go
            foreach (DynamicTableEntity item in result)
            {
                // Add to the return dto collection
                returnresults.Add(new TableEntityDto().ToDTO<DTO>(item));
            }

            return returnresults;
        }
        catch (Exception ex)
        {
            // Derive the location
            string location = $"TableSet<{new DTO().GetType().Name}>.FetchAsync";
            // Log inner exception if it exists
            _Logger.Error($"Location: {location}{Environment.NewLine}{ex}");
            throw;
        }
    }
    /// <summary>
    /// Performs a fetch of all items in the table
    /// </summary>
    /// <returns>Returns a DTO collection</returns>
    public async Task<IList<DTO>> FetchAsync()
    {
        // Create a return list of D.T.O. objects
        IList<DTO> returnresults = new List<DTO>();

        try
        {
            // Create a result list of entities
            List<DynamicTableEntity> entities = new List<DynamicTableEntity>();

            // Create an entity result object
            TableQuerySegment<DynamicTableEntity> queryResult;

            // Create a Table Continuation token
            TableContinuationToken token = null;

            // Loop until the continuation token is null
            do
            {
                // Get the query result
                queryResult = await _CloudTable.ExecuteQuerySegmentedAsync(new TableQuery<DynamicTableEntity>(), token);

                // Add to the entities
                entities.AddRange(queryResult.Results);

                // Get a continuation token
                token = queryResult.ContinuationToken;

            } while (token != null);

            // Iterate the entities converting to DTO's
            queryResult.ToList().ForEach(e => returnresults.Add(new TableEntityDto().ToDTO<DTO>(e)));
        }
        catch (Exception ex)
        {
            // Derive the location
            string location = $"TableSet<{new DTO().GetType().Name}>.FetchAsync";
            // Log inner exception if it exists
            _Logger.Error($"Location: {location}{Environment.NewLine}{ex}");
            throw;
        }
        // Return the results
        return returnresults;
    }
    /// <summary>
    /// Asynchronous - Performs an insert of the item passed into the specified table.
    /// </summary>
    /// <param name="dto">A valid TableEntity object</param>
    /// <returns></returns>
    public async Task<DTO> InsertAsync(DTO dto)
    {
        ITableEntity entity = new TableEntityDto().ToEntity(dto);

        TableOperation tableoperation;

        TableResult tableresult;

        try
        {
            try
            {
                tableoperation = TableOperation.Insert(entity);

                tableresult = await _CloudTable.ExecuteAsync(tableoperation);

                dto = new TableEntityDto().ToDTO<DTO>((TableEntityDto)tableresult.Result);

                entity.ETag = tableresult.Etag;
            }
            catch (StorageException ex)
            {
                // Derive the location
                string location = $"TableSet<{new DTO().GetType().Name}>.FetchAsync";
                // Log inner exception if it exists
                _Logger.Error($"Location: {location}{Environment.NewLine}{ex}");
                throw;

                // The current record already exists, attempt an update instead
                if (ex.RequestInformation.HttpStatusCode == 409)
                {

                    _Logger.Information($"Attempting UpdateInsertOrReplace");

                    await UpdateInsertOrReplaceAsync(dto);
                }
            }
            catch (Exception ex)
            {
                // Derive the location
                string location = $"TableSet<{new DTO().GetType().Name}>.InsertAsync";
                // Log inner exception if it exists
                _Logger.Error($"Location: {location}{Environment.NewLine}{ex}");
                throw;
            }
        }
        catch (StorageException ex)
        {
            // Derive the location
            string location = $"TableSet<{new DTO().GetType().Name}>.InsertAsync";
            // Log inner exception if it exists
            _Logger.Error($"Location: {location}{Environment.NewLine}{ex}");
            throw;
        }
        return dto;
    }
    public async Task<IList<DTO>> InsertAsync(IList<DTO> dtos)
    {
        // Create a table batch operation
        TableBatchOperation batchoperation = new TableBatchOperation();
        // Create a List of return table results
        IList<TableResult> tableresults;
        // Create a list of 
        IList<DTO> dtoresults = new List<DTO>();
        try
        {
            // Iterate the DTO collection, converting into Entities and building the batch
            foreach (DTO dto in dtos)
            {
                ITableEntity entity = new TableEntityDto().ToEntity(dto);

                batchoperation.Insert(entity);
            }

            // Execute the batch  
            tableresults = await _CloudTable.ExecuteBatchAsync(batchoperation);

            // Iterate the table results, converting back to DTO's
            foreach (TableResult result in tableresults)
            {
                dtoresults.Add(new TableEntityDto().ToDTO<DTO>((TableEntityDto)result.Result));
            }

            return dtoresults;
        }
        catch (Exception ex)
        {
            // Derive the location
            string location = $"TableSet<{new DTO().GetType().Name}>.InsertAsync";
            // Log inner exception if it exists
            _Logger.Error($"Location: {location}{Environment.NewLine}{ex}");
            throw;
        }
    }
    /// <summary>
    /// Asynchronous - Performs an Update of the <see cref="TableEntity"/> object passed using the Insert or Replace method.
    /// </summary>
    /// <param name="dto">A <see cref="TableEntity"/> instance.</param>
    /// <returns>The <see cref="TableEntity"/> object passed, with the <see cref="TableEntity.ETag"/> updated for concurrency purposes</returns>
    public async Task<DTO> UpdateInsertOrReplaceAsync(DTO dto)
    {
        ITableEntity entity = new TableEntityDto().ToEntity(dto);

        TableOperation tableoperation;

        TableResult tableresult;

        try
        {
            // Instantiates the TableOperation as an InsertOrReplace instance passing the TableEntity
            tableoperation = TableOperation.InsertOrReplace(entity);

            // Performs the Table Operation Asynchronously.
            tableresult = await _CloudTable.ExecuteAsync(tableoperation);
        }
        catch (Exception ex)
        {
            // Derive the location
            string location = $"TableSet<{new DTO().GetType().Name}>.UpdateInsertOrReplaceAsync";
            // Log inner exception if it exists
            _Logger.Error($"Location: {location}{Environment.NewLine}{ex}");
            throw;
        }

        // Updates the TableEntity.Etag field of the TableEntity parameter for concurrency checks
        return new TableEntityDto().ToDTO<DTO>((TableEntityDto)tableresult.Result);
    }
    /// <summary>
    /// Asynchronous - Performs a Deletion of the TableEntity collection passed.
    /// </summary>
    /// <param name="dtos">An IEnumerable, IList collection of TableEntity items.</param>
    /// <returns>True if succeeds</returns>
    public async Task<bool> DeleteAsync(IList<DTO> dtos)
    {
        try
        {
            TableBatchOperation tableBatchOperation = new TableBatchOperation();

            foreach (DTO item in dtos)
            {
                try
                {
                    tableBatchOperation.Delete(new TableEntityDto().ToEntity(item));
                }
                catch (Exception ex)
                {
                    // Log inner exception if it exists
                    _Logger.Error($"{ex}");
                    throw;
                }
            }
            await _CloudTable.ExecuteBatchAsync(tableBatchOperation);
        }
        catch (StorageException ex)
        {
            // Derive the location
            string location = $"TableSet<{new DTO().GetType().Name}>.DeleteAsync";
            // Log inner exception if it exists
            _Logger.Error($"Location: {location}{Environment.NewLine}{ex}");
            throw;
        }
        return true;
    }
    public async Task<bool> DeleteAsync(DTO dto)
    {
        try
        {
            TableBatchOperation tableBatchOperation = new TableBatchOperation();

            tableBatchOperation.Delete(new TableEntityDto().ToEntity(dto));

            // Invoke the delete
            await _CloudTable.ExecuteBatchAsync(tableBatchOperation);
        }
        catch (Exception ex)
        {
            // Derive the location
            string location = $"TableSet<{new DTO().GetType().Name}>.DeleteAsync";
            // Log inner exception if it exists
            _Logger.Error($"Location: {location}{Environment.NewLine}{ex}");
            throw;
        }
        return true;
    }
    #endregion

    #region object mapping              
    public int Commit()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Helper Methods
    public async Task<bool> BackUpToFileAsync(string path, string fileName = null)
    {
        try
        {
            // Check if a filename has been provided
            if (fileName == null)
            {
                // No filename provided. Derive from Table name suffixing with _Backup_ and the 
                fileName = $"{TableName}_Backup_{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.json";
            }

            // Create a new stream writer
            using StreamWriter writer = new StreamWriter(Path.Combine(path, fileName));

            // Call all records
            IList<DTO> records = await FetchAsync();

            // Convert the records to a json string
            string json = JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true });

            // Write to the file
            await writer.WriteAsync(json);

            // Flush and Close
            writer.Flush();
            writer.Close();

        }
        catch (Exception ex)
        {
            _Logger.Error($"{ex}");
            throw;
        }

        return true;
    }
    private void InitialiseTable(string tablename)
    {
        try
        {
            // Store the Table name
            TableName = tablename;

            // Initialize if not already initialised
            if (_TableClient == null)
            {
                // Get the specified Table client
                _TableClient = _CloudStorageAccount.CreateCloudTableClient();
                // Get the referenced table
                _CloudTable = _TableClient.GetTableReference(tablename);
                // Specify that it's to be created if it doesn't exist
                _CloudTable.CreateIfNotExistsAsync();
            }
        }
        catch (Exception ex)
        {
            // Derive the location
            string location = $"TableSet<{new DTO().GetType().Name}>.InitialiseTable";
            // Log inner exception if it exists
            _Logger.Error($"Location: {location}{Environment.NewLine}{ex}");
            throw;
        }
    }
    #endregion
}
