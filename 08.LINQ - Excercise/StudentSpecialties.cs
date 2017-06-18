using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSpecialties
{
    class Program
    {
        static void Main()
        {
            var specs = new List<StudentSpecialty>();
            var students = new List<Student>();
            string input;

            while ((input = Console.ReadLine()) != "Students:")
            {
                var tokens = input.Split(' ');
                specs.Add(new StudentSpecialty(tokens[0] + " " + tokens[1], int.Parse(tokens[2])));
            }

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(' ');
                students.Add(new Student(tokens[1] + " " + tokens[2], int.Parse(tokens[0])));
            }

            specs.Join(students, sp => sp.FacultyNumber, st => st.FacultyNumber, (sp, st) => new
                {
                    Name = st.StudentName,
                    FacNum = sp.FacultyNumber,
                    Spec = sp.SpecName
                })
                .OrderBy(res => res.Name)
                .ToList()
                .ForEach(res => Console.WriteLine($"{res.Name} {res.FacNum} {res.Spec}"));
        }
    }

    public class Student
    {
        public string StudentName { get; set; }
        public int FacultyNumber { get; set; }

        public Student(string name, int num)
        {
            this.StudentName = name;
            this.FacultyNumber = num;
        }
    }

    public class StudentSpecialty
    {
        public string SpecName { get; set; }
        public int FacultyNumber { get; set; }

        public StudentSpecialty(string name, int num)
        {
            this.SpecName = name;
            this.FacultyNumber = num;
        }
    }
}
