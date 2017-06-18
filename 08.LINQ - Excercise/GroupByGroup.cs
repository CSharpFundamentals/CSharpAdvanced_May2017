using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupByGroup
{
    public class GroupByGroup
    {
        public static void Main()
        {
            var students = new List<Person>();
            var inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                var tokens = inputLine.Split(' ');
                students.Add(new Person(tokens[0] + " " + tokens[1], int.Parse(tokens[2])));
                inputLine = Console.ReadLine();
            }

            var grouped = students
                .GroupBy(pr => pr.Group)
                .OrderBy(gr => gr.Key);

            foreach (var group in grouped)
            {
                Console.Write(group.Key + " - ");
                var sb = new StringBuilder();
                foreach (var person in group)
                {
                    sb.Append(person.Name).Append(", ");
                }
                sb.Length -= 2;
                Console.WriteLine(sb);
            }

        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Group { get; set; }

        public Person(string name, int group)
        {
            this.Name = name;
            this.Group = group;
        }
    }
}
