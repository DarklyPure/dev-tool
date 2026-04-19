namespace Pure.SQLiteRepository;

public class Entity
{

	#region Variables
	private Dictionary<Type, Func<object>> _valueSetters = new()
	{
		[typeof(int)] = 
	};
	#endregion
}
