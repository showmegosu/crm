using System.Collections.Generic;

namespace Tourism.DAL
{
    public interface ICompanyRepository
    {
        List<Company> GetAllCompanies();
        Company GetCompanyById(int id);
        int InsertCompany(Company company);
        void Update(Company company);
        void Delete(int id);
    }
}
