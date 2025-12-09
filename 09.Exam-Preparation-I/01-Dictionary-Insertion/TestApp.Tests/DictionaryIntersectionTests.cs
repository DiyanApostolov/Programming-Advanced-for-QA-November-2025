using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>();
        Dictionary<string, int> dict2 = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        // Arrage
        Dictionary<string, int> dict1 = new Dictionary<string, int>(); // empty dictionary
        Dictionary<string, int> dict2 = new Dictionary<string, int>()
        {
            { "Pesho", 1 },
            { "Gosho", 2}
        };

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        // Arrage
        Dictionary<string, int> dict1 = new Dictionary<string, int>()
        {
            { "Diyan", 1 },
            { "Dimitrichko", 2 }
        }; 

        Dictionary<string, int> dict2 = new Dictionary<string, int>()
        {
            { "Pesho", 1 },
            { "Gosho", 2 }
        };

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        // Arrage
        Dictionary<string, int> dict1 = new Dictionary<string, int>()
        {
            { "Pesho", 1 },
            { "Dimitrichko", 2 },
            { "Mariika", 3}
        };

        Dictionary<string, int> dict2 = new Dictionary<string, int>()
        {
            { "Pesho", 1 },
            { "Gosho", 2},
            { "Stamat", 2 },
            { "Mariika", 5}
        };

        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            { "Pesho", 1 }
        };

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Is.EqualTo(expected));

        // проверяваме дали в резуллтата има ключ "Pesho"
        // и дали result речника има някъде стойност 1
        Assert.That(result, Does.ContainKey("Pesho").And.ContainValue(1));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        // Arrage
        Dictionary<string, int> dict1 = new Dictionary<string, int>()
        {
            { "Diyan", 1 },
            { "Dimitrichko", 2 }
        };

        Dictionary<string, int> dict2 = new Dictionary<string, int>()
        {
            { "Diyan", 3 },
            { "Dimitrichko", 4 }
        };

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Is.Empty);
    }
}
