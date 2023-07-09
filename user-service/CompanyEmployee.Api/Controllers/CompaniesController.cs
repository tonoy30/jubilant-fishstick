using CompanyEmployee.Api.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployee.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly IServiceManager _service;

    public CompaniesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetCompanies()
    {
        try
        {
            var companies = _service.CompanyService.GetAllCompanies(false);
            return Ok(companies);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
}