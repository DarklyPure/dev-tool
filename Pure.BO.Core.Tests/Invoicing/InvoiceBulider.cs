namespace Pure.BO.Core.Invoicing.Tests;

public class InvoiceBuilder
{
	private static Random _random = new();
	private static DateTime _baseData = DateTime.Now.AddDays(_random.Next(0,1000));

	private string _number = Guid.NewGuid().ToString();
	private DateOnly _issueDate;
	private DateOnly _dueDate;
	private Address? _sellerAddress;
	private Address? _customerAddress;
	private List<OrderItem> _items;
	private string _comments = Guid.NewGuid().ToString();
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

	private Invoice? _object;

	public Invoice Build()
	{
		return _object ??= new()
		{
			Number = _number,
			IssueDate = _issueDate,
			DueDate = _dueDate,
			SellerAddress = _sellerAddress,
			CustomerAddress = _customerAddress,
			Items = _items,
			Comments = _comments,
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

	public  InvoiceBuilder WithNumber(string value)
	{
		_number = value;
		return this;
	}

	public  InvoiceBuilder WithIssueDate(DateOnly value)
	{
		_issueDate = value;
		return this;
	}

	public  InvoiceBuilder WithDueDate(DateOnly value)
	{
		_dueDate = value;
		return this;
	}

	public  InvoiceBuilder WithSellerAddress(Address value)
	{
		_sellerAddress = value;
		return this;
	}

	public  InvoiceBuilder WithCustomerAddress(Address value)
	{
		_customerAddress = value;
		return this;
	}

	public  InvoiceBuilder WithItems(List<OrderItem> value)
	{
		_items = value;
		return this;
	}

	public  InvoiceBuilder WithComments(string value)
	{
		_comments = value;
		return this;
	}

	public  InvoiceBuilder WithId(int? value)
	{
		_id = value;
		return this;
	}

	public  InvoiceBuilder WithCreated(DateTime value)
	{
		_created = value;
		return this;
	}

	public  InvoiceBuilder WithCreatedBy(string value)
	{
		_createdBy = value;
		return this;
	}

	public  InvoiceBuilder WithModified(DateTime value)
	{
		_modified = value;
		return this;
	}

	public  InvoiceBuilder WithModifiedBy(string value)
	{
		_modifiedBy = value;
		return this;
	}

	public  InvoiceBuilder WithPartitionKey(string value)
	{
		_partitionKey = value;
		return this;
	}

	public  InvoiceBuilder WithRowKey(string value)
	{
		_rowKey = value;
		return this;
	}

	public  InvoiceBuilder WithTimestamp(DateTimeOffset value)
	{
		_timestamp = value;
		return this;
	}

	public  InvoiceBuilder WithETag(string value)
	{
		_eTag = value;
		return this;
	}

	public  InvoiceBuilder WithConcurrencyTimestamp(byte[] value)
	{
		_concurrencyTimestamp = value;
		return this;
	}

	public  InvoiceBuilder WithMetaData(Dictionary<string, string> value)
	{
		_metaData = value;
		return this;
	}

}
