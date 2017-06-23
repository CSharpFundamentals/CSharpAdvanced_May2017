using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class AshesOfRoses
{
    public static void Main()
    {
        var rgx = new Regex(@"^Grow <(?<region>[A-Z][a-z]+)> <(?<color>[a-zA-Z\d]+)> (?<amount>\d+)$");
        var regionsInfo = new Dictionary<string, Dictionary<string, long>>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "Icarus, Ignite!")
        {
            var match = rgx.Match(inputLine);
            if (!match.Success)
            {
                continue;
            }

            var regionName = match.Groups["region"].Value;
            var colorName = match.Groups["color"].Value;
            var amount = int.Parse(match.Groups["amount"].Value);

            if (!regionsInfo.ContainsKey(regionName))
            {
                regionsInfo[regionName] = new Dictionary<string, long>();
            }

            if (!regionsInfo[regionName].ContainsKey(colorName))
            {
                regionsInfo[regionName].Add(colorName, 0);
            }

            regionsInfo[regionName][colorName] += amount;
        }

        foreach (var region in regionsInfo
            .OrderByDescending(rg => rg.Value.Sum(cl => cl.Value))
            .ThenBy(rg => rg.Key))
        {
            Console.WriteLine(region.Key);
            foreach (var color in region.Value.OrderBy(cl => cl.Value).ThenBy(cl => cl.Key))
            {
                Console.WriteLine($"*--{color.Key} | {color.Value}");
            }
        }
    }
}