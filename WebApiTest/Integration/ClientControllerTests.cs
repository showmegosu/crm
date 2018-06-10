using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using Xunit;
using System.Web.Http;
using Tourism.DAL;

namespace WebApiTest.Integration
{
    public class ClientControllerTests
    {
        public ClientController clientController;
        public ClientControllerTests()
        {
            clientController = new ClientController();
        }

        [Fact]
        public void Post_Client_Created()
        {
            // Arrange
            var client = new Client
            {
                Surname = "Boreyko",
                Name = "Eugenia",
                FathersName = "Ostapovna",
            };
            client.PhoneNumbers.Add("3333333");
            client.PhoneNumbers.Add("5555555");
            client.Addresses.Add("new address");
            client.Addresses.Add("myAddress");

            // Act
            var expectedId = clientController.Post(client);
            var actualId = clientController.Get(expectedId).Id;

            // Assert
            Assert.Equal(expectedId, actualId);
        }
    }
}
