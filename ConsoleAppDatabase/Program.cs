using System;
using System.Collections.Generic;

namespace ConsoleAppDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Student> students = Facade.GetAllStudents2();

            foreach (Student item in students)
            {
                Console.WriteLine($"id:{item.id} name:{item.name} telefon:{item.mobilNr}");
            }

            //Facade.GetAllStudents2();
        }
    }
}
