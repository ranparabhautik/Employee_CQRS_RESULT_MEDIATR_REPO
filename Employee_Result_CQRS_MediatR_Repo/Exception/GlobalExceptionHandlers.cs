using Microsoft.AspNetCore.Diagnostics;

namespace Employee_Result_CQRS_MediatR_Repo.Exception;

public class GlobalExceptionHandlers (ILogger logger): IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, exception.Message);
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(new{Message = exception.Message},cancellationToken);
        return true;
    }
}                                       