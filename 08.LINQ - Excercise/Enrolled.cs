using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolled
{
    public class Enrolled
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
                .Where(arr => arr[0].EndsWith("14") || arr[0].EndsWith("15"))
                .Select(arr => arr.Skip(1))
                .ToList()
                .ForEach(x => Console.WriteLine(string.Join(" ", x)));
        }
    }
}
