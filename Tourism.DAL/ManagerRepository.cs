using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public ManagerDto GetManagerById(int id)
        {
            var queryString =
                "SELECT Manager_Id, Surname, dbo.Managers.Name, Fathers_name, Email, Skype, dbo.Managers.Address, " +
                "dbo.Companies.Name as Company, dbo.Offices.Name as Office, DoB, Joined, Base_salary " +
                "FROM dbo.Managers " +
                "INNER JOIN dbo.Companies ON dbo.Managers.Fk_Company_Id=dbo.Companies.Company_Id " + // Fk to Company.Name
                "INNER JOIN dbo.Offices ON dbo.Managers.Fk_Office_Id=dbo.Offices.Office_Id " + // Fk to Office.Name
                "WHERE Manager_Id=@id " +
                "SELECT Number from dbo.ManagerPhones WHERE Fk_Manager_Id=@id"; // Selecting phones from ManagerPhones

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                var reader = command.ExecuteReader();
                var manager = new ManagerDto();
                while (reader.Read())
                {
                    manager.Id = (int) reader[0];
                    manager.Surname = reader[1].ToString();
                    manager.Name = reader[2].ToString();
                    manager.FathersName = reader[3].ToString();
                    manager.Email = reader[4].ToString();
                    manager.Skype = reader[5].ToString();
                    manager.Address = reader[6].ToString();
                    manager.Company = reader[7].ToString();
                    manager.Office = reader[8].ToString();
                    manager.DateOfBirth = reader[9].ToString();
                    manager.JoiningDate = reader[10].ToString();
                    manager.BaseSalary = (int) reader[11];
                }

                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        manager.PhoneNumbers.Add(reader[0].ToString());
                    }
                }

                return manager;
            }
        }

        public int InsertManager(Manager manager)
        {
            var queryString =
                "INSERT INTO dbo.Managers (Surname,Name,Fathers_name,Email,Skype,Address,Fk_Company_Id,Fk_Office_Id,DoB,Joined,Base_salary) " +
                "output INSERTED.Manager_Id VALUES (@Surname,@Name,@FathersName,@Email,@Skype,@Address,@Company,@Office,@DateOfBirth,@JoiningDate,@BaseSalary);" +
                "SELECT @Manager_Id = SCOPE_IDENTITY()";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Surname", manager.Surname);
                command.Parameters.AddWithValue("@Name", manager.Name);
                command.Parameters.AddWithValue("@FathersName", manager.FathersName);
                command.Parameters.AddWithValue("@Email", manager.Email);
                command.Parameters.AddWithValue("@Skype", manager.Skype);
                command.Parameters.AddWithValue("@Address", manager.Address);
                command.Parameters.AddWithValue("@Company", manager.Company);
                command.Parameters.AddWithValue("@Office", manager.Office);
                command.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value=manager.DateOfBirth.Date;
                command.Parameters.Add("@JoiningDate", SqlDbType.Date).Value=manager.JoiningDate.Date;
                command.Parameters.AddWithValue("@BaseSalary", manager.BaseSalary);
                command.Parameters.Add("@Manager_Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                var managerId = (int)command.ExecuteScalar();
                var queryStringAddPhones = "";
                foreach (var phoneNumber in manager.PhoneNumbers)
                {
                    queryStringAddPhones +=
                        $"INSERT INTO dbo.ManagerPhones (Number,Fk_Manager_Id) VALUES ('{phoneNumber}',{managerId});\n";
                }

                var command2 = new SqlCommand(queryStringAddPhones, connection);
                command2.ExecuteNonQuery();
                return managerId;
            }
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
}