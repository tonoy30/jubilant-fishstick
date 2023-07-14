using CompanyEmployee.Api.Entities;

namespace CompanyEmployee.Api.Contracts;

public interface ICompanyRepository
{
    IEnumerable<Company> GetAllCompanies(bool trackChanges);
    Company? GetCompany(Guid companyId, bool trackChanges);
}