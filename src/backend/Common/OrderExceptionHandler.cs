using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OrdersList.Common;

public sealed class OrderExceptionHandler(IHostEnvironment env) : IExceptionHandler
{
    private const string ServerError = "An internal server error occurred.";

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var problem = CreateProblemDetails(httpContext, exception);
        await httpContext.Response.WriteAsJsonAsync(
            problem,
            cancellationToken
        );

        return true;
    }

    private ProblemDetails CreateProblemDetails(HttpContext httpContext, Exception exception)
    {
        var (statusCode, title, detail) = exception switch
        {
            _ => (StatusCodes.Status500InternalServerError, "Internal server error", ServerError)
        };

        httpContext.Response.StatusCode = statusCode;

        var problem = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
            Instance = httpContext.Request.Path
        };

        if (env.IsDevelopment())
        {
            problem.Detail = exception.ToString();
        }

        return problem;
    }
}