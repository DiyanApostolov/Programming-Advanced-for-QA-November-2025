using System.Collections.Generic;
using System.Text;

namespace TestApp;

public class CountRealNumbers
{
    public static string Count(int[] nums)
    {
        // input -> [ 2, 5, 2, 1, 8, 5 ]
        SortedDictionary<int, int> count = new();

        foreach (int num in nums)
        {
            count.TryAdd(num, 0);
            count[num]++;
        }
        // Key (число), Value (бройка от числото)
        // 1 -> 1
        // 2 -> 2
        // 5 -> 2
        // 8 -> 1

        StringBuilder sb = new();
        foreach (KeyValuePair<int, int> pair in count)
        {
            sb.AppendLine($"{pair.Key} -> {pair.Value}");
        }

        // "1 -> 1
        // 2 -> 2
        // 5 -> 2
        // 8 -> 1"

        return sb.ToString().Trim();
    }
}
