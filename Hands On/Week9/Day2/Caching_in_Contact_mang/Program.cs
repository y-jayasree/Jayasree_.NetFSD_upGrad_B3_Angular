using WebApplication10.Repositories;
using WebApplication10.Services;

namespace WebApplication10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add controllers
            builder.Services.AddControllers();

            // Enable in-memory caching
            builder.Services.AddMemoryCache();

            // Dependency Injection
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IContactService, ContactService>();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
