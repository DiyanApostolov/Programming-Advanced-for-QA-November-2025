using NUnit.Framework;

namespace TestApp.UnitTests;

public class SubstringTests
{
    // TODO: finish the test
    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromMiddle()
    {
        // Arrange
        string toRemove = "fox";
        string input = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick brown jumps over the lazy dog";

        // Act
        string result = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromStart()
    {
        // Arrange
        string toRemove = "Brown";
        string input = "Brown fox jumps over the lazy dog";
        string expected = "fox jumps over the lazy dog";

        // Act
        string result = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromEnd()
    {
        // Arrange
        string toRemove = "dog";
        string input = "Brown fox jumps over the lazy dog";
        string expected = "Brown fox jumps over the lazy";

        // Act
        string result = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesAllOccurrences()
    {
        // Arrange
        string toRemove = "THE";  // test case insensitive
        string input = "The quick brown fox jumps over the lazy dog";
        string expected = "quick brown fox jumps over lazy dog";

        // Act
        string result = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // BONUS TESTS - NOT FOR JUDGE
    [Test]
    public void Test_RemoveOccurrences_RemovesAllOccurrencesWithSpaceInIt()
    {
        // Arrange
        string toRemove = "brown fox";  
        string input = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick jumps over the lazy dog";

        // Act
        string result = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("Green bear")]
    [TestCase("")]
    public void Test_RemoveOccurrences_ReturOriginalTextIfNoOccurrences(string toRemove)
    {
        // Arrange
        //string toRemove = "Green bear";
        string input = "The quick brown fox jumps over the lazy dog";

        // Act
        string result = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.That(result, Is.EqualTo(input));
    }

    [Test]
    public void Test_RemoveOccurrences_ReturEmptyStringIfInputIsEmpty()
    {
        // Arrange
        string toRemove = "Green bear";
        string input = string.Empty;

        // Act
        string result = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesAllOccurrencesWithSingleCharacterString()
    {
        // Arrange
        string toRemove = "o";
        string input = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick brwn fx jumps ver the lazy dg";

        // Act
        string result = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
