using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace Tourism.DAL
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly string _connectionString;
        private readonly ILogger _logger;

        public ManagerRepository(string connectionString, ILogger logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public List<ManagerDto> GetAllManagers()
        {
            var managersList = new List<ManagerDto>();

            var queryString = "SELECT Manager_Id, Surname from dbo.Managers";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    managersList.Add(new ManagerDto((int) reader[0], reader[1].ToString()));
                }

                reader.Close();
            }

            return managersList;
        }

        public Manager GetManagerById(int id)
        {
            var queryString = "SELECT Manager_Id, Surname, Name, Fathers_name, Email, Skype, Access_lvl, DoB, Joined, Base_salary,  from dbo.Managers WHERE Manager_Id=@id;" +
                              "SELECT Number from dbo.Phones WHERE Fk_Client_Id=@id;" +
                              "SELECT Address from dbo.Addresses WHERE Fk_Client_Id=@id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                var reader = command.ExecuteReader();
                var manager = new Manager();
                while (reader.Read())
                {
                    manager.Id = (int) reader[0];
                    manager.Surname = reader[1].ToString();
                    manager.Name = reader[2].ToString();
                    manager.FathersName = reader[3].ToString();
                }

                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        manager.PhoneNumbers.Add(reader[0].ToString());
                    }
                }

                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        manager.Addresses.Add(reader[0].ToString());
                    }
                }

                return manager;
            }
        }

        public int InsertManager(Manager manager)
        {
            throw new NotImplementedException();
        }

        public void Update(Manager manager)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }