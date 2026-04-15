using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;
using WebApplication14.Data;
using WebApplication14.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContactDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ContactService>();


//builder.Services.AddScoped<IContactRepository, ContactRepository>();
//builder.Services.AddScoped<IContactService, ContactService>();


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRateLimiter();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
