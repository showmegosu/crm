using System.Collections.Generic;
using System.Web.Http;
using Logger;
using Tourism.DAL;

namespace WebApi.Controllers
{
    public class ClientController : ApiController
    {
        private readonly IClientRepository _clientRepository;
        private readonly ILogger _logger;

        public ClientController(ILogger logger, IClientRepository repository)
        {
            _clientRepository = repository;
            _logger = logger;
        }

        // GET: api/v1/Client
        public List<ClientDto> Get()
        {
            _logger.LogInfo("GetAll request was sent.");
            return _clientRepository.GetAllClients();
        }

        // GET: api/Client/5
        public Client Get(int id)
        {
            _logger.LogInfo("Get client by Id=" + id + " request was sent.");
            return _clientRepository.GetClientById(id);
        }

        // POST: api/v1/Client
        public void Post([FromBody] Client client)
        {
            _logger.LogInfo("Post client=" + client + " request was sent.");
            _clientRepository.InsertClient(client);
        }

        // PUT: api/Client/5
        public void Put(int id, [FromBody] Client client)
        {
            _logger.LogInfo("Update client=" + client + " request was sent.");
            _clientRepository.Update(client);
        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
            _logger.LogInfo("Delete client by Id=" + id + " request was sent.");
            _clientRepository.Delete(id);
        }
    }
}