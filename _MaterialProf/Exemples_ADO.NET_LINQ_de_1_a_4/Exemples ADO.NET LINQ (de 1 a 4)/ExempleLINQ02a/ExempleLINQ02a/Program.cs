using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleLINQ02a
{
    public class Student
    {

        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            // LINQ Method Syntax to find out teenager students
            var teenAgerStudent1 = studentList.Where(s => s.Age > 12 && s.Age < 20);

            Console.WriteLine("Teen age Students:");

            foreach (Student std in teenAgerStudent1)
            {
                Console.WriteLine(std.StudentName);
            }
            Console.WriteLine();

            Func<Student, bool> isStudentTeenAger = s => s.Age > 12 && s.Age < 20;

            // LINQ Method Syntaxe to find out teenager students
            var teenAgerStudent2 = studentList.Where(isStudentTeenAger);

            Console.WriteLine("Teen age Students:");

            foreach (Student std in teenAgerStudent2)
            {
                Console.WriteLine(std.StudentName);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
