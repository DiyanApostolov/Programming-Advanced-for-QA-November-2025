using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp;

public class Grouping
{
    public static string GroupNumbers(List<int> nums)
    {
        // input List<int> { 2, 42, 5, 8, 7, 12 }
        Dictionary<string, List<int>> grouped = nums
            .GroupBy(n => n % 2 == 0 ? "Even" : "Odd")
            .ToDictionary(g => g.Key, g => g.ToList());

        // Key (string) -> Value (List<int>)
        // "Even" -> List<int> { 2, 42, 8, 12 }
        // "Odd" -> List<int> { 5, 7 }

        StringBuilder sb = new();
        foreach (KeyValuePair<string, List<int>> group in grouped)
        {
            sb.AppendLine($"{group.Key} numbers: {string.Join(", ", group.Value)}");
        }

        // "Even numbers: 2, 42, 8, 12
        // Odd numbers: 5, 7"

        return sb.ToString().Trim();
    }
}
