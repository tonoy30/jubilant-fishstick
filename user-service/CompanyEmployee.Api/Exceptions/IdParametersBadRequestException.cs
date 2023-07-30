namespace CompanyEmployee.Api.Exceptions;

public class IdParametersBadRequestException : BadRequestException
{
    public IdParametersBadRequestException()
        : base("Parameter ids is null")
    {
    }
}