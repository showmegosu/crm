using System.Collections.Generic;
using System.Web.Http;

namespace Tourism.DAL.Controllers
{
    public class ClientController : ApiController
    {
        private readonly ClientRepository _clientRepository;

        #region .ctor

        public ClientController()
        {
            _clientRepository = new ClientRepository();
        }

        #endregion

        // GET: api/v1/Client
        public List<ClientDto> Get() => _clientRepository.GetAllClients();

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
