using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;

public class InfernoIII
{
    private static List<int> gems;
    public static void Main()
    {
        gems = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();
        var command = Console.ReadLine();
        var commands = new Dictionary<string, Dictionary<int, Predicate<int>>>();

        while (command != "Forge")
        {
            var tokens = command.Split(';');
            var action = tokens[0];
            var filterType = tokens[1];
            var filterParam = int.Parse(tokens[2]);
            
            if (action == "Exclude")
            {
                var filterPred = GetPredicate(filterType, filterParam);
                if (!commands.ContainsKey(filterType))
                {
                    commands[filterType] = new Dictionary<int, Predicate<int>>();
                }

                commands[filterType].Add(filterParam, filterPred);
            }
            else
            {
                commands[filterType].Remove(filterParam);
            }

            command = Console.ReadLine();
        }

        gems = Filter(commands);
        Console.WriteLine(string.Join(" ", gems));
    }

    private static List<int> Filter(Dictionary<string, Dictionary<int, Predicate<int>>> filters)
    {
        var result = new List<int>();
        for(var i = 0; i < gems.Count; i++)
        {
            var isFiltered = false;
            foreach (var filter in filters)
            {
                foreach (var predicate in filter.Value)
                {
                    if (predicate.Value(i))
                    {
                        isFiltered = true;
                        break;
                    }
                }
            }
            if (!isFiltered)
            {
                result.Add(gems[i]);
            }
        }

        return result;
    }

    private static Predicate<int> GetPredicate(string filterType, int filterParam)
    {
        switch (filterType)
        {
            case "Sum Left":
                return  i => (i <= 0 ? 0 : gems[i - 1]) + gems[i] == filterParam;
            case "Sum Right":
                return i => gems[i] + (i >= gems.Count -1 ? 0 : gems[i + 1]) == filterParam;
            case "Sum Left Right":
                return i => (i <= 0 ? 0 : gems[i - 1]) + gems[i] + (i >= gems.Count -1 ? 0 : gems[i + 1]) == filterParam;
        }

        return null;
    }
}