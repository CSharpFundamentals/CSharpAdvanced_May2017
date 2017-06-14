using System;
using System.Collections.Generic;
using System.Linq;

public class ListOfPredicates
{
    private static int intTest = 0;

    public static void Main()
    {
        var border = int.Parse(Console.ReadLine());
        var dividers = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        Func<int, int, bool> filter = (n, d) => n % d == 0;

        SelectAndPrint(border, dividers, filter);
    }

    private static void SelectAndPrint(int border, int[] dividers, Func<int, int, bool> filter)
    {
        var result = new List<int>();
        for (var i = 1; i <= border; i++)
        {
            var hasPassed = true;

            foreach (var divider in dividers)
            {
                Predicate<int> predFilter = n => i % n == 0;
                if (!predFilter(divider))
                {
                    hasPassed = false;
                    break;
                }
            }

            if (hasPassed)
                result.Add(i);
        }

        Console.WriteLine(string.Join(" ", result));
    }
}