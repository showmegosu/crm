using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.DAL
{
    public interface IRepository
    {
        List<ClientDto> GetAllClients();
        Client GetClientById(int id);
        int InsertClient(Client client);
        void Update(Client client);
        void Delete(int id);
    }
}