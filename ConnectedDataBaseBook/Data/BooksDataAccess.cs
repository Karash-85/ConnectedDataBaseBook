using ConnectedDataBaseBook.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConnectedDataBaseBook.Data
{
    public class BooksDataAccess
    {
        // Выведите список книг, которые доступны в данный момент

        public ICollection<Books> SelectAllBooks()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Server = DESKTOP-JC4A8MC\\MSSQLSERVER1; Database = Library; Trusted_Connection = true"; // localdb)\\mssqllocaldb
                connection.Open(); // подключись

                string selectSqlScript = "select * from public. \"Books\"";

                SqlCommand command = new SqlCommand(selectSqlScript, connection);
                SqlDataReader dataReader = command.ExecuteReader();


                List<Books> books = new List<Books>();

                while (dataReader.Read())
                {
                    books.Add(new Books
                    {
                        Id = int.Parse(dataReader["id"].ToString()),
                        NameBook = dataReader["NameBook"].ToString(),
                        GenreBook = dataReader["GenreBook"].ToString(),
                    });
                }

                command.Dispose();
                dataReader.Close();


                return books;

            }

        }
    }
}
