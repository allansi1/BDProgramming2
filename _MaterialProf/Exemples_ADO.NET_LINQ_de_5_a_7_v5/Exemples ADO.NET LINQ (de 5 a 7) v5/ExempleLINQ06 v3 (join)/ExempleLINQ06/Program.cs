using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleLINQ06
{
    class Department
    {
        public int DepId { get; set; }
        public string DepName { get; set; }
    }

    class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int DeptId { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Department> deptList = new List<Department>()
                                       {
                                           new Department{DepId=1,DepName="Accounting"},
                                           new Department{DepId=2,DepName="Finance"},
                                           new Department{DepId=3,DepName="Sales"}
                                       };

            List<Employee> empList = new List<Employee>()
                                    {
                                        new Employee { EmpId=1,Name = "Anne Tremblay", DeptId=1 },
                                        new Employee { EmpId=2,Name = "Jean Desjardins", DeptId=1 },
                                        new Employee { EmpId=3,Name = "Robert Gagnon", DeptId=2 },
                                        new Employee { EmpId=4,Name = "Louis Benoît", DeptId =2},
                                        new Employee { EmpId=5,Name = "Pierre Lafont"}
                                    };

            //==========================================================================
            // LINQ inner join
            //==========================================================================

            // LINQ inner join - first form - Query syntax
            var resultQ1 = from e in empList
                           join d in deptList
                           on e.DeptId equals d.DepId            // == is not valid here et "equals" n'est pas symmetrique
                           select new { EmployeeName = e.Name, DepartmentName = d.DepName };

            foreach (var item in resultQ1)
            {
                Console.WriteLine(item.EmployeeName + "\t | " + item.DepartmentName);
            }
            Console.WriteLine();

            // LINQ inner join - first form -  Method syntax 
            var resultM1 = empList.Join(deptList, e => e.DeptId, d => d.DepId,
                                       (e, d) => new { EmployeeName = e.Name, DepartmentName = d.DepName });

            foreach (var item in resultM1)
            {
                Console.WriteLine(item.EmployeeName + "\t | " + item.DepartmentName);
            }
            Console.WriteLine();

            // Il y a une deuxième manière de faire le "inner join".
            // Cette deuxième manière est plus facile.

            // LINQ inner join - second form - Query syntax 
            var resultQ2 = from e in empList
                           from d in deptList
                           where e.DeptId == d.DepId
                           select new { EmployeeName = e.Name, DepartmentName = d.DepName };

            foreach (var item in resultQ2)
            {
                Console.WriteLine(item.EmployeeName + "\t | " + item.DepartmentName);
            }
            Console.WriteLine();

            // LINQ inner join - second form - Method syntax 
            var resultM2 = empList.SelectMany(_ => deptList, (x, y) => new { x, y })    // _ c'est un paramètre anonym
                                 .Where(z => z.x.DeptId == z.y.DepId)
                                 .Select(z => new { EmployeeName = z.x.Name, DepartmentName = z.y.DepName });

            foreach (var item in resultM2)
            {
                Console.WriteLine(item.EmployeeName + "\t | " + item.DepartmentName);
            }
            Console.WriteLine();

            //==========================================================================
            // LINQ cross join
            //==========================================================================

            // LINQ cross join - Query syntax 
            var resultQ3 = from e in empList
                           from d in deptList
                           select new { EmployeeName = e.Name, DepartmentName = d.DepName };

            foreach (var item in resultQ3)
            {
                Console.WriteLine(item.EmployeeName + "\t | " + item.DepartmentName);
            }
            Console.WriteLine();

            // LINQ cross join - Method syntax 
            var resultM3 = empList.SelectMany(_ => deptList, (x, y) => new { x, y })     // _ c'est un paramètre anonym
                                 .Select(z => new { EmployeeName = z.x.Name, DepartmentName = z.y.DepName });

            foreach (var item in resultM3)
            {
                Console.WriteLine(item.EmployeeName + "\t | " + item.DepartmentName);
            }
            Console.WriteLine();

            //==========================================================================
            // LINQ group join
            //==========================================================================

            // LINQ group join - first example - Query syntax 
            var resultQ4 = from d in deptList
                           join e in empList
                           on d.DepId equals e.DeptId into empDep
                           select new { DepartmentName = d.DepName, Employees = empDep };

            foreach (var item in resultQ4)
            {
                Console.WriteLine(item.DepartmentName);
                foreach (var emp in item.Employees)
                {
                    Console.WriteLine("---> " + emp.Name);
                }
            }
            Console.WriteLine();

            // LINQ group join - first example - Method syntax 
            var resultM4 = deptList.GroupJoin(empList, d => d.DepId, e => e.DeptId,
                (d, e) => new { DepartmentName = d.DepName, Employees = e });

            foreach (var item in resultM4)
            {
                Console.WriteLine(item.DepartmentName);
                foreach (var emp in item.Employees)
                {
                    Console.WriteLine("---> " + emp.Name);
                }
            }
            Console.WriteLine();

            // LINQ group join - second example - Query syntax 
            var resultQ5 = from d in deptList
                           join e in empList
                           on d.DepId equals e.DeptId into empDep
                           select new
                           {
                               DepartmentName = d.DepName,
                               Employees = from e2 in empDep
                                           orderby e2.Name descending
                                           select e2.Name
                           };

            foreach (var item in resultQ5)
            {
                Console.WriteLine(item.DepartmentName);
                foreach (var empName in item.Employees)
                {
                    Console.WriteLine("---> " + empName);
                }
            }
            Console.WriteLine();

            // LINQ group join - second example - Method syntax 
            var resultM5 = deptList.GroupJoin(empList, d => d.DepId, e => e.DeptId,
               (d, e) => new { DepartmentName = d.DepName, Employees = e.OrderByDescending(s => s.Name).Select(s => s.Name) });

            foreach (var item in resultM5)
            {
                Console.WriteLine(item.DepartmentName);
                foreach (var empName in item.Employees)
                {
                    Console.WriteLine("---> " + empName);
                }
            }
            Console.WriteLine();

            //==========================================================================
            // LINQ Left join
            //==========================================================================

            // LINQ left join - first example - Query syntax
            var resultQ6 = from e in empList
                           join d in deptList
                           on e.DeptId equals d.DepId            // == is not valid here et "equals" n'est pas symmetrique
                           into depEmp
                           from dd in depEmp.DefaultIfEmpty(new Department())
                           select new { EmployeeName = e.Name, DepartmentName = dd.DepName };

            foreach (var item in resultQ6)
            {
                Console.WriteLine(item.EmployeeName + "\t | " + item.DepartmentName);
            }
            Console.WriteLine();

            // LINQ left join - first example - Method syntax 
            var resultM6 = empList.GroupJoin(deptList, e => e.DeptId, d => d.DepId,
                                       (e, d) => new { e.Name, d })
                                       .SelectMany(z => z.d.DefaultIfEmpty(new Department()),
                                       (z, dd) => new { EmployeeName = z.Name, DepartmentName = dd.DepName });

            foreach (var item in resultM6)
            {
                Console.WriteLine(item.EmployeeName + "\t | " + item.DepartmentName);
            }
            Console.WriteLine();

            // LINQ left join - second example - Query syntax
            var resultQ7 = from e in empList
                           join d in deptList
                           on e.DeptId equals d.DepId            // == is not valid here et "equals" n'est pas symmetrique
                           into depEmp
                           from dd in depEmp.DefaultIfEmpty(null)
                           select new { EmployeeName = e.Name, 
                                        DepartmentName = dd == null ? "No Department" : dd.DepName };

            foreach (var item in resultQ7)
            {
                Console.WriteLine(item.EmployeeName + "\t | " + item.DepartmentName);
            }
            Console.WriteLine();

            // LINQ left join - second example - Method syntax 
            var resultM7 = empList.GroupJoin(deptList, e => e.DeptId, d => d.DepId,
                                       (e, d) => new { e.Name, d })
                                       .SelectMany(z => z.d.DefaultIfEmpty(null),
                                       (z, dd) => new { EmployeeName = z.Name,
                                           DepartmentName = dd == null ? "No Department" : dd.DepName });

            foreach (var item in resultM7)
            {
                Console.WriteLine(item.EmployeeName + "\t | " + item.DepartmentName);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
