using Xunit;

namespace Tourism.DAL.Test
{
    public class ClientRepositoryTests
    {
        [Fact]
        public void InsertClient_ValidClientProvided_IdReturned()
        {
            // Arrange
            var clientRepository = new ClientRepository("Data Source=.;Initial Catalog=CRM;Integrated Security=True;Connect Timeout=15;Encrypt=False;" +
                                                        "TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
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
            var id = clientRepository.InsertClient(client);

            // Assert
            Assert.NotEqual(0,id);
        }
    }
}
