using Application.Application;
using Application.Contracts;
using Application.Repositories;
using DataBase;
using DataBase.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllCors", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

string? connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddDbContext<IUserRepository, UserRepository>(options => options.UseNpgsql(connectionString, o => o.SetPostgresVersion(new Version(17, 2, 1))));
builder.Services.AddDbContext<IOrderRepository, OrderRepository>(options => options.UseNpgsql(connectionString, o => o.SetPostgresVersion(new Version(17, 2, 1))));
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddControllers();

WebApplication app = builder.Build();

DatabaseInitializer.Initialize(app.Services);
app.UseCors("AllowAllCors");
app.MapControllers();

app.Run();