using NUnit.Framework;

using System;
using System.Text;
using TestApp.Vehicle;

namespace TestApp.UnitTests;

public class VehicleTests
{
    private Vehicles _vehicles;

    [SetUp]
    public void SetUp()
    {
        _vehicles = new Vehicles();
    }

    // TODO: finish test
    [Test]
    public void Test_AddAndGetCatalogue_ReturnsSortedCatalogue()
    {
        // Arrange
        // input vehicle format -> "{type}/{brand}/{model}/{power}"
        string[] input = new string[] { "Truck/Volvo/VNL/500", "Car/Toyota/Camry/150", "Car/Ford/Focus/120", "Truck/Scanina/HW/2000" };

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Cars:");
        sb.AppendLine("Ford: Focus - 120hp");
        sb.AppendLine("Toyota: Camry - 150hp");
        sb.AppendLine("Trucks:");
        sb.AppendLine("Scanina: HW - 2000kg");
        sb.AppendLine("Volvo: VNL - 500kg");

        string expected = sb.ToString().TrimEnd(); 

        // Act
        string result = this._vehicles.AddAndGetCatalogue(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetCatalogue_ReturnsEmptyCatalogue_WhenNoDataGiven()
    {
        // Arrange
        string[] input = Array.Empty<string>();
        string expected = $"Cars:{Environment.NewLine}Trucks:";

        // Act
        string result = this._vehicles.AddAndGetCatalogue(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
