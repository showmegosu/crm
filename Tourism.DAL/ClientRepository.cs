using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Tourism.DAL
{
    public class ClientRepository
    {
        public List<Client> GetAllClients()
        {
            var clientsList = new List<Client>();

            var connectionString = "Data Source=(local);Initial Catalog=CRM;" + "Integrated Security=true";

            var queryString = "SELECT Client_Id, Surname from dbo.Clients";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        clientsList.Add(new Client((int)reader[0], reader[1].ToString()));
                    }

                    reader.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadLine();
            }

            return clientsList;
        }
    }
}