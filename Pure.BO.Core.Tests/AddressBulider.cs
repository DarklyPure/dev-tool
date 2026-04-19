namespace Pure.BO.Core.Tests;

public class AddressBuilder
{
	private static Random _random = new();
	private static DateTime _baseData = DateTime.Now.AddDays(_random.Next(0,1000));

	private string _houseNumber = Guid.NewGuid().ToString();
	private string _flatNumber = Guid.NewGuid().ToString();
	private string _buildingName = Guid.NewGuid().ToString();
	private string _street1 = Guid.NewGuid().ToString();
	private string _street2 = Guid.NewGuid().ToString();
	private string _area = Guid.NewGuid().ToString();
	private string _town = Guid.NewGuid().ToString();
	private string _region = Guid.NewGuid().ToString();
	private string _country = Guid.NewGuid().ToString();
	private string _postcode = Guid.NewGuid().ToString();
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

	private Address? _object;

	public Address Build()
	{
		return _object ??= new()
		{
			HouseNumber = _houseNumber,
			FlatNumber = _flatNumber,
			BuildingName = _buildingName,
			Street1 = _street1,
			Street2 = _street2,
			Area = _area,
			Town = _town,
			Region = _region,
			Country = _country,
			Postcode = _postcode,
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

	public  AddressBuilder WithHouseNumber(string value)
	{
		_houseNumber = value;
		return this;
	}

	public  AddressBuilder WithFlatNumber(string value)
	{
		_flatNumber = value;
		return this;
	}

	public  AddressBuilder WithBuildingName(string value)
	{
		_buildingName = value;
		return this;
	}

	public  AddressBuilder WithStreet1(string value)
	{
		_street1 = value;
		return this;
	}

	public  AddressBuilder WithStreet2(string value)
	{
		_street2 = value;
		return this;
	}

	public  AddressBuilder WithArea(string value)
	{
		_area = value;
		return this;
	}

	public  AddressBuilder WithTown(string value)
	{
		_town = value;
		return this;
	}

	public  AddressBuilder WithRegion(string value)
	{
		_region = value;
		return this;
	}

	public  AddressBuilder WithCountry(string value)
	{
		_country = value;
		return this;
	}

	public  AddressBuilder WithPostcode(string value)
	{
		_postcode = value;
		return this;
	}

	public  AddressBuilder WithId(int? value)
	{
		_id = value;
		return this;
	}

	public  AddressBuilder WithCreated(DateTime value)
	{
		_created = value;
		return this;
	}

	public  AddressBuilder WithCreatedBy(string value)
	{
		_createdBy = value;
		return this;
	}

	public  AddressBuilder WithModified(DateTime value)
	{
		_modified = value;
		return this;
	}

	public  AddressBuilder WithModifiedBy(string value)
	{
		_modifiedBy = value;
		return this;
	}

	public  AddressBuilder WithPartitionKey(string value)
	{
		_partitionKey = value;
		return this;
	}

	public  AddressBuilder WithRowKey(string value)
	{
		_rowKey = value;
		return this;
	}

	public  AddressBuilder WithTimestamp(DateTimeOffset value)
	{
		_timestamp = value;
		return this;
	}

	public  AddressBuilder WithETag(string value)
	{
		_eTag = value;
		return this;
	}

	public  AddressBuilder WithConcurrencyTimestamp(byte[] value)
	{
		_concurrencyTimestamp = value;
		return this;
	}

	public  AddressBuilder WithMetaData(Dictionary<string, string> value)
	{
		_metaData = value;
		return this;
	}

}
