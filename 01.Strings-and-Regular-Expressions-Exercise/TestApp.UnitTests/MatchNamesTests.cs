using NUnit.Framework;
using System.Xml.Linq;

namespace TestApp.UnitTests;

public class MatchNamesTests
{
    [Test]
    public void Test_Match_ValidNames_ReturnsMatchedNames()
    {
        // Arrange
        string names = "John Smith and Alice Johnson";
        string expected = "John Smith Alice Johnson";

        // Act
        string result = MatchNames.Match(names);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Match_NoValidNames_ReturnsEmptyString()
    {
        // Arrange
        string text = "My name is Diyan apostolov from Varna. Some other names: pesho Angelov and ANA Karenina";

        // Act
        string result = MatchNames.Match(text);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Match_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string text = string.Empty;

        // Act
        string result = MatchNames.Match(text);

        // Assert
        Assert.That(result, Is.Empty);
    }
}
