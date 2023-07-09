using AutoMapper;
using CompanyEmployee.Api.Contracts;

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
}