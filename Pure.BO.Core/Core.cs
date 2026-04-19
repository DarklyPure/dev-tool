using Pure.BO.Core.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Pure.BO.Core
{
    /// <summary>
    /// Core Business Object
    /// </summary>
    public abstract class Core
    {
        #region Properties
        /// <summary>
        /// Primary Key - Whereby a primary key is used and not a Row Key
        /// </summary>
        [RequiredIdentity()]
        public int? Id { get; set; }

        /// <summary>
        /// The date and time that the item was created
        /// </summary>
        public DateTime Created { get; set; } = DateTime.Now;

        /// <summary>
        /// The username of the account that created the item
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// The date and time that the item was last modified
        /// </summary>
        public DateTime Modified { get; set; } = DateTime.Now;

        /// <summary>
        /// The username of the account that last modified the item
        /// </summary>
        public string? ModifiedBy { get; set; }

        private string? _PartitionKey;
        /// <summary>
        /// The partition key - Becomes part of the primary key - can be duplicated
        /// </summary>
        [RequiredIdentity()]
        public string? PartitionKey
        {
            get => _PartitionKey;
            set => _PartitionKey = (!string.IsNullOrEmpty(value)) ? value.ToLower() : value;
        }

        private string? _RowKey;
        /// <summary>
        /// The row key - Becomes part of the primary key - Must be unique
        /// </summary>
        [RequiredIdentity()]
        public string? RowKey
        {
            get => _RowKey;
            set => _RowKey = (!string.IsNullOrEmpty(value)) ? value.ToLower() : value;
        }

        /// <summary>
        /// NoSQL/Table Storage Timestamp
        /// </summary>
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// The ETag works as a concurrency check. When updating a record update against
        /// <see cref="PartitionKey"/>, <see cref="RowKey"/> and <see cref="ETag"/>.
        /// </summary>
        public string? ETag { get; set; }

        /// <summary>
        /// Maps to an MSSQL Timestamp field providing concurrency checking
        /// </summary>
        public byte[]? ConcurrencyTimestamp { get; set; }

        /// <summary>
        /// A dictionary, containing meta data.
        /// </summary>
        public Dictionary<string, string> MetaData { get; set; } = [];
        #endregion

        #region Helpers
        /// <summary>
        /// Invokes validation on this business object.
        /// </summary>
        /// <returns>A collection of <see cref="ValidationResult"/> objects, containing the validation result.</returns>
        public virtual List<ValidationResult> Validate()
        {
            List<ValidationResult> results = [];

            // Run checks
            Validator.TryValidateObject(this, new ValidationContext(this), results, validateAllProperties: true);
            return results;
        }

        /// <summary>
        /// Generates a new <see cref="Guid"/> and sets the <see cref="RowKey"/> to this.
        /// </summary>
        public virtual void SetDefaultKey()
        {
            RowKey = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Dumps the Business Object to a Json file.
        /// </summary>
        /// <param name="fileName">The fully qualified name of the file.</param>
        public void DumpToJson(string fileName)
        {
            using StreamWriter streamWriter = new(fileName);

            streamWriter.Write(JsonSerializer.Serialize(this));
            streamWriter.Flush();
            streamWriter.Close();
        }

        /// <summary>
        /// Dumps the Business Object to a Json file, asynchronously.
        /// </summary>
        /// <param name="fileName">The fully qualified name of the file.</param>
        /// <returns>True if successful</returns>
        public async Task<bool> DumpToJsonAsync(string fileName)
        {
            try
            {
                using StreamWriter streamWriter = new(fileName);

                await streamWriter.WriteAsync(JsonSerializer.Serialize(this));
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Loads the passed instance to the business object.
        /// </summary>
        /// <typeparam name="T">The type of the instance.</typeparam>
        /// <param name="instance">The instance.</param>
        public void Load<T>(T instance)
        {
            Span<PropertyInfo> span = CollectionsMarshal.AsSpan(GetType().GetProperties().Where(f => f.CanWrite).ToList());

            for (int i = 0; i < span.Length; i++)
            {
                PropertyInfo? propertyInfo = span[i];

                PropertyInfo? propertyInfoThis = GetType().GetProperty(span[i].Name);

                if (propertyInfoThis != null)
                {
                    object? value = propertyInfo.GetValue(instance);

                    propertyInfoThis.SetValue(this, value);
                }
            }
        }
        #endregion
    }
}
