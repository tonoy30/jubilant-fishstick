using CompanyEmployee.Api.Contracts;
using CompanyEmployee.Api.Entities;

namespace CompanyEmployee.Api.Repositories;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
        FindAll(trackChanges).OrderBy(o => o.Name).ToList();

    public Company? GetCompany(Guid companyId, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefault();

    public void CreateCompany(Company company) => Create(company);

    public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        => FindByCondition(x => ids.Contains(x.Id), trackChanges).ToList();
}