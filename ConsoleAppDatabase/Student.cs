using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppDatabase
{
    public class Student
    {
        public int id;
        public string name;
        public string mobilNr;

        public Student(int id, string name, string mobilNr)
        {
            this.id = id;
            this.name = name;
            this.mobilNr = mobilNr;
        }

    }
}
