using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace ShopEZ.Middleware
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
                _logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var (status, message) = ex switch
            {
                KeyNotFoundException => (HttpStatusCode.NotFound, ex.Message),

                ArgumentException => (HttpStatusCode.BadRequest, ex.Message),

                InvalidOperationException => (HttpStatusCode.Conflict, ex.Message),

                DbUpdateException => (HttpStatusCode.Conflict, "Cannot delete product because it is used in orders."),

                UnauthorizedAccessException => (HttpStatusCode.Unauthorized, ex.Message),

                _ => (HttpStatusCode.InternalServerError, ex.Message)
            };


            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            var result = JsonSerializer.Serialize(new
            {
                statusCode = (int)status,
                message
            });

            return context.Response.WriteAsync(result);
        }
    }
}

