using Indexer.Models;

namespace Indexer;

internal class Program
{
    static void Main()
    {
        int[] arr = { 1, 5, 7, 9, 5, 8, 10, 5, 2 };
        ListInt List = new ListInt(arr.Length);
        for (int i = 0; i < arr.Length; i++)
        {
            List[i] = arr[i];
        }

        List.Add(12);
        List.Add([1, 2, 3]);
        List.Insert(99, 4);
        List.Pop();
        Console.WriteLine(List.Contains(91));
        Console.WriteLine(List.Sum());
        Console.WriteLine(List.IndexOf(5));
        Console.WriteLine(List.LastIndexOf(5));
        Console.WriteLine(List.Average());
        Console.WriteLine(List.ToString());
    }
}