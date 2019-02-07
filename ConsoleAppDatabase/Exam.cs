using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppDatabase
{
    public class Exam
    {
        public int examId;
        public string examName;
        public int grade;
        public int studentId;

        public Exam(int examId, string examName, int grade, int studentId)
        {
            this.examId = examId;
            this.examName = examName;
            this.grade = grade;
            this.studentId = studentId;

        }
    }
}
