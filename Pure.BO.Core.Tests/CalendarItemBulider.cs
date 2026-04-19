namespace Pure.BO.Core.Tests;

public class CalendarItemBuilder
{
	private static Random _random = new();
	private static DateTime _baseData = DateTime.Now.AddDays(_random.Next(0,1000));

	private DateTime _dateStart;
	private DateTime? _dateEnd;
	private bool _isAllDay = _random.Next(0,1) == 1;
	private string _title = Guid.NewGuid().ToString();
	private string _description = Guid.NewGuid().ToString();

	private CalendarItem? _object;

	public CalendarItem Build()
	{
		return _object ??= new()
		{
			DateStart = _dateStart,
			DateEnd = _dateEnd,
			IsAllDay = _isAllDay,
			Title = _title,
			Description = _description
		};
	}

	public  CalendarItemBuilder WithDateStart(DateTime value)
	{
		_dateStart = value;
		return this;
	}

	public  CalendarItemBuilder WithDateEnd(DateTime? value)
	{
		_dateEnd = value;
		return this;
	}

	public  CalendarItemBuilder WithIsAllDay(bool value)
	{
		_isAllDay = value;
		return this;
	}

	public  CalendarItemBuilder WithTitle(string value)
	{
		_title = value;
		return this;
	}

	public  CalendarItemBuilder WithDescription(string value)
	{
		_description = value;
		return this;
	}

}
