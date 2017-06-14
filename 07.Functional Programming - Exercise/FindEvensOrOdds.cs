using System;
using System.Collections.Generic;
using System.Linq;

public class FindEvensOrOdds
{
    public static void Main()
    {
        var rangeBorders = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        var command = Console.ReadLine();

        var numbers = Enumerable.Range(rangeBorders[0], rangeBorders[1] - rangeBorders[0] + 1);
        Predicate<int> isEven = n => n % 2 == 0;
        PrintChoosenNums(numbers, command, isEven);
    }

    private static void PrintChoosenNums(IEnumerable<int> numbers, string command, Predicate<int> isEven)
    {
        var result = new List<int>();
        foreach (var number in numbers)
            if (isEven(number) && command == "even")
                result.Add(number);
            else if (!isEven(number) && command == "odd")
                result.Add(number);

        Console.WriteLine(string.Join(" ", result));
    }
}