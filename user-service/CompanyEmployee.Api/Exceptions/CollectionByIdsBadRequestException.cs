namespace CompanyEmployee.Api.Exceptions;

public class CollectionByIdsBadRequestException : BadRequestException
{
    public CollectionByIdsBadRequestException() : base("Collection count mismatch comparing to ids.")
    {
    }
}