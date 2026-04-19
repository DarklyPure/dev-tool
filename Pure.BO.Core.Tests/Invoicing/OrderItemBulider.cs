namespace Pure.BO.Core.Invoicing.Tests;

public class OrderItemBuilder
{
	private static Random _random = new();

	private string _name = Guid.NewGuid().ToString();
	private decimal _price;
	private int _quantity = _random.Next(0,1000);

	private OrderItem? _object;

	public OrderItem Build()
	{
		return _object ??= new()
		{
			Name = _name,
			Price = _price,
			Quantity = _quantity
		};
	}

	public  OrderItemBuilder WithName(string value)
	{
		_name = value;
		return this;
	}

	public  OrderItemBuilder WithPrice(decimal value)
	{
		_price = value;
		return this;
	}

	public  OrderItemBuilder WithQuantity(int value)
	{
		_quantity = value;
		return this;
	}

}
