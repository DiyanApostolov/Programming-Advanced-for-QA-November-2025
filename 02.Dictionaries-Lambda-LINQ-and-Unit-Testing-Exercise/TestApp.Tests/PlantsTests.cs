using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string result = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        // Arrange
        string[] input = new string[] { "Rose" };

        string expected = $"Plants with 4 letters:"
                          + Environment.NewLine
                          + "Rose";

        // Act
        string result = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        /// Arrange
        string[] input = new string[] { "rose", "aloe", "pothos", "aloe vera", "lavender" };

        string expected = $"Plants with 4 letters:"
                          + Environment.NewLine
                          + "rose"
                          + Environment.NewLine
                          + "aloe"
                          + Environment.NewLine
                          + "Plants with 6 letters:"
                          + Environment.NewLine
                          + "pothos"
                          + Environment.NewLine
                          + "Plants with 8 letters:"
                          + Environment.NewLine
                          + "lavender"
                          + Environment.NewLine
                          + "Plants with 9 letters:"
                          + Environment.NewLine
                          + "aloe vera";

        // Act
        string result = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] input = new string[]
        {
            "Rose", "Aloe", "Pothos", "Aloe Vera", "Lavender"
        };
        string expected = $"Plants with 4 letters:"
                          + Environment.NewLine
                          + "Rose"
                          + Environment.NewLine
                          + "Aloe"
                          + Environment.NewLine
                          + "Plants with 6 letters:"
                          + Environment.NewLine
                          + "Pothos"
                          + Environment.NewLine
                          + "Plants with 8 letters:"
                          + Environment.NewLine
                          + "Lavender"
                          + Environment.NewLine
                          + "Plants with 9 letters:"
                          + Environment.NewLine
                          + "Aloe Vera";

        // Act
        string result = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
