using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Employee Object List

            List<Employee> employees = new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "Nitish",
                    Department = "IT",
                    DepartmentId = 1,
                    Salary = 50000
                },

                new Employee
                {
                    Id = 2,
                    Name = "Athul",
                    Department = "HR",
                    DepartmentId = 2,
                    Salary = 40000
                },

                new Employee
                {
                    Id = 3,
                    Name = "Kavi",
                    Department = "IT",
                    DepartmentId = 1,
                    Salary = 60000
                },

                new Employee
                {
                    Id = 4,
                    Name = "Priya",
                    Department = "Finance",
                    DepartmentId = 3,
                    Salary = 45000
                },

                new Employee
                {
                    Id = 5,
                    Name = "Rahul",
                    Department = "IT",
                    DepartmentId = 1,
                    Salary = 55000
                }
            };

            List<Department> departments =
            new List<Department>()
            {
                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "IT"
                },

                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "HR"
                },

                new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "Finance"
                }
            };

            // Task 2: Filtering

            Console.WriteLine("===== FILTERING =====");

            var result =
                employees.Where(e => e.Department == "IT");

            foreach (var emp in result)
            {
                Console.WriteLine(emp.Name);
            }

            Console.WriteLine();

            // Task 3: Projection

            Console.WriteLine("===== PROJECTION =====");

            var empNames =
                employees.Select(e => e.Name);

            foreach (var name in empNames)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            // Task 4: Grouping

            Console.WriteLine("===== GROUPING =====");

            var grouped =
                employees.GroupBy(e => e.Department);

            foreach (var group in grouped)
            {
                Console.WriteLine("Department: " + group.Key);

                foreach (var emp in group)
                {
                    Console.WriteLine(emp.Name);
                }

                Console.WriteLine();
            }

            // Task 5: Join

            Console.WriteLine("===== JOIN =====");

            var joinResult =
                from e in employees
                join d in departments
                on e.DepartmentId equals d.DepartmentId
                select new
                {
                    EmployeeName = e.Name,
                    DepartmentName = d.DepartmentName
                };

            foreach (var item in joinResult)
            {
                Console.WriteLine(
                    item.EmployeeName +
                    " - " +
                    item.DepartmentName);
            }

            Console.WriteLine();

            // Sorting

            Console.WriteLine("===== SORTING =====");

            var sortedEmployees =
                employees.OrderByDescending(e => e.Salary);

            foreach (var emp in sortedEmployees)
            {
                Console.WriteLine(
                    emp.Name + " - " + emp.Salary);
            }

            Console.WriteLine();

            // Aggregate Functions

            Console.WriteLine("===== AGGREGATES =====");

            Console.WriteLine(
                "Employee Count: "
                + employees.Count());

            Console.WriteLine(
                "Total Salary: "
                + employees.Sum(e => e.Salary));

            Console.WriteLine(
                "Average Salary: "
                + employees.Average(e => e.Salary));

            Console.WriteLine(
                "Maximum Salary: "
                + employees.Max(e => e.Salary));

            Console.WriteLine(
                "Minimum Salary: "
                + employees.Min(e => e.Salary));

            Console.ReadKey();
        }
    }
}