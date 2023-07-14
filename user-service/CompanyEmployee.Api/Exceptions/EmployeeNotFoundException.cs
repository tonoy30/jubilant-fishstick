namespace CompanyEmployee.Api.Exceptions;

public class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(Guid employeeId)
        : base($"Employee with id: {employeeId} doesn't exist in the database.")
    {
    }
}