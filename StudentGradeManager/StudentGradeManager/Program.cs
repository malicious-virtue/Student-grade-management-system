using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        while (true)
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Course and Grade");
            Console.WriteLine("3. Display Student Records");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    AddStudent(students);
                    break;
                case 2:
                    AddCourseAndGrade(students);
                    break;
                case 3:
                    DisplayStudentRecords(students);
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddStudent(List<Student> students)
    {
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Student ID: ");
        string id = Console.ReadLine();

        students.Add(new Student { Name = name, Id = id });
    }

    static void AddCourseAndGrade(List<Student> students)
    {
        Console.Write("Enter Student ID: ");
        string id = Console.ReadLine();
        Student student = students.FirstOrDefault(s => s.Id == id);

        if (student != null)
        {
            Console.Write("Enter Course Name: ");
            string courseName = Console.ReadLine();
            Console.Write("Enter Grade: ");
            double grade = double.Parse(Console.ReadLine());

            student.Courses.Add(new Course { Name = courseName, Grade = grade });
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void DisplayStudentRecords(List<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine($"Student Name: {student.Name}, Student ID: {student.Id}");
            foreach (var course in student.Courses)
            {
                Console.WriteLine($"Course: {course.Name}, Grade: {course.Grade}");
            }
            Console.WriteLine($"Average Grade: {student.CalculateAverageGrade()}");
            Console.WriteLine();
        }
    }
}

class Student
{
    public string Name { get; set; }
    public string Id { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();

    public double CalculateAverageGrade()
    {
        if (Courses.Count == 0) return 0;
        return Courses.Average(c => c.Grade);
    }
}

class Course
{
    public string Name { get; set; }
    public double Grade { get; set; }
}