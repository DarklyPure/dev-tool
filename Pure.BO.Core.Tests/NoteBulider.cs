namespace Pure.BO.Core.Tests;

public class NoteBuilder
{
	private static Random _random = new();
	private static DateTime _baseData = DateTime.Now.AddDays(_random.Next(0,1000));

	private DateTime _created;
	private string _createdBy = Guid.NewGuid().ToString();
	private DateTime _edited;
	private string _editedBy = Guid.NewGuid().ToString();
	private string _description = Guid.NewGuid().ToString();
	private string _content = Guid.NewGuid().ToString();

	private Note? _object;

	public Note Build()
	{
		return _object ??= new()
		{
			Created = _created,
			CreatedBy = _createdBy,
			Edited = _edited,
			EditedBy = _editedBy,
			Description = _description,
			Content = _content
		};
	}

	public  NoteBuilder WithCreated(DateTime value)
	{
		_created = value;
		return this;
	}

	public  NoteBuilder WithCreatedBy(string value)
	{
		_createdBy = value;
		return this;
	}

	public  NoteBuilder WithEdited(DateTime value)
	{
		_edited = value;
		return this;
	}

	public  NoteBuilder WithEditedBy(string value)
	{
		_editedBy = value;
		return this;
	}

	public  NoteBuilder WithDescription(string value)
	{
		_description = value;
		return this;
	}

	public  NoteBuilder WithContent(string value)
	{
		_content = value;
		return this;
	}

}
