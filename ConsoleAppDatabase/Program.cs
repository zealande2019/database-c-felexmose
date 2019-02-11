using System;
using System.Collections.Generic;

namespace ConsoleAppDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //creation of a variable the contains a list of all students.
            List<Student> students = Facade.GetAllStudents();

            //print each student contained in the list of students variable.
            foreach (Student item in students)
            {
                Console.WriteLine($"id:{item.id} name:{item.name} telefon:{item.mobilNr}");
            }

            //creation of a variable to contain exam nr.12.
            Exam Exam12 = Facade.GetSpecifikExam(20);
            //print exam12 details.
            Console.WriteLine($"ExamID:{Exam12.examId} Exam Name:{Exam12.examName} Grade:{Exam12.grade} Student ID:{Exam12.studentId} ");

            //delete exam nr.24.
            Facade.DeleteExam(24);
           
            Console.ReadKey();
        }
    }
}
