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
                    Console.WriteLine("\nQuery data GetAllStudents:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT* ");
                    sb.Append("FROM student ;");
                    //sb.Append("JOIN [SalesLT].[Product] p ");
                    //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // saving data from the database to respective variables.
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string mobilNr = reader.GetString(2);

                                // creation of a student object to carry the data from the student table.
                                Student student = new Student(id, name, mobilNr);

                                // add each student object to the list of student variable.
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
            //a helper variable for return purpose
            Exam result = new Exam();
            
            //try
            //{
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "zealand2019.database.windows.net";
                builder.UserID = "fele0009";
                builder.Password = "Zealand1234";
                builder.InitialCatalog = "student";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data GetSpecifikExam:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * ");
                    sb.Append("FROM exam ");
                    sb.Append("WHERE exam.ExamId = @examId ;");
                    //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
                    String sqlQuery = sb.ToString();

                    using (SqlCommand selectCommand = new SqlCommand(sqlQuery, connection))
                    {
                        //replacing the @examId with the actual user given parameter value.
                        selectCommand.Parameters.AddWithValue("@examId", examId);

                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int ExamId = reader.GetInt32(0);
                                string examName = reader.GetString(1);
                                int grade = reader.GetInt32(2);
                                int studentId = reader.GetInt32(3);

                                Exam exam = new Exam(ExamId, examName, grade, studentId);

                                result = exam;                           
                            }
                        }
                    }
                }
            //}
            //catch (SqlException e)
            //{
            //    Console.WriteLine(e.ToString());
            //}
            //Console.ReadLine();
            return result;                             
        }

        public static void DeleteExam(int examId)
        {
            //try
            //{
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "zealand2019.database.windows.net";
                builder.UserID = "fele0009";
                builder.Password = "Zealand1234";
                builder.InitialCatalog = "student";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data DeleteSpecifikData:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("DELETE FROM exam ");
                    sb.Append("WHERE exam.ExamID = @examId ; ");
                    //sb.Append(" ");
                    //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
                    String sqlQuery = sb.ToString();

                    using (SqlCommand deleteCommand = new SqlCommand(sqlQuery, connection))
                    {

                        deleteCommand.Parameters.AddWithValue("@examId",examId);

                        // execute the sql query on against the database.    
                        deleteCommand.ExecuteReader();
                        Console.WriteLine("Data deleted.");

                        //using (SqlDataReader reader = command.ExecuteReader())
                        //{
                        //    Console.WriteLine("Data deleted.");
                        //}
                    }
                }
            //}
            //catch (SqlException e)
            //{
            //    Console.WriteLine(e.ToString());
            //}

        }

        // opgave 1.1 selecting all students, with respective attributes from the student table and exam table from database
        public static void SelectAllStudents()
        {
            //A return variable result that will contain the requested data from the database
            List<Student> result = new List<Student>();

            string sqlStoredProcedure = "selectAllStudents";

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "zealand2019.database.windows.net";
            builder.UserID = "fele0009";
            builder.Password = "Zealand1234";
            builder.InitialCatalog = "student";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("\nQuery data GetAllStudents:");
                Console.WriteLine("=========================================\n");

                connection.Open();

                using (var storedProcedureCommand = new SqlCommand(sqlStoredProcedure, connection))
                {
                    storedProcedureCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = storedProcedureCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // saving data from the database to respective variables.
                            int studentId = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int grade = reader.GetInt32(2);
                            string examName = reader.GetString(3);                                                 

                            Console.WriteLine("{0} {1} {2} {3}", studentId, name, grade, examName);
                        }
                    }
                }
            }      
        }
    }
}
