using System.Net;
using CompanyEmployee.Api.Entities;
using CompanyEmployee.Api.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace CompanyEmployee.Api.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(err =>
        {
            err.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    Log.Error("Something went wrong: {Error}", contextFeature.Error.ToString());
                    await context.Response.WriteAsync(new ErrorModel
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message
                    }.ToString());
                }
            });
        });
    }
}