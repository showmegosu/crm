using System.Collections.Generic;
using System.Data.SqlClient;

namespace Tourism.DAL
{
    public class ClientRepository
    {
        public ClientRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private string ConnectionString { get; }
        public List<ClientDto> GetAllClients()
        {
            var clientsList = new List<ClientDto>();

            var queryString = "SELECT Client_Id, Surname from dbo.Clients";

            using (var connection = new SqlConnection(ConnectionString))
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