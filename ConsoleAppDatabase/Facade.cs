using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAppDatabase
{
    public static class Facade
    {
        public static List<Student> GetAllStudents()
        {
            string Conn = "Server=tcp:zealand2019.database.windows.net,1433;Initial Catalog=student;Persist Security Info=False;User ID={fele0009};Password={Zealand1234};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            string selectAllStudents = "select * from student";

            List<Student> result = new List<Student>();

            using (SqlConnection databaseConnection = new SqlConnection(Conn))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectAllStudents, databaseConnection))
                {

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string mobilNr = reader.GetString(2);

                                Student student = new Student(id, name, mobilNr);

                                result.Add(student);
                             
                            }
                        }
                        else
                        {
                            Console.WriteLine("no more rows in SqlDataReader");
                        }
                    }


                }
            }
            return result;
        } 

    }
}
