namespace Pure.Coders.Service.Tests.Mocks;

public sealed class SimpleClass
{
    public int IntegerProperty { get; set; }
    public string StringProperty { get; set; } = string.Empty;
    public DateTime DateProperty { get; set; }
    public void MethodWithoutReturnNoParameters()
    {

    }
    public bool MethodWithReturnWithParameters(string itemOne, int itemTwo, DateTime dateTime)
    {
        return true;
    }
}
