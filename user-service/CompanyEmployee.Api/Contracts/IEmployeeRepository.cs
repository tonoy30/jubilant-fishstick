using CompanyEmployee.Api.Entities;

namespace CompanyEmployee.Api.Contracts;

public interface IEmployeeRepository
{

    IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);
    Employee? GetEmployee(Guid companyId, Guid employeeId, bool trackChanges);
}