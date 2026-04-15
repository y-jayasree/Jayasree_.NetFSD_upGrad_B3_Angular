using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;
using WebApplication14.Data;
using WebApplication14.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRateLimiter(options =>
{
    options.AddPolicy("fixed", httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContext.Connection.RemoteIpAddress?.ToString(), // IP based
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 5,              // 5 requests
                Window = TimeSpan.FromSeconds(60), // per 60 sec
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                QueueLimit = 0                // no queue
            }));

    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = 429;
        await context.HttpContext.Response.WriteAsync(
            "Too many requests. Please try again later.", token);
    };
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRateLimiter();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
