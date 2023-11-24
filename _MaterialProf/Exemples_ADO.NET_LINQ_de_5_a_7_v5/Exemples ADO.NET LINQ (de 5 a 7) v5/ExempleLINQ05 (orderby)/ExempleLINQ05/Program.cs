using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleLINQ05
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
            List<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21} ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18} ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15}
            };

            // LINQ Query Syntax to find out teenager students
            var teenAgerStudent1 = from s in studentList
                                   where s.Age > 12 && s.Age < 20
                                   orderby s.Age
                                   //orderby  s.Age descending
                                   select new { s.StudentName, s.Age };
            Console.WriteLine("Teen age Students:");

            foreach (var item in teenAgerStudent1)
            {
                Console.WriteLine("Student Name: {0}, Age: {1}", item.StudentName, item.Age);
            }
            Console.WriteLine();

            // LINQ Method Syntax to find out teenager students 
            var teenAgerStudent2 = studentList.Where(s => s.Age > 12 && s.Age < 20)
                                              .OrderBy(s => s.Age)
                                              //.OrderByDescending(s=>s.Age)
                                              .Select(s => new { s.StudentName, s.Age });

            Console.WriteLine("Teen age Students:");

            foreach (var item in teenAgerStudent2)
            {
                Console.WriteLine("Student Name: {0}, Age: {1}", item.StudentName, item.Age);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
