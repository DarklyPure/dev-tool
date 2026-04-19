using Pure.Library.Extensions;

namespace Pure.Library.Tests.Extensions;

[TestClass]
public class CollectionExtensionsTests
{
    [TestMethod]
    public void TakNewOfString_WithSecondList_HasNew_ReturnsTrue()
    {
        // Arrange
        List<string> sut = ["One", "Two", "Three", "Four"];
        List<string> secondList = ["One", "Two", "Three", "Four", "Five"];

        // Act
        List<string> actual = sut.TakeNew<string>(secondList);

        // Assert
        Assert.HasCount(1, actual);
        Assert.AreEqual("Five", actual.Last());
    }

    [TestMethod]
    public void TakeNewOfString_WithFirstList_HasNew_ReturnsTrue()
    {
        // Arrange
        List<string> sut = ["One", "Two", "Three", "Four", "Five"];
        List<string> secondList = ["One", "Two", "Three", "Four"];

        // Act
        List<string> actual = sut.TakeNew<string>(secondList);

        // Assert
        Assert.HasCount(1, actual);
        Assert.AreEqual("Five", actual.Last());
    }

    [TestMethod]
    public void TakNewOfInt_WithSecondList_HasNew_ReturnsTrue()
    {
        // Arrange
        List<int> sut = [1, 2, 3, 4];
        List<int> secondList = [1, 2, 3, 4, 5];

        // Act
        List<int> actual = sut.TakeNew<int>(secondList);

        // Assert
        Assert.HasCount(1, actual);
        Assert.AreEqual(5, actual.Last());
    }

    [TestMethod]
    public void TakeNewOfInt_WithFirstList_HasNew_ReturnsTrue()
    {
        // Arrange
        List<int> sut = [1, 2, 3, 4, 5];
        List<int> secondList = [1, 2, 3, 4];

        // Act
        List<int> actual = sut.TakeNew<int>(secondList);

        // Assert
        Assert.HasCount(1, actual);
        Assert.AreEqual(5, actual.Last());
    }
}
