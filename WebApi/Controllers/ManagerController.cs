using System.Collections.Generic;
using System.Web.Http;
using Logger;
using Tourism.DAL;

namespace WebApi.Controllers
{
    public class ManagerController : ApiController
    {
        private readonly IManagerRepository _managerRepository;
        private readonly ILogger _logger;

        public ManagerController(ILogger logger, IManagerRepository repository)
        {
            _managerRepository = repository;
            _logger = logger;
        }

        // GET: api/v1/Manager
        public List<ManagerDto> Get()
        {
            _logger.LogInfo("GetAll request was sent.");
            return _managerRepository.GetAllManagers();
        }

        // GET: api/Manager/5
        public ManagerDto Get(int id)
        {
            _logger.LogInfo("Get manager by Id=" + id + " request was sent.");
            return _managerRepository.GetManagerById(id);
        }
    }
}