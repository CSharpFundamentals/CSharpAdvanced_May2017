using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FilterBtPhone
{
    public class FilterByPhone
    {
        public static void Main()
        {
            var group = new List<string[]>();
            var inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                group.Add(inputLine.Split(' '));
                inputLine = Console.ReadLine();
            }

            group
                .Where(arr => arr[2].StartsWith("02") || arr[2].StartsWith("+3592"))
                //.Where(s => Regex.IsMatch(s[2], @"(^02|\+3592)\d+"))
                .Select(arr => $"{arr[0]} {arr[1]}")
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
