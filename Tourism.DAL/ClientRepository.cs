﻿using System;
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
            var queryString = "SELECT Surname, Name, Fathers_name from dbo.Clients WHERE Client_Id=@id;" +
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
                    client.Surname = reader[0].ToString();
                    client.Name = reader[1].ToString();
                    client.FathersName = reader[2].ToString();
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


        public void InsertClient(Client client)
        {
            var queryString =
                "INSERT INTO dbo.Clients (Surname,Name,Fathers_name) VALUES (@Surname,@Name,@FathersName);" +
                "SELECT @Client_Id = SCOPE_IDENTITY()";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Surname", client.Surname);
                command.Parameters.AddWithValue("@Name", client.Name);
                command.Parameters.AddWithValue("@FathersName", client.FathersName);
                command.Parameters.Add("@Client_Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}