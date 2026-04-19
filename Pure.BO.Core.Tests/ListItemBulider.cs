namespace Pure.BO.Core.Tests;

public class ListItemBuilder
{
	private static Random _random = new();
	private static DateTime _baseData = DateTime.Now.AddDays(_random.Next(0,1000));

	private ListItem _parent;
	private string _name = Guid.NewGuid().ToString();
	private string _description = Guid.NewGuid().ToString();
	private bool _archive = _random.Next(0,1) == 1;
	private int? _id = _random.Next(0,1000);
	private DateTime _created;
	private string _createdBy = Guid.NewGuid().ToString();
	private DateTime _modified;
	private string _modifiedBy = Guid.NewGuid().ToString();
	private string _partitionKey = Guid.NewGuid().ToString();
	private string _rowKey = Guid.NewGuid().ToString();
	private DateTimeOffset _timestamp;
	private string _eTag = Guid.NewGuid().ToString();
	private byte[] _concurrencyTimestamp;
	private Dictionary<string, string> _metaData;

	private ListItem? _object;

	public ListItem Build()
	{
		return _object ??= new()
		{
			Parent = _parent,
			Name = _name,
			Description = _description,
			Archive = _archive,
			Id = _id,
			Created = _created,
			CreatedBy = _createdBy,
			Modified = _modified,
			ModifiedBy = _modifiedBy,
			PartitionKey = _partitionKey,
			RowKey = _rowKey,
			Timestamp = _timestamp,
			ETag = _eTag,
			ConcurrencyTimestamp = _concurrencyTimestamp,
			MetaData = _metaData
		};
	}

	public  ListItemBuilder WithParent(ListItem value)
	{
		_parent = value;
		return this;
	}

	public  ListItemBuilder WithName(string value)
	{
		_name = value;
		return this;
	}

	public  ListItemBuilder WithDescription(string value)
	{
		_description = value;
		return this;
	}

	public  ListItemBuilder WithArchive(bool value)
	{
		_archive = value;
		return this;
	}

	public  ListItemBuilder WithId(int? value)
	{
		_id = value;
		return this;
	}

	public  ListItemBuilder WithCreated(DateTime value)
	{
		_created = value;
		return this;
	}

	public  ListItemBuilder WithCreatedBy(string value)
	{
		_createdBy = value;
		return this;
	}

	public  ListItemBuilder WithModified(DateTime value)
	{
		_modified = value;
		return this;
	}

	public  ListItemBuilder WithModifiedBy(string value)
	{
		_modifiedBy = value;
		return this;
	}

	public  ListItemBuilder WithPartitionKey(string value)
	{
		_partitionKey = value;
		return this;
	}

	public  ListItemBuilder WithRowKey(string value)
	{
		_rowKey = value;
		return this;
	}

	public  ListItemBuilder WithTimestamp(DateTimeOffset value)
	{
		_timestamp = value;
		return this;
	}

	public  ListItemBuilder WithETag(string value)
	{
		_eTag = value;
		return this;
	}

	public  ListItemBuilder WithConcurrencyTimestamp(byte[] value)
	{
		_concurrencyTimestamp = value;
		return this;
	}

	public  ListItemBuilder WithMetaData(Dictionary<string, string> value)
	{
		_metaData = value;
		return this;
	}

}
