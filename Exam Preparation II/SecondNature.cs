using System;
using System.Collections.Generic;
using System.Linq;

public class SecondNature
{
    public static void Main()
    {
        var flowers = new Stack<int>(Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .Reverse());
        var buckets = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
        var secondNature = new Queue<int>();
        var currentFlower = 0;

        while (flowers.Count > 0 && buckets.Count > 0)
        {
            currentFlower = flowers.Pop();

            while (buckets.Count > 0 && currentFlower - buckets.Peek() > 0)
                currentFlower -= buckets.Pop();

            var remainder = 0;
            if (buckets.Count > 0)
            {
                if (currentFlower - buckets.Peek() < 0)
                {
                    remainder = buckets.Pop() - currentFlower;
                }
                else
                {
                    secondNature.Enqueue(currentFlower);
                    buckets.Pop();
                }
                currentFlower = -1;

                if (buckets.Count > 0)
                    buckets.Push(buckets.Pop() + remainder);
                else if (remainder > 0)
                    buckets.Push(remainder);
            }

            if (currentFlower > 0)
            {
                flowers.Push(currentFlower);
            }
        }

        if (flowers.Count > 0)
            Console.WriteLine(string.Join(" ", flowers));

        if (buckets.Count > 0)
            Console.WriteLine(string.Join(" ", buckets));

        if (secondNature.Count > 0)
            Console.WriteLine(string.Join(" ", secondNature));
        else
            Console.WriteLine("None");
    }
}