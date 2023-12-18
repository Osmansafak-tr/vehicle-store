using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VehicleStore.Server.Common;
using VehicleStore.Server.Database;
using VehicleStore.Server.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"))
);
builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

var app = builder.Build(); 

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    SeedData.Initialize(service);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();