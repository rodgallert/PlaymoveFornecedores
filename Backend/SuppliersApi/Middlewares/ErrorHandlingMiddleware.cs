using Suppliers.Domain.Exceptions;
using System.Text.Json;

namespace Suppliers.Api.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BadRequestException ex)
        {
            var response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = StatusCodes.Status400BadRequest;

            var result = JsonSerializer.Serialize(new { error = ex.Message });

            await response.WriteAsync(result);
        }
        catch (Exception)
        {
            var response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = StatusCodes.Status400BadRequest;

            var result = JsonSerializer.Serialize(new { error = "Something went wrong. Please, contact support." });

            await response.WriteAsync(result);
        }
    }
}
