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
            var queryString = "SELECT Manager_Id, Surname, Name, Fathers_name, Email, Skype, Address, dbo.Companies.Name, dbo.Offices.Name, DoB, Joined, Base_salary" +
                              "FROM dbo.Managers WHERE Manager_Id=@id;" +
                              "INNER JOIN dbo.Companies ON dbo.Managers.Fk_Company_Id=dbo.Companies.Company_Id;"+       // Fk to Company.Name
                              "INNER JOIN dbo.Offices ON dbo.Managers.Fk_Office_Id=dbo.Offices.Office_Id;"+             // Fk to Office.Name
                              "SELECT Number from dbo.ManagerPhones WHERE Fk_Manager_Id=@id";                           // Selecting phones from ManagerPhones

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