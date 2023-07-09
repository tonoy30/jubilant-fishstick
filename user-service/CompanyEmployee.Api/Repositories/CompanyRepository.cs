using CompanyEmployee.Api.Contracts;
using CompanyEmployee.Api.Entities;

namespace CompanyEmployee.Api.Repositories;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}