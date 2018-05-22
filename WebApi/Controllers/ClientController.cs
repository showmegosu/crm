using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using Tourism.DAL;

namespace WebApi.Controllers
{
    public class ClientController : ApiController
    {
        private readonly ClientRepository _clientRepository;

        private readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["ClientRepository"].ConnectionString;

        public ClientController()
        {
            _clientRepository = new ClientRepository(_connectionString);
        }

        // GET: api/v1/Client
        public List<ClientDto> Get()
        {
            return _clientRepository.GetAllClients();
        }

        // GET: api/Client/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Client
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Client/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
        }
    }
}
