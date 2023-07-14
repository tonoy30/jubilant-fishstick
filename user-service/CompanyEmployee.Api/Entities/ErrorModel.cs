using System.Text.Json;

namespace CompanyEmployee.Api.Entities;

public class ErrorModel
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public override string ToString() => JsonSerializer.Serialize(this);
}