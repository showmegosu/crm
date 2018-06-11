using System.Configuration;
using Xunit;

namespace Tourism.DAL.Test
{
    public class ClientRepositoryTests
    {
        private readonly ClientRepository _clientRepository;

        public ClientRepositoryTests()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            _clientRepository = new ClientRepository(connectionString);
        }


        [Fact]
        public void InsertClient_ValidClientProvided_IdReturned()
        {
            // Arrange
           var client = new Client()
            {
                Surname = "Boreyko",
                Name = "Eugenia",
                FathersName = "Ostapovna",
            };
            client.Addresses.Add("Kyiv");
            client.Addresses.Add("Ukraine");
            client.PhoneNumbers.Add("333333");
            client.PhoneNumbers.Add("555555");

            // Act
            var id = _clientRepository.InsertClient(client);

            // Assert
            Assert.NotEqual(0,id);
        }
    }
}
