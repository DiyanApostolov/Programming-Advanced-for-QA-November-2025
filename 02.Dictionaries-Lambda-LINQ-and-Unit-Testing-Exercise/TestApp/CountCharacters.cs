using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp;

public class CountCharacters
{
    public static string Count(List<string> input)
    {
        // List -> "hi", "ha"
        Dictionary<char, int> charCount = input.SelectMany(s => s) // 'h', 'i', 'h', 'a'
            .GroupBy(c => c)
            .ToDictionary(g => g.Key, g => g.Count());
        // charCount -> Key (символ), Value (брой от символа)
        // 'h' -> 2
        // 'i' -> 1
        // 'a' -> 1

        StringBuilder sb = new();
        foreach (KeyValuePair<char, int> pair in charCount)
        {
            sb.AppendLine($"{pair.Key} -> {pair.Value}");
        }

        // "h -> 2
        //  i -> 1
        //  a -> 1"

        return sb.ToString().Trim();
    }
}
