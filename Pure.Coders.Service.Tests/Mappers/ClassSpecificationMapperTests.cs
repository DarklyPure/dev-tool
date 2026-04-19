using Pure.BO.Coders;
using Pure.Coders.Service.Mappers;
using Pure.Coders.Service.Tests.Mocks;

namespace Pure.Coders.Service.Tests.Mappers;

[TestClass]
public class ClassSpecificationMapperTests
{
    [TestMethod]
    public void Map_From_Type_Maps_Correctly()
    {
        // Arrange
        SimpleClass sut = new();

        // Act
        ClassSpecification actual = ClassSpecificationMapper.Map(sut.GetType());

        // Assert
        Assert.AreEqual("SimpleClass", actual.Name);
    }

    [TestMethod]
    public void Map_From_Type_With_Constructors_Maps_Correctly()
    {
        // Arrange
        SimpleClassWithConstructors sut = new(1, "", DateTime.Now);

        // Act
        ClassSpecification actual = ClassSpecificationMapper.Map(sut.GetType());

        // Assert
        Assert.AreEqual("SimpleClassWithConstructors", actual.Name);
    }
}
