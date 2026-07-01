using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManager
{

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Marks { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                Console.WriteLine("\n--- Student List Manager ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Filter by Marks");
                Console.WriteLine("4. Sort by Name");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent(students);
                        break;

                    case 2:
                        DisplayStudents(students);
                        break;

                    case 3:
                        FilterByMarks(students);
                        break;

                    case 4:
                        SortByName(students);
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

  
        static void AddStudent(List<Student> students)
        {
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Marks: ");
            double marks = Convert.ToDouble(Console.ReadLine());

            students.Add(new Student
            {
                Id = id,
                Name = name,
                Marks = marks
            });

            Console.WriteLine("Student added successfully!");
        }
        static void DisplayStudents(List<Student> students)
        {
            if (!students.Any())
            {
                Console.WriteLine("No students available.");
                return;
            }

            foreach (var s in students)
            {
                Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Marks: {s.Marks}");
            }
        }

        
        static void FilterByMarks(List<Student> students)
        {
            Console.Write("Enter minimum marks: ");
            double minMarks = Convert.ToDouble(Console.ReadLine());

            var filteredStudents = students
                .Where(s => s.Marks >= minMarks)   
                .Select(s => new { s.Name, s.Marks }); 

            Console.WriteLine("\nFiltered Students:");

            foreach (var s in filteredStudents)
            {
                Console.WriteLine($"Name: {s.Name}, Marks: {s.Marks}");
            }
        }

    
        static void SortByName(List<Student> students)
        {
            var sortedStudents = students
                .OrderBy(s => s.Name); 

            Console.WriteLine("\nStudents Sorted by Name:");

            foreach (var s in sortedStudents)
            {
                Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Marks: {s.Marks}");
            }
        }
    }
}