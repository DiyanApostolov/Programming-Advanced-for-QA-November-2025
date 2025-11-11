using System.Collections.Generic;
using System.Text;

namespace TestApp;

public class Orders
{
    public static string Order(params string[] input)
    {
        // "Apple 2.50 3", "Banana 2.80 2", "Apple 3.2 2"
        Dictionary<string, decimal[]> products = new();

        foreach (string s in input)
        {
            string[] data = s.Split(); //"Apple 2.50 3" -> [ "Apple", "2.50", "3" ]

            string product = data[0];
            decimal price = decimal.Parse(data[1]);
            decimal quantity = decimal.Parse(data[2]);

            products.TryAdd(product, new[] { (decimal)0.0, (decimal)0.0 });
            products[product][1] += quantity; // update (add) quantity
            products[product][0] = price; // set new price
        }

        // "Apple" -> [ 3.20, 5 ]
        // "Banana" -> [ 2.80, 2 ]



        StringBuilder sb = new();
        foreach (KeyValuePair<string, decimal[]> pair in products)
        {
            decimal totalPrice = pair.Value[1] * pair.Value[0];
            sb.AppendLine($"{pair.Key} -> {totalPrice:f2}");
        }

        // "Apple -> 16.00
        // Banana -> 5.60"

        return sb.ToString().Trim();
    }
}
