using WebApplication8.Exceptions;
using WebApplication8.Models;

namespace WebApplication8.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var response = new ErrorResponse
            {
                Timestamp = DateTime.UtcNow
            };

            switch (ex)
            {
                case NotFoundException:
                    response.StatusCode = 404;
                    response.Message = ex.Message;
                    context.Response.StatusCode = 404;
                    break;

                case ValidationException:
                    response.StatusCode = 400;
                    response.Message = ex.Message;
                    context.Response.StatusCode = 400;
                    break;

                case DatabaseException:
                    response.StatusCode = 500;
                    response.Message = "Database error occurred";
                    context.Response.StatusCode = 500;
                    break;

                default:
                    response.StatusCode = 500;
                    response.Message = "Something went wrong";
                    context.Response.StatusCode = 500;
                    break;
            }

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
    
