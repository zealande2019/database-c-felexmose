using System;

namespace ConsoleAppDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var students = Facade.GetAllStudents();

            foreach (var item in students)
            {
                Console.WriteLine($"id:{item.id} name:{item.name} telefon:{item.mobilNr}");
            }
        }
    }
}
