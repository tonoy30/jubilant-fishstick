using AutoMapper;
using CompanyEmployee.Api.DataTransferObjects;
using CompanyEmployee.Api.Entities;

namespace CompanyEmployee.Api.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>().ForCtorParam("FullAddress",
            opt =>
                opt.MapFrom(x =>
                    string.Join(' ', x.Address, x.Country)
                )
        );
        CreateMap<Employee, EmployeeDto>();
    }
}