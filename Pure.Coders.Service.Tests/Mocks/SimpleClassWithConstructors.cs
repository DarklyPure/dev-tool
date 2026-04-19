namespace Pure.Coders.Service.Tests.Mocks;

public class SimpleClassWithConstructors(int integerProperty, string stringProperty, DateTime dateTimeProperty)
{
    private readonly int _integerProperty = integerProperty;
    private readonly string _stringProperty = stringProperty;
    private readonly DateTime _dateTimeProperty = dateTimeProperty;


    public int IntegerProperty { get; set; }
    public string StringProperty { get; set; } = string.Empty;
    public DateTime DateProperty { get; set; }
}
