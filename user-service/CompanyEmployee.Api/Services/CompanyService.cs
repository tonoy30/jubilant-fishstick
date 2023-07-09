using AutoMapper;
using CompanyEmployee.Api.Contracts;
using CompanyEmployee.Api.DataTransferObjects;
using CompanyEmployee.Api.Entities;
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
}