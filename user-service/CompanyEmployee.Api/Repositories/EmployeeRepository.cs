using CompanyEmployee.Api.Contracts;
using CompanyEmployee.Api.Entities;

namespace CompanyEmployee.Api.Repositories;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}