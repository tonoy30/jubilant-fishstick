using AutoMapper;
using CompanyEmployee.Api.Contracts;
using CompanyEmployee.Api.DataTransferObjects;
using CompanyEmployee.Api.Entities;
using CompanyEmployee.Api.Exceptions;
using Serilog;

namespace CompanyEmployee.Api.Services;

internal sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CompanyService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
    {
        try
        {
            var companies = _repository.Company.GetAllCompanies(trackChanges);
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }
        catch (Exception ex)
        {
            Log.Error("Somethings went wrong in the {Name} service method {Message}",
                nameof(GetAllCompanies), ex.Message);
            throw;
        }
    }

    public CompanyDto GetCompany(Guid companyId, bool trackChanges)
    {
        var company = _repository.Company.GetCompany(companyId, trackChanges);
        if (company is null)
        {
            throw new CompanyNotFoundException(companyId);
        }

        var companyDto = _mapper.Map<CompanyDto>(company);
        return companyDto;
    }
}