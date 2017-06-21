using System;
using System.Collections.Generic;
using System.Linq;

public class CubicAssault
{
    public static int ConvertThreshold = 1_000_000;

    public static void Main()
    {
        var meteorNames = new List<string> {"Green", "Red", "Black"};
        var regions = new Dictionary<string, Dictionary<string, long>>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "Count em all")
        {
            var regionTokens = inputLine.Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
            var regionName = regionTokens[0];
            var meteorType = regionTokens[1];
            var meteorCount = int.Parse(regionTokens[2]);

            if (!regions.ContainsKey(regionName))
            {
                regions[regionName] = new Dictionary<string, long> {{"Green", 0}, {"Red", 0}, {"Black", 0}};
            }

            regions[regionName][meteorType] += meteorCount;

            for (var i = 0; i < meteorNames.Count - 1; i++)
            {
                var nextTypeCout = regions[regionName][meteorNames[i]] / ConvertThreshold;
                if (nextTypeCout > 0)
                {
                    regions[regionName][meteorNames[i + 1]] += nextTypeCout;
                    regions[regionName][meteorNames[i]] %= ConvertThreshold;
                }
            }
        }

        var orderedRegions = regions
            .OrderByDescending(r => r.Value["Black"])
            .ThenBy(r => r.Key.Length)
            .ThenBy(r => r.Key)
            .ToDictionary(r => r.Key, r => r.Value);

        foreach (var region in orderedRegions)
        {
            Console.WriteLine(region.Key);
            foreach (var meteorType in region.Value
                .OrderByDescending(m => m.Value)
                .ThenBy(m => m.Key))
            {
                Console.WriteLine($"-> {meteorType.Key} : {meteorType.Value}");
            }
        }
    }
}