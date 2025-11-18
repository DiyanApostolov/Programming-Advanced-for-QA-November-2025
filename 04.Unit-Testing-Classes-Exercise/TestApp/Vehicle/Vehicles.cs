using System.Linq;
using System.Text;

namespace TestApp.Vehicle;

public class Vehicles
{
    public string AddAndGetCatalogue(string[] vehicles)
    {
        Catalogue catalogue = new();
        foreach (string vehicle in vehicles)
        {
            string[] data = vehicle.Split("/");

            string type = data[0];
            string brand = data[1];
            string model = data[2];
            int power = int.Parse(data[3]);

            if (type == "Truck")
            {
                //вдигаме си нова инсанция на класа Truck
                Truck newTruck = new()
                {
                    Brand = brand,
                    Model = model,
                    Weight = power
                };

                // добавям си камиона в каталога в списъка с камиони
                catalogue.TruckList.Add(newTruck);
            }
            else
            {
                //вдигаме си нова инсанция на класа Car
                Car newCar = new Car()
                {
                    Brand = brand,
                    Model = model,
                    HorsePower = power
                };

                // добавям си клата в каталога в списъка с коли
                catalogue.CarList.Add(newCar);
            }
        }

        StringBuilder sb = new();
        sb.AppendLine("Cars:");
        foreach (Car car in catalogue.CarList.OrderBy(car => car.Brand))
        {
            sb.AppendLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
        }

        sb.AppendLine("Trucks:");
        foreach (Truck truck in catalogue.TruckList.OrderBy(truck => truck.Brand))
        {
            sb.AppendLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
        }

        return sb.ToString().Trim();
    }
}
