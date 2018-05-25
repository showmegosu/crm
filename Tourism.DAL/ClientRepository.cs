using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Tourism.DAL
{
    public class ClientRepository
    {
        private readonly string _connectionString;

        public ClientRepository(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            _connectionString = connectionString;
        }

        public List<ClientDto> GetAllClients()
        {
            var clientsList = new List<ClientDto>();

            var queryString = "SELECT Client_Id, Surname from dbo.Clients";

            using (var connection = new SqlConnection(_connectionString))
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

        public void InsertClient(Client client)
        {
            var queryString = "INSERT INTO dbo.Clients (Surname,Name,Fathers_name) VALUES (@Surname,@Name,@FathersName);" +
                              "SELECT @Client_Id = SCOPE_IDENTITY()";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Surname", client.Surname);
                command.Parameters.AddWithValue("@Name", client.Name);
                command.Parameters.AddWithValue("@FathersName", client.FathersName);
                command.Parameters.Add("@Client_Id",SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}