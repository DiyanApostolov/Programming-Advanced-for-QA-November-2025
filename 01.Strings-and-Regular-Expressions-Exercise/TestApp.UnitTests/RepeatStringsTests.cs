using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class RepeatStringsTests
{
    [Test]
    public void Test_Repeat_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string result = RepeatStrings.Repeat(input);

        // Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Test_Repeat_SingleInputString_ReturnsRepeatedString()
    {
        // Arrage
        string[] input = new string[] { "hello" };
        string expected = "hellohellohellohellohello";

        // Act
        string result = RepeatStrings.Repeat(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Repeat_MultipleInputStrings_ReturnsConcatenatedRepeatedStrings()
    {
        // Arrage
        string[] input = new string[] { "abc", "Dido", "go" };
        string expected = "abcabcabcDidoDidoDidoDidogogo";

        // Act
        string result = RepeatStrings.Repeat(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // BONUS TEST - ONT FOR JUDGE
    [Test]
    public void Test_Repeat_MultipleSingleCharacterInputStrings_ReturnsConcatenatedRepeatedStrings()
    {
        // Arrage
        string[] input = new string[] { "P", "e", "s", "h", "o" };
        string expected = "Pesho";

        // Act
        string result = RepeatStrings.Repeat(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
