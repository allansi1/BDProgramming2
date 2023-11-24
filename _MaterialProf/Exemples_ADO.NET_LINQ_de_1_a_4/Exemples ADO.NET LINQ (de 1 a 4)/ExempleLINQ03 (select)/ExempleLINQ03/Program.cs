using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleLINQ03
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

            // returns collection of strings (StudentName) - Query syntax 
            var selectResult1 = from s in studentList
                               select s.StudentName;

            foreach (var name in selectResult1)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            // returns collection of anonymous objects with Name and Age property - Query syntax 
            var selectResult2 = from s in studentList
                               select new { Name = s.StudentName, Age= s.Age };

            // iterate selectResult2
            foreach (var item in selectResult2)
            {
                Console.WriteLine("Student Name: {0}, Age: {1}", item.Name, item.Age);
            }
            Console.WriteLine();


            // returns collection of strings (StudentName) - Method syntax 
            var selectResult3 = studentList.Select(s=> s.StudentName);

            // iterate selectResult3
            foreach (var name in selectResult3)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            // returns collection of anonymous objects with Name and Age property - Method syntax 
            var selectResult4 = studentList.Select(s => new {Name = s.StudentName, Age = s.Age});

            // iterate selectResult4
            foreach (var item in selectResult4)
            {
                Console.WriteLine("Student Name: {0}, Age: {1}", item.Name, item.Age);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
 }
 

