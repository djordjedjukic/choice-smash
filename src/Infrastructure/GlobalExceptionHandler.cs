using System.Security.Authentication;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ChoiceSmash.Infrastructure;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        ProblemDetails problemDetails = new ProblemDetails();

        switch (exception)
        {
            case ValidationException ex:
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Title = "One or more validation errors occurred.";
                problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
                problemDetails.Extensions["errors"] = ex.Errors;
                
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
            default:
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                problemDetails.Title = "An unexpected error occurred. Please try again later.";
                problemDetails.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
#if DEBUG
                problemDetails.Extensions = new Dictionary<string, object?>
                {
                    { "message", new[] { exception.Message } },
                    { "stack trace", new[] { exception.StackTrace } }
                };
#endif

                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);
                break;
        }

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }

    /*private static Dictionary<string, string[]> MapValidationErrors(ValidationException ex)
    {
        var errors = new Dictionary<string, string[]>();
        foreach (var error in ex.Errors)
        {
            if (!errors.ContainsKey(error.Error))
            {
                errors[error.Error] = [error.Message];
            }
            else
            {
                var errorList = errors[error.Error].ToList();
                errorList.Add(error.Message);
                errors[error.Error] = errorList.ToArray();
            }
        }

        return errors;
    }*/
}