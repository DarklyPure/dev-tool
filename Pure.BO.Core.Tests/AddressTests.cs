using Pure.Library.Extensions;
using System.Text.Json;

namespace Pure.BO.Core.Tests;

[TestClass]
public sealed class AddressTests
{
    [TestMethod]
    public void Address_Populated_Serialisation_AreEqual()
    {
        // Arrange
        Address sut = new AddressBuilder().Build();

        // Act
        string json = JsonSerializer.Serialize(sut);
        Address? actual = JsonSerializer.Deserialize<Address>(json);

        // Assert
        Assert.IsTrue(actual!.JsonComparator(sut));
    }

    [TestMethod]
    public void Address_Default_Serialisation_IsTrue()
    {
        // Arrange
        Address sut = new();

        // Act
        string json = JsonSerializer.Serialize(sut);
        Address? actual = JsonSerializer.Deserialize<Address>(json);

        // Assert
        Assert.IsTrue(actual!.JsonComparator(sut));
    }
}
