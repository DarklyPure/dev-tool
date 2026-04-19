namespace Pure.BO.Core.Tests;

public class AppointmentBuilder
{
	private static Random _random = new();
	private static DateTime _baseData = DateTime.Now.AddDays(_random.Next(0,1000));

	private bool _allDayEvent = _random.Next(0,1) == 1;
	private string _body = Guid.NewGuid().ToString();
	private Dictionary<string, string>? _metaData;
	private int _duration = _random.Next(0,1000);
	private DateTime _end;
	private bool _isRecurring = _random.Next(0,1) == 1;
	private DateTime _start;
	private string _subject = Guid.NewGuid().ToString();

	private Appointment? _object;

	public Appointment Build()
	{
		return _object ??= new()
		{
			AllDayEvent = _allDayEvent,
			Body = _body,
			MetaData = _metaData,
			Duration = _duration,
			End = _end,
			IsRecurring = _isRecurring,
			Start = _start,
			Subject = _subject
		};
	}

	public  AppointmentBuilder WithAllDayEvent(bool value)
	{
		_allDayEvent = value;
		return this;
	}

	public  AppointmentBuilder WithBody(string value)
	{
		_body = value;
		return this;
	}

	public  AppointmentBuilder WithMetaData(Dictionary<string, string> value)
	{
		_metaData = value;
		return this;
	}

	public  AppointmentBuilder WithDuration(int value)
	{
		_duration = value;
		return this;
	}

	public  AppointmentBuilder WithEnd(DateTime value)
	{
		_end = value;
		return this;
	}

	public  AppointmentBuilder WithIsRecurring(bool value)
	{
		_isRecurring = value;
		return this;
	}

	public  AppointmentBuilder WithStart(DateTime value)
	{
		_start = value;
		return this;
	}

	public  AppointmentBuilder WithSubject(string value)
	{
		_subject = value;
		return this;
	}

}
