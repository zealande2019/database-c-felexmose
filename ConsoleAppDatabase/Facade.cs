using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAppDatabase
{
    public static class Facade
    {
        //Opgave 2
        public static List<Student> GetAllStudents()
        {
            //A return variable result that will contain the requested data from the database
            List<Student> result = new List<Student>();

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "zealand2019.database.windows.net";
                builder.UserID = "fele0009";
                builder.Password = "Zealand1234";
                builder.InitialCatalog = "student";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT* ");
                    sb.Append("FROM student");
                    //sb.Append("JOIN [SalesLT].[Product] p ");
                    //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string mobilNr = reader.GetString(2);

                                Student student = new Student(id, name, mobilNr);

                                result.Add(student);


                                //Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            //Console.ReadLine();
            return result;
        

    }
    public static Exam GetSpecifikExam(int examId)
        {
            //make connection to database
            string Conn = "Server=tcp:zealand2019.database.windows.net,1433;Initial Catalog=student;Persist Security Info=False;User ID={fele0009};Password={Zealand1234};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                
            //create sql statement to select the specific exam for the database
            string selectSpecifikExam = "select * from exam where exam.ExamId = @examId";

            //create an helper variable for return purpose
            Exam result = new Exam();

            using (SqlConnection databaseConnection = new SqlConnection(Conn))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectSpecifikExam, databaseConnection))
                {

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int ExamId = reader.GetInt32(0);
                                string examName = reader.GetString(1);
                                int grade = reader.GetInt32(2);
                                int studentId = reader.GetInt32(3);

                                Exam exam = new Exam(ExamId,examName,grade,studentId);

                                result = exam;

                            }
                        }
                        else
                        {
                            Console.WriteLine("no more rows in SqlDataReader");
                        }
                    }


                }
            }

            //create an Exam object to carry the table result
            return result;


        }
    }
}
