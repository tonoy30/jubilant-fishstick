using CompanyEmployee.Api.Contracts;
using CompanyEmployee.Api.DataTransferObjects;
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

    [HttpGet("{employeeId:guid}", Name = "EmployeeById")]
    public IActionResult GetEmployee(Guid companyId, Guid employeeId)
    {
        var employee = _service.EmployeeService.GetEmployee(companyId, employeeId, false);
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
    {
        try
        {
            var createEmployee = _service.EmployeeService.CreateEmployeeForCompany(companyId, employee, false);
            return CreatedAtRoute("EmployeeById", new { companyId, employeeId = createEmployee.Id }, createEmployee);
        }
        catch (Exception e)
        {
            return BadRequest("Please provide valid data");
        }
    }

    [HttpDelete("{employeeId:guid}")]
    public IActionResult DeleteEmployeeForCompany(Guid companyId, Guid employeeId)
    {
        _service.EmployeeService.DeleteEmployeeForCompany(companyId, employeeId, false);
        return NoContent();
    }

    [HttpPut("{employeeId:guid}")]
    public IActionResult UpdateEmployeeForCompany(Guid companyId, Guid employeeId,
        [FromBody] EmployeeForUpdateDto employeeForUpdateDto)
    {
        try
        {
            _service.EmployeeService
                .UpdateEmployeeForCompany(companyId, employeeId, employeeForUpdateDto,
                    false, true);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest("please provide valid data");
        }
    }
}