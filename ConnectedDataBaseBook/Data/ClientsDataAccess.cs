using ConnectedDataBaseBook.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConnectedDataBaseBook.Data
{
    public class ClientsDataAccess
    {        
        // Выведите список должников
        // Вывести список книг, которые на руках у пользователя №2
        // Обнулите задолженности всех должников
        public ICollection<Clients> SelectAllClients()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Server = DESKTOP-JC4A8MC\\MSSQLSERVER1; Database = Library; Trusted_Connection = true"; // localdb)\\mssqllocaldb
                connection.Open();

                string selectSqlScript = "select * from public. \"Clients\"";

                SqlCommand command = new SqlCommand(selectSqlScript, connection);
                SqlDataReader dataReader = command.ExecuteReader();


                List<Clients> clients = new List<Clients>();

                while (dataReader.Read())
                {
                    clients.Add(new Clients
                    {
                        Id = int.Parse(dataReader["id"].ToString()),
                        NameClient = dataReader["NameClient"].ToString(),
                        BookList2_id = int.Parse(dataReader["BookList2_id"].ToString()),
                    });
                }

                command.Dispose();
                dataReader.Close();


                return clients;

            }
        }

    }
}
