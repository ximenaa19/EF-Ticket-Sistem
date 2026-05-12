using System.Net;
using AirlineTicketSystem.Domain.Exceptions;
using FluentValidation;

namespace AirlineTicketSystem.Api.Middlewares;

public sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException exception)
        {
            await WriteValidationProblemAsync(context, exception);
        }
        catch (EntityNotFoundException exception)
        {
            await WriteProblemAsync(context, HttpStatusCode.NotFound, "Entity not found", exception.Message);
        }
        catch (DuplicateEntityException exception)
        {
            await WriteProblemAsync(context, HttpStatusCode.Conflict, "Duplicate entity", exception.Message);
        }
        catch (DomainException exception)
        {
            await WriteProblemAsync(context, HttpStatusCode.BadRequest, "Domain error", exception.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Unhandled exception while processing request.");
            await WriteProblemAsync(
                context,
                HttpStatusCode.InternalServerError,
                "Unexpected error",
                "An unexpected error occurred while processing the request.");
        }
    }

    private static async Task WriteValidationProblemAsync(HttpContext context, ValidationException exception)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.ContentType = "application/json";

        var errors = exception.Errors
            .GroupBy(error => error.PropertyName)
            .ToDictionary(
                group => group.Key,
                group => group.Select(error => error.ErrorMessage).ToArray());

        var response = new
        {
            title = "Validation error",
            status = StatusCodes.Status400BadRequest,
            errors
        };

        await context.Response.WriteAsJsonAsync(response);
    }

    private static async Task WriteProblemAsync(
        HttpContext context,
        HttpStatusCode statusCode,
        string title,
        string detail)
    {
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        var response = new
        {
            title,
            status = (int)statusCode,
            detail
        };

        await context.Response.WriteAsJsonAsync(response);
    }
}
