using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsBygroup
{
    public class StudentsByGroup
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
                .Where(arr => arr[2] == "2")
                .OrderBy(arr => arr[0])
                .ToList()
                .ForEach(pr => Console.WriteLine($"{pr[0]} {pr[1]}"));
        }
    }
}
