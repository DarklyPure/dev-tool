namespace Pure.BO.Core.Tests;

public class PersonBuilder
{
	private static Random _random = new();
	private static DateTime _baseData = DateTime.Now.AddDays(_random.Next(0,1000));

	private string _title = Guid.NewGuid().ToString();
	private string _gender = Guid.NewGuid().ToString();
	private string _firstName = Guid.NewGuid().ToString();
	private string _lastName = Guid.NewGuid().ToString();
	private DateTime? _dateOfBirth;
	private int? _id = _random.Next(0,1000);
	private DateTime _created;
	private string _createdBy = Guid.NewGuid().ToString();
	private DateTime _modified;
	private string _modifiedBy = Guid.NewGuid().ToString();
	private string _partitionKey = Guid.NewGuid().ToString();
	private string _rowKey = Guid.NewGuid().ToString();
	private DateTimeOffset _timestamp;
	private string _eTag = Guid.NewGuid().ToString();
	private byte[] _concurrencyTimestamp = Guid.NewGuid().ToByteArray();
	private Dictionary<string, string> _metaData;

	private Person? _object;

	public Person Build()
	{
		return _object ??= new()
		{
			Title = _title,
			Gender = _gender,
			FirstName = _firstName,
			LastName = _lastName,
			DateOfBirth = _dateOfBirth,
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

	public  PersonBuilder WithTitle(string value)
	{
		_title = value;
		return this;
	}

	public  PersonBuilder WithGender(string value)
	{
		_gender = value;
		return this;
	}

	public  PersonBuilder WithFirstName(string value)
	{
		_firstName = value;
		return this;
	}

	public  PersonBuilder WithLastName(string value)
	{
		_lastName = value;
		return this;
	}

	public  PersonBuilder WithDateOfBirth(DateTime? value)
	{
		_dateOfBirth = value;
		return this;
	}

	public  PersonBuilder WithId(int? value)
	{
		_id = value;
		return this;
	}

	public  PersonBuilder WithCreated(DateTime value)
	{
		_created = value;
		return this;
	}

	public  PersonBuilder WithCreatedBy(string value)
	{
		_createdBy = value;
		return this;
	}

	public  PersonBuilder WithModified(DateTime value)
	{
		_modified = value;
		return this;
	}

	public  PersonBuilder WithModifiedBy(string value)
	{
		_modifiedBy = value;
		return this;
	}

	public  PersonBuilder WithPartitionKey(string value)
	{
		_partitionKey = value;
		return this;
	}

	public  PersonBuilder WithRowKey(string value)
	{
		_rowKey = value;
		return this;
	}

	public  PersonBuilder WithTimestamp(DateTimeOffset value)
	{
		_timestamp = value;
		return this;
	}

	public  PersonBuilder WithETag(string value)
	{
		_eTag = value;
		return this;
	}

	public  PersonBuilder WithConcurrencyTimestamp(byte[] value)
	{
		_concurrencyTimestamp = value;
		return this;
	}

	public  PersonBuilder WithMetaData(Dictionary<string, string> value)
	{
		_metaData = value;
		return this;
	}

}
