using CompanyEmployee.Api.DataTransferObjects;
using CompanyEmployee.Api.Entities;

namespace CompanyEmployee.Api.Contracts;

public interface ICompanyService
{
    IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
    CompanyDto GetCompany(Guid companyId, bool trackChanges);
}