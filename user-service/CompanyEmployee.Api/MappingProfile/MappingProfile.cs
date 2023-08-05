using AutoMapper;
using CompanyEmployee.Api.DataTransferObjects;
using CompanyEmployee.Api.Entities;

namespace CompanyEmployee.Api.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForMember(o => o.FullAddress,
                opt =>
                    opt.MapFrom(x =>
                        string.Join(' ', x.Address, x.Country)
                    )
            );
        CreateMap<CompanyForCreationDto, Company>();
        CreateMap<CompanyForUpdateDto, Company>();
        
        CreateMap<Employee, EmployeeDto>();
        CreateMap<EmployeeForCreationDto, Employee>();
        CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
    }
}