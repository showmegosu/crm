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
                FathersName = "Ostapovna"
            };
            client.Addresses.Add("Kyiv");
            client.Addresses.Add("Ukraine");
            client.PhoneNumbers.Add("333333");
            client.PhoneNumbers.Add("555555");

            // Act
            var id = _clientRepository.InsertClient(client);

            // Assert
            Assert.NotEqual(0, id);

            // Clean up
            _clientRepository.Delete(id);
        }

        [Fact]
        public void Update_Client_UpdatedSuccessfully()
        {
            // Arrange
            var client = new Client()
            {
                Surname = "InitialClient",
                Name = "InitialName",
                FathersName = "InitialFathersName"
            };
            client.Addresses.Add("InitialAddressOne");
            client.Addresses.Add("InitialAddressTwo");
            client.PhoneNumbers.Add("InitialPhoneOne");
            client.PhoneNumbers.Add("InitialPhoneTwo");

            var updatedClient = new Client()
            {
                Surname = "UpdatedClient",
                Name = "UpdatedName",
                FathersName = "UpdatedFathersName"
            };
            updatedClient.Addresses.Add("UpdatedAddress");
            updatedClient.PhoneNumbers.Add("UpdatedPhone");

            // Act
            var id = _clientRepository.InsertClient(client);
            updatedClient.Id = id;

            try
            {
                _clientRepository.Update(updatedClient);
                var actualUpdatedClient = _clientRepository.GetClientById(id);

                // Assert
                Assert.Equal(id, actualUpdatedClient.Id);
                Assert.Single(actualUpdatedClient.Addresses);
                Assert.Single(actualUpdatedClient.PhoneNumbers);
                Assert.Equal(updatedClient.Surname, actualUpdatedClient.Surname);
                Assert.Equal(updatedClient.Name, actualUpdatedClient.Name);
                Assert.Equal(updatedClient.FathersName, actualUpdatedClient.FathersName);
            }

            finally
            {
                // Clean up
                _clientRepository.Delete(id);
            }
        }
    }
}