using CompanyEmployee.Api.DataTransferObjects;
using CompanyEmployee.Api.Entities;

namespace CompanyEmployee.Api.Contracts;

public interface ICompanyService
{
    IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
    CompanyDto GetCompany(Guid companyId, bool trackChanges);
    CompanyDto CreateCompany(CompanyForCreationDto company);
    IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    (IEnumerable<CompanyDto>, string ids) CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companies);
    void DeleteCompany(Guid companyId, bool trackChanges);
    void UpdateCompany(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges);
}