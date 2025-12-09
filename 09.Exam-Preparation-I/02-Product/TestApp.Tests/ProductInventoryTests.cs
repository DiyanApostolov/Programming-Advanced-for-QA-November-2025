using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }
    
    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        // Arrange
        string name = "Keyboard";
        double price = 100.854;
        int quantity = 3;

        string expected = "Product Inventory:"
                        + Environment.NewLine
                        + $"{name} - Price: ${price:f2} - Quantity: {quantity}";

        // Act
        _inventory.AddProduct(name, price, quantity);

        string result = _inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        // Arrange
        string expected = "Product Inventory:";

        // Act
        string result = _inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        // Arrange
        string expected = "Product Inventory:"
                        + Environment.NewLine
                        + $"Laptop - Price: $1250.00 - Quantity: 3"
                        + Environment.NewLine
                        + $"Mouse - Price: $89.50 - Quantity: 5";

        // Act
        _inventory.AddProduct("Laptop", 1250, 3);
        _inventory.AddProduct("Mouse", 89.5, 5);

        string result = _inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        // Assert
        double expected = 0;

        // Act
        double result = _inventory.CalculateTotalValue();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        // Arrange
        double expected = 4397.50;

        // Act
        _inventory.AddProduct("Laptop", 1250, 3);
        _inventory.AddProduct("Mouse", 89.5, 5);
        _inventory.AddProduct("Keyboard", 50, 4);

        double result = _inventory.CalculateTotalValue();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
