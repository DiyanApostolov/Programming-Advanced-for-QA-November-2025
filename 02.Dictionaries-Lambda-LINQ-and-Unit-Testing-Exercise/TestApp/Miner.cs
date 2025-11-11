using System.Collections.Generic;
using System.Text;

namespace TestApp;

public class Miner
{
    public static string Mine(params string[] input)
    {
        // input -> [ "Gold 10", "Silver 20", "GOLD 20" ]
        Dictionary<string, int> resources = new();

        foreach (string s in input)
        {
            string[] split = s.Split(); // "Gold 10" -> [ "Gold", "10" ]

            resources.TryAdd(split[0].ToLower(), 0);
            resources[split[0].ToLower()] += int.Parse(split[1]);
        }

        // Key (ресурса) -> Value (количество)
        // "gold" -> 30
        // "silver" -> 10

        StringBuilder sb = new();
        foreach (KeyValuePair<string, int> pair in resources)
        {
            sb.AppendLine($"{pair.Key} -> {pair.Value}");
        }

        // "gold -> 30
        // silver" -> 10"

        return sb.ToString().Trim();
    }
}
