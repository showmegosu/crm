using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace Tourism.DAL
{
    public class ManagerRepository : IClientRepository
    {
        private readonly string _connectionString;
        private readonly ILogger _logger;

        public ManagerRepository(string connectionString, ILogger logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }
    }