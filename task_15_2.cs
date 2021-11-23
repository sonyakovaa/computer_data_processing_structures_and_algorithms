using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace practice_15
{
    struct Student
    {
        public string surname, name, patronymic;
        public int group;
        public int [] assessments { get; set; }

        public Student(string surname, string name, string patronymic, int group, int [] assessments)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.group = group;
            this.assessments = new int[3];

            for (int i = 0; i < 3; i++)
            {
                this.assessments[i] = assessments[i];
            }
        }

        public string getStudent()
        {
            string s = surname + " " + name + " " + patronymic + " " + group + " " + assessments[0] + " " + assessments[1] + " " + assessments[2];
            return s;
        }
    }

    class Program
    {
        static public List<Student> inputStudents()
        {
            using (StreamReader file_input = new StreamReader("C:/Users/sonya/source/repos/practice_15/practice_15/input.txt"))
            {
                List<Student> inputStudents = new List<Student>();

                while (file_input.Peek() != -1)
                {
                    string[] s = file_input.ReadLine().Split(' ');
                    int[] marks = { int.Parse(s[s.Length - 1]), int.Parse(s[s.Length - 2]), int.Parse(s[s.Length - 3]) };
                    Student copyStudent = new Student(s[0], s[1], s[2], int.Parse(s[3]), marks);
                    inputStudents.Add(copyStudent);
                }

                return inputStudents;
            }
        }

        static void Main(string[] args)
        {
            List<Student> listStudents = inputStudents();

            // LINQ-запрос
            /* var sortedStudents =
                from item in listStudents
                where item.assessments[0] < 3 || item.assessments[1] < 3 || item.assessments[2] < 3
                orderby item.@group
                select item;
            */

            // Метод расширений
            var sortedStudents = listStudents.Where(item => item.assessments[0] < 3 || item.assessments[1] < 3 || item.assessments[2] < 3)
                .OrderBy(item => item.group).Select(item => item);

            using (StreamWriter fileOut = new StreamWriter("C:/Users/sonya/source/repos/practice_15/practice_15/output.txt"))
            {
                foreach (Student item in sortedStudents)
                {
                    fileOut.WriteLine(item.getStudent());
                }
            }
        }
    }
}
