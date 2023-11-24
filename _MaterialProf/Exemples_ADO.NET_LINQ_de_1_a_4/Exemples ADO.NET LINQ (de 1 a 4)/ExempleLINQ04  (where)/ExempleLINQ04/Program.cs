using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleLINQ04
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        public static bool IsTeenAger(Student stud)
        {
            return stud.Age > 12 && stud.Age < 20;
        }

        static void Main(string[] args)
        {
            // Student collection
            List<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            // LINQ Query Syntax to find out teenager students
            var teenAgerStudent1 = from s in studentList
                                  where s.Age > 12 && s.Age < 20
                                  select s;
            Console.WriteLine("Teen age Students:");

            foreach (Student std in teenAgerStudent1)
            {
                Console.WriteLine(std.StudentName);
            }
            Console.WriteLine();

            Func<Student, bool> isStudentTeenAger = s => s.Age > 12 && s.Age < 20;

            // LINQ Query Syntax to find out teenager students - Using the delegate isStudentTeenAger
            var teenAgerStudent2 = from s in studentList
                                   where isStudentTeenAger(s)
                                   select s;
            Console.WriteLine("Teen age Students:");

            foreach (Student std in teenAgerStudent2)
            {
                Console.WriteLine(std.StudentName);
            }
            Console.WriteLine();

            // LINQ Query Syntax to find out teenager students - Using the class method isTeenAger
            var teenAgerStudent3 = from s in studentList
                                   where IsTeenAger(s)
                                   select s;
            Console.WriteLine("Teen age Students:");

            foreach (Student std in teenAgerStudent3)
            {
                Console.WriteLine(std.StudentName);
            }
            Console.WriteLine();

            // LINQ Query Syntax to find out teenager students - Using multiple where
            var teenAgerStudent4 = from s in studentList
                                   where s.Age > 12
                                   where s.Age < 20
                                   select s;
            Console.WriteLine("Teen age Students:");

            foreach (Student std in teenAgerStudent4)
            {
                Console.WriteLine(std.StudentName);
            }
            Console.WriteLine();


            // LINQ Method Syntax to find out teenager students 
            var teenAgerStudent5 = studentList.Where(s => s.Age > 12 && s.Age < 20);

            Console.WriteLine("Teen age Students:");

            foreach (Student std in teenAgerStudent5)
            {
                Console.WriteLine(std.StudentName);
            }
            Console.WriteLine();

            // LINQ Method Syntax to find out teenager students - Using the delegate isStudentTeenAger
            var teenAgerStudent6 = studentList.Where(isStudentTeenAger);

            Console.WriteLine("Teen age Students:");

            foreach (Student std in teenAgerStudent6)
            {
                Console.WriteLine(std.StudentName);
            }
            Console.WriteLine();

            // LINQ Method Syntax to find out teenager students - Using the class method isTeenAger
            var teenAgerStudent7 = studentList.Where(IsTeenAger);

            Console.WriteLine("Teen age Students:");

            foreach (Student std in teenAgerStudent7)
            {
                Console.WriteLine(std.StudentName);
            }
            Console.WriteLine();

            // LINQ Method Syntax to find out teenager students - Using multiple where
            var teenAgerStudent8 = studentList.Where(s => s.Age > 12).Where (s => s.Age < 20);

            Console.WriteLine("Teen age Students:");

            foreach (Student std in teenAgerStudent8)
            {
                Console.WriteLine(std.StudentName);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
