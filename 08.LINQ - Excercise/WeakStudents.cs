using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakStudents
{
    public class WeakStudents
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
                .Where(arr => arr.Skip(2).Count(mark => int.Parse(mark) <= 3) >= 2)
                .ToList()
                .ForEach(arr => Console.WriteLine($"{arr[0]} {arr[1]}"));
        }
    }
}
