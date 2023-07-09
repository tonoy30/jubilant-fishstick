namespace CompanyEmployee.Api.Contracts;

public interface IServiceManager
{
    ICompanyService CompanyService { get; }
    IEmployeeService EmployeeService { get; }
}