using System.Collections.Generic;

namespace Tourism.DAL
{
    public interface IOfficeRepository
    {
        List<Office> GetAllOffices();
        Office GetOfficeById(int id);
        int InsertOffice(Office office);
        void Update(Office office);
        void Delete(int id);
    }
}
