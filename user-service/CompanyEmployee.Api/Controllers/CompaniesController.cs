using CompanyEmployee.Api.Contracts;
using CompanyEmployee.Api.DataTransferObjects;
using CompanyEmployee.Api.ModelBinders;
using Microsoft.AspNetCore.Http.HttpResults;
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

    [HttpGet("{companyId:guid}", Name = "CompanyById")]
    public IActionResult GetCompany(Guid companyId)
    {
        var company = _service.CompanyService.GetCompany(companyId, false);
        return Ok(company);
    }

    [HttpGet("collection/({ids})", Name = "CompanyCollection")]
    public IActionResult GetCompanyCollection(
        [ModelBinder(BinderType = typeof(ArrayModelBinder))]
        IEnumerable<Guid> ids)
    {
        var companies = _service.CompanyService.GetByIds(ids, false);
        return Ok(companies);
    }

    [HttpPost]
    public IActionResult CreateCompany([FromBody] CompanyForCreationDto company)
    {
        try
        {
            var createdCompany = _service.CompanyService.CreateCompany(company);
            return CreatedAtRoute("CompanyById", new { companyId = createdCompany.Id }, createdCompany);
        }
        catch (Exception e)
        {
            return BadRequest("Please provide valid data");
        }
    }

    [HttpPost("collection")]
    public IActionResult CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
    {
        var (companies, ids) = _service.CompanyService
            .CreateCompanyCollection(companyCollection);

        return CreatedAtRoute("CompanyCollection", new { ids }, companies);
    }

    [HttpDelete("companyId:guid")]
    public IActionResult DeleteCompany(Guid companyId)
    {
        _service.CompanyService.DeleteCompany(companyId, false);
        return NoContent();
    }
}