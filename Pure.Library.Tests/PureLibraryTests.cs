namespace Pure.Library.Tests;

[TestClass]
public class PureLibraryTests
{
    [TestMethod]
    public void BinaryResult_Returns_True()
    {
        // Arrange
        ResultBinary<int> result = 1;

        // Act

        // Assert
        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(1, result.ResultValue);
    }

    [TestMethod]
    public void BinaryResult_Returns_False()
    {
        // Arrange
        ResultBinary<int> result = new();

        // Act

        // Assert
        Assert.IsFalse(result.IsSuccess);
    }
}
