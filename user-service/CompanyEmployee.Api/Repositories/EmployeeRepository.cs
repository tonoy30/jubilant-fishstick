using CompanyEmployee.Api.Contracts;
using CompanyEmployee.Api.Entities;

namespace CompanyEmployee.Api.Repositories;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Employee> GetAllEmployees(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(e => e.Name)
            .ToList();

    public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) =>
        FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(e => e.Name)
            .ToList();

    public Employee? GetEmployee(Guid companyId, Guid employeeId, bool trackChanges) =>
        FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(employeeId), trackChanges)
            .SingleOrDefault();

    public void CreateEmployeeForCompany(Guid companyId, Employee employee)
    {
        employee.CompanyId = companyId;
        Create(employee);
    }
}