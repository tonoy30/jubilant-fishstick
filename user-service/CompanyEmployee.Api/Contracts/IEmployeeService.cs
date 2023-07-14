using CompanyEmployee.Api.DataTransferObjects;
using CompanyEmployee.Api.Entities;

namespace CompanyEmployee.Api.Contracts;

public interface IEmployeeService
{
    IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
    EmployeeDto GetEmployee(Guid companyId, Guid employeeId, bool trackChanges);
}