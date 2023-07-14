using CompanyEmployee.Api.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployee.Api.Controllers;

[ApiController]
[Route("api/companies/{companyId:guid}/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IServiceManager _service;

    public EmployeesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetEmployees(Guid companyId)
    {
        var employees = _service.EmployeeService.GetEmployees(companyId, false);
        return Ok(employees);
    }

    [HttpGet("{employeeId:guid}")]
    public IActionResult GetEmployee(Guid companyId, Guid employeeId)
    {
        var employee = _service.EmployeeService.GetEmployee(companyId, employeeId, false);
        return Ok(employee);
    }
}