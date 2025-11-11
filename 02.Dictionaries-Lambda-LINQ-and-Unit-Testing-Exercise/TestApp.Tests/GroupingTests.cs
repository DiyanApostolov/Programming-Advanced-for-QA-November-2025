using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Tests;

public class GroupingTests
{
    // TODO: finish test
    [Test]
    public void Test_GroupNumbers_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> input = new List<int>(); // Empty list

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GroupNumbers_WithEvenAndOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int>() { 2, 42, 5, 8, 7, 12 };

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Even numbers: 2, 42, 8, 12");
        sb.AppendLine("Odd numbers: 5, 7");
        string expected = sb.ToString().TrimEnd();

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GroupNumbers_WithOnlyEvenNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int>() { 2, 42, 8, 20, 12 };

        string expected = "Even numbers: 2, 42, 8, 20, 12";

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_GroupNumbers_WithOnlyOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int>() { 7, 13, 5, 39 };

        string expected = "Odd numbers: 7, 13, 5, 39";

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_GroupNumbers_WithNegativeNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int>() { -2, -42, 5, -8, -7, 12 };

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Even numbers: -2, -42, -8, 12");
        sb.AppendLine("Odd numbers: 5, -7");
        string expected = sb.ToString().TrimEnd();

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
