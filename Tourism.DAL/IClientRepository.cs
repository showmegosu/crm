using System.Collections.Generic;

namespace Tourism.DAL
{
    public interface IClientRepository
    {
        List<ClientDto> GetAllClients();
        Client GetClientById(int id);
        int InsertClient(Client client);
        void Update(Client client);
        void Delete(int id);
    }
}