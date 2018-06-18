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

        public Client GetClientById(int id)
        {
            var queryString = "SELECT Client_Id, Surname, Name, Fathers_name from dbo.Clients WHERE Client_Id=@id;" +
                              "SELECT Number from dbo.Phones WHERE Fk_Client_Id=@id;" +
                              "SELECT Address from dbo.Addresses WHERE Fk_Client_Id=@id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                var reader = command.ExecuteReader();
                var client = new Client();
                while (reader.Read())
                {
                    client.Id = (int)reader[0];
                    client.Surname = reader[1].ToString();
                    client.Name = reader[2].ToString();
                    client.FathersName = reader[3].ToString();
                }

                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        client.PhoneNumbers.Add(reader[0].ToString());
                    }
                }

                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        client.Addresses.Add(reader[0].ToString());
                    }
                }

                return client;
            }
        }


        public int InsertClient(Client client)
        {
            var queryString =
                "INSERT INTO dbo.Clients (Surname,Name,Fathers_name) output INSERTED.Client_Id VALUES (@Surname,@Name,@FathersName);" +
                "SELECT @Client_Id = SCOPE_IDENTITY()";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Surname", client.Surname);
                command.Parameters.AddWithValue("@Name", client.Name);
                command.Parameters.AddWithValue("@FathersName", client.FathersName);
                command.Parameters.Add("@Client_Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                var clientsId = (int)command.ExecuteScalar();
                var queryStringAddAddressesPhones = "";
                foreach (var phoneNumber in client.PhoneNumbers)
                {
                    queryStringAddAddressesPhones += $"INSERT INTO dbo.Phones (Number,Fk_Client_Id) VALUES ('{phoneNumber}',{clientsId});\n";
                }

                foreach (var address in client.Addresses)
                {
                    queryStringAddAddressesPhones += $"INSERT INTO dbo.Addresses (Address,Fk_Client_Id) VALUES ('{address}',{clientsId});\n";
                }
                var command2 = new SqlCommand(queryStringAddAddressesPhones, connection);
                command2.ExecuteNonQuery();
                return clientsId;
            }
        }

        public void Update(Client client)
        {
            var queryString =
                "UPDATE dbo.Clients " +
                "SET Surname=@Surname, Name=@Name, Fathers_name=@FathersName " +
                "WHERE Client_Id=@id;\n" +
                "DELETE FROM dbo.Phones " +
                "WHERE Fk_Client_Id=@id; " +
                "DELETE FROM dbo.Addresses " +
                "WHERE Fk_Client_Id=@id;\n";
            foreach (var phoneNumber in client.PhoneNumbers)
            {
                queryString +=
                    $"INSERT INTO dbo.Phones (Number, Fk_Client_Id) VALUES ('{phoneNumber}',{client.Id});\n";
            }

            foreach (var address in client.Addresses)
            {
                queryString +=
                    $"INSERT INTO dbo.Addresses (Address, Fk_Client_Id) VALUES ('{address}',{client.Id});\n";
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Surname", client.Surname);
                command.Parameters.AddWithValue("@Name", client.Name);
                command.Parameters.AddWithValue("@FathersName", client.FathersName);
                command.Parameters.AddWithValue("@Id", client.Id);

                connection.Open();
                command.ExecuteNonQuery();
            }



        }
    }
}