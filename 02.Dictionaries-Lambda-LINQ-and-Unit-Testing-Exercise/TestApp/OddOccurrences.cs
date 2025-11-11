using System.Collections.Generic;
using System.Text;

namespace TestApp;

public class OddOccurrences
{
    public static string FindOdd(string[] input)
    {
        // input [ "Hello", "HELLO", "HeLLo", "hi", "hi", "Dido" ]
        Dictionary<string, int> oddWords = new();

        foreach (string word in input)
        {
            string wordLower = word.ToLower();

            oddWords.TryAdd(wordLower, 0);
            oddWords[wordLower]++;
        }

        // Key (думата) -> Value (брой)
        // "hello" -> 3
        // "hi" -> 2
        // "dido" -> 1

        StringBuilder sb = new();
        foreach (KeyValuePair<string, int> word in oddWords)
        {
            if (word.Value % 2 != 0) // хваща само думите, който са срещнати нечетен брой пъти
            {
                sb.Append($"{word.Key} ");
            }
        }

        // "hello dido"

        return sb.ToString().Trim();
    }
}
