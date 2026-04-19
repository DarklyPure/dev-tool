using Pure.Library.Extensions;

namespace Pure.Library.Tests.Extensions;

[TestClass]
public class DictionaryExtensionsTests
{
    [TestMethod]
    public void GetTypedValue_Returns_TypedValue()
    {
        // Arrange
        DateTime dateTime = DateTime.Now;
        Dictionary<int, object> sut = new()
        {
            [1] = "This is a string",
            [2] = 1,
            [3] = dateTime
        };

        // Act

        // Assert
        Assert.AreEqual("This is a string", sut.TryGetTypedValue<int, string>(1));
        Assert.AreEqual(1, sut.TryGetTypedValue<int, int>(2));
        Assert.AreEqual(dateTime, sut.TryGetTypedValue<int, DateTime>(3));
    }

    [TestMethod]
    public void GetTypedValue_Returns_Null()
    {
        // Arrange
        Dictionary<int, object> sut = new()
        {
            [1] = 1,
            [3] = 3
        };

        // Act
        ResultBinary<int> actual = sut.TryGetTypedValue<int, int>(2);

        // Assert
        Assert.IsFalse(actual.IsSuccess);
    }
}
