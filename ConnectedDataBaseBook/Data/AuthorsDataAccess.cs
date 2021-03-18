using ConnectedDataBaseBook.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System;

namespace ConnectedDataBaseBook.Data
{
    public class AuthorsDataAccess
    {
        // Выведите список авторов книги №3 (по порядку из таблицы Book)
        
        public ICollection<Authors> SelectAllAuthors()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Server = DESKTOP-JC4A8MC\\MSSQLSERVER1; Database = Library; Trusted_Connection = true"; // localdb)\\mssqllocaldb
                connection.Open(); // подключись

                string selectSqlScript = "select * from public. \"Authors\"";

                SqlCommand command = new SqlCommand(selectSqlScript, connection);
                SqlDataReader dataReader = command.ExecuteReader();


                List<Authors> authors = new List<Authors>();

                while (dataReader.Read())
                {
                    authors.Add(new Authors
                    {
                        Id = int.Parse(dataReader["id"].ToString()),
                        NameAuthor = dataReader["NameAuthor"].ToString(),
                        BookList_id = dataReader["BookList_id"].ToString(),
                    });
                }

                command.Dispose();
                dataReader.Close();


                return authors;
                
            }
        }
    }
}
