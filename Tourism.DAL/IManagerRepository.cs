using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.DAL
{
    public interface IManagerRepository
    {
        List<ClientDto> GetAllManagers();
        Client GetManagerById(int id);
        int InsertManager(Client client);
        void Update(Client client);
        void Delete(int id);
    }
}
