using NUnit.Framework;

using System;
using System.Collections.Generic;
using static NUnit.Framework.Constraints.Tolerance;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new Exceptions();
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "Hello, world!";
        string expected = "!dlrow ,olleH";

        // Act
        string result = _exceptions.ArgumentNullReverse(input);


        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;
        string expectedMessage = "String cannot be null.";

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);

        // допълнителна логика за тестване на съобщението в грешката
        try
        {
            // Act -> throw Exception
            _exceptions.ArgumentNullReverse(input);
        }
        catch (ArgumentNullException ex)
        {
            Assert.That(ex.Message, Does.Contain(expectedMessage));
        }
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        // Arrange
        decimal totalPrice = 200;
        decimal discount = 10;
        decimal expected = 180;

        // Act
        decimal result = _exceptions.ArgumentCalculateDiscount(totalPrice, discount);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 200;
        decimal discount = -10;

        // Act & Assert
        Assert.That(() => _exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);

        // нов синтаксис - логика за тестване на съобщението в грешката
        try
        {
            _exceptions.ArgumentCalculateDiscount(totalPrice, discount);
        }
        catch (ArgumentException ex)
        {
            Assert.That(ex.Message, Does.Contain("Discount must be between 0 and 100."));
        }
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100;
        decimal discount = 110;

        // Act & Assert
        // стар синтаксис (Assert.Throws<>) - логика за тестване на съобщението в грешката
        ArgumentException ex = Assert.Throws<ArgumentException>(() => _exceptions.ArgumentCalculateDiscount(totalPrice, discount));

        Assert.That(ex.Message, Does.Contain("Discount must be between 0 and 100."));
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        // Arrange
        int[] input = new int[] { 10, 20, 30, 40 };
        int index = 2;
        int expected = 30;

        // Act
        int result = _exceptions.IndexOutOfRangeGetElement(input, index);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = new int[] { 10, 20, 30, 40 };
        int index = -2;

        // Act & Assert
        Assert.That(() => _exceptions.IndexOutOfRangeGetElement(input, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 10, 20, 30, 40, 50 };
        int index = input.Length;

        // Act & Assert
        Assert.That(() => _exceptions.IndexOutOfRangeGetElement(input, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 10, 20, 30, 40, 50 };
        int index = 10;

        // Act & Assert -> OLD SINTAX
        Assert.Throws<IndexOutOfRangeException>(() => _exceptions.IndexOutOfRangeGetElement(input, index));
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        // Arrange
        bool input = true;
        string expected = "User logged in.";

        // Act
        string result = _exceptions.InvalidOperationPerformSecureOperation(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        // Arrange
        bool input = false;

        // Act & Assert
        Assert.That(() => this._exceptions.InvalidOperationPerformSecureOperation(input), Throws.InstanceOf<InvalidOperationException>());   
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        // Arrange
        string input = "42";
        int expected = 42;

        // Act
        int result = _exceptions.FormatExceptionParseInt(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        // Arrange
        string input = "five";

        // Act & Assert
        Assert.That(() => _exceptions.FormatExceptionParseInt(input), Throws.InstanceOf<FormatException>());
        Assert.That(() => _exceptions.FormatExceptionParseInt("5.5"), Throws.InstanceOf<FormatException>());
        Assert.That(() => _exceptions.FormatExceptionParseInt("5 a"), Throws.InstanceOf<FormatException>());
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>();
        input.Add("one", 1);
        input.Add("two", 2);
        input.Add("three", 3);
        input.Add("four", 4);

        string key = "two";
        int expected = 2;

        // Act
        int result = _exceptions.KeyNotFoundFindValueByKey(input, key);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>();
        input.Add("one", 1);
        input.Add("two", 2);
        input.Add("three", 3);
        input.Add("four", 4);

        string key = "five";

        // Act & Assert
        Assert.That(() => _exceptions.KeyNotFoundFindValueByKey(input, key), Throws.InstanceOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        // Arrange
        int a = 5;
        int b = 6;
        int expected = 11;

        // Act
        int result = _exceptions.OverflowAddNumbers(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MaxValue;
        int b = 1;

        // Act & Assert
        Assert.That(() => _exceptions.OverflowAddNumbers(a, b), Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MinValue;
        int b = -1;

        // Act & Assert
        Assert.That(() => _exceptions.OverflowAddNumbers(a, b), Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        // Arrange
        int dividend = 13;
        int divisor = 3;
        int expected = 4;

        // Act
        int result = _exceptions.DivideByZeroDivideNumbers(dividend, divisor);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int dividend = 13;
        int divisor = 0;

        // Act & Assert
        Assert.That(() => _exceptions.DivideByZeroDivideNumbers(dividend, divisor), Throws.InstanceOf<DivideByZeroException>());
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // Arrange
        int[] input = new int[] { 1, 2, 3, 4, 5 };
        int index = 2;
        int expectedSum = 15;

        // Act
        int result = _exceptions.SumCollectionElements(input, index);

        // Assert
        Assert.That(result, Is.EqualTo(expectedSum));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        int[] input = null;
        int index = 2;

        // Act & Assert
        Assert.That(() => _exceptions.SumCollectionElements(input, index), Throws.ArgumentNullException);
    }

    [TestCase(-1)]
    [TestCase(5)]
    [TestCase(10)]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException(int index)
    {
        // Arrange
        int[] input = new int[] { 1, 2, 3, 4, 5 };

        // Act & Assert
        Assert.That(() => _exceptions.SumCollectionElements(input, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>();
        input.Add("one", "1");
        input.Add("two", "2");
        input.Add("three", "3");
        input.Add("four", "4");

        string key = "four";
        int expected = 4;

        // Act
        int result = _exceptions.GetElementAsNumber(input, key);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>();
        input.Add("one", "1");
        input.Add("two", "2");
        input.Add("three", "3");
        input.Add("four", "4");

        string key = "five";

        // Act & Assert -> OLD SINTAX
        var ex = Assert.Throws<KeyNotFoundException>(() => _exceptions.GetElementAsNumber(input, key));
        Assert.AreEqual("Key not found in the dictionary.", ex.Message);
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>();
        input.Add("one", "1a");
        input.Add("two", "2b");
        input.Add("three", "3.5");
        input.Add("four", "4#");

        string key = "four";

        // Act & Assert -> OLD SINTAX
        var ex = Assert.Throws<FormatException>(() => _exceptions.GetElementAsNumber(input, key));
        Assert.AreEqual("Can't parse string.", ex.Message);
    }
}
