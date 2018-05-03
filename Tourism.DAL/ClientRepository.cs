using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Tourism.DAL
{
    public class ClientRepository
    {
        public List<ClientDto> GetAllClients()
        {
            var clientsList = new List<ClientDto>();

            var connectionString = "Data Source=.;Initial Catalog=CRM;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            var queryString = "SELECT Client_Id, Surname from dbo.Clients";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    clientsList.Add(new ClientDto((int) reader[0], reader[1].ToString()));
                }

                reader.Close();
            }

            return clientsList;
        }
    }
}