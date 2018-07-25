using System.Collections.Generic;

namespace Tourism.DAL
{
    public interface IManagerRepository
    {
        List<ManagerDto> GetAllManagers();
        Manager GetManagerById(int id);
        int InsertManager(Manager manager);
        void Update(Manager manager);
        void Delete(int id);
    }
}