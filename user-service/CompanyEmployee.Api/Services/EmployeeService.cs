using AutoMapper;
using CompanyEmployee.Api.Contracts;
using CompanyEmployee.Api.DataTransferObjects;
using CompanyEmployee.Api.Exceptions;
using Serilog;

namespace CompanyEmployee.Api.Services;

internal sealed class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public EmployeeService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
    {
        var company = _repository.Company.GetCompany(companyId, trackChanges);
        if (company is null)
        {
            throw new CompanyNotFoundException(companyId);
        }

        var employees = _repository.Employee.GetEmployees(companyId, trackChanges);
        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }

    public EmployeeDto GetEmployee(Guid companyId, Guid employeeId, bool trackChanges)
    {
        var company = _repository.Company.GetCompany(companyId, trackChanges);
        if (company is null)
        {
            throw new CompanyNotFoundException(companyId);
        }

        var employee = _repository.Employee.GetEmployee(companyId, employeeId, trackChanges);
        if (employee is null)
        {
            throw new EmployeeNotFoundException(employeeId);
        }

        return _mapper.Map<EmployeeDto>(employee);
    }
}