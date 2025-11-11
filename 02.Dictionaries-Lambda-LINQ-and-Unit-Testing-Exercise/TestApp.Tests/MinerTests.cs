using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class MinerTests
{
    [Test]
    public void Test_Mine_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Mine_WithMixedCaseResources_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] input = new string[] { "Gold 10", "SILVER 20" };

        string expected = "gold -> 10" +
                          Environment.NewLine +
                          "silver -> 20";

        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Mine_WithDifferentResources_ShouldReturnResourceCounts()
    {
        // Arrange
        string[] input = new string[] { "Gold 10", "Silver 20", "GOLD 20", "Copper 15", "SILver 15", "gold 0" };

        string expected = "gold -> 30" +
                          Environment.NewLine +
                          "silver -> 35" +
                          Environment.NewLine +
                          "copper -> 15";

        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
