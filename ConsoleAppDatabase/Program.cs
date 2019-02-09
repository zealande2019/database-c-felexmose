using System;
using System.Collections.Generic;

namespace ConsoleAppDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Student> students = Facade.GetAllStudents();

            foreach (Student item in students)
            {
                Console.WriteLine($"id:{item.id} name:{item.name} telefon:{item.mobilNr}");
            }

            Exam specikExam = Facade.GetSpecifikExam(12);
            Console.WriteLine($"ExamID:{specikExam.examId} Exam Name:{specikExam.examName} Grade:{specikExam.grade} Student ID:{specikExam.studentId} ");
            //Facade.GetAllStudents2();
        }
    }
}
