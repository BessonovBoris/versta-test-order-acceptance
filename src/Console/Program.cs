using Application.Models;
using Application.Repositories;
using DataBase.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();

string? connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddDbContext<IUserRepository, UserRepository>(options => options.UseNpgsql(connectionString, o => o.SetPostgresVersion(new Version(17, 2, 1))));
builder.Services.AddDbContext<IOrderRepository, OrderRepository>(options => options.UseNpgsql(connectionString, o => o.SetPostgresVersion(new Version(17, 2, 1))));

WebApplication app = builder.Build();

app.UseCors("AllowAll");

using (IServiceScope scope = app.Services.CreateScope())
{
    UserRepository userRepository = scope.ServiceProvider.GetRequiredService<UserRepository>();
    userRepository.Database.Migrate();
}

using (IServiceScope scope = app.Services.CreateScope())
{
    OrderRepository orderRepository = scope.ServiceProvider.GetRequiredService<OrderRepository>();
    orderRepository.Database.Migrate();
}

app.MapGet("/", () => "Hello World!");
app.MapPost("/api/orders/", async ([FromServices] IOrderRepository orderRepository, HttpContext context) =>
{
    Order newOrder = await context.Request.ReadFromJsonAsync<Order>().ConfigureAwait(false) ?? throw new AggregateException("Invalid request");

    Console.WriteLine(newOrder);

    orderRepository.AddOrder(newOrder);
});

app.MapGet("/api/orders/{orderId:int}", async (int orderId, [FromServices] IOrderRepository orderRepository, HttpContext context) =>
{
    Order order = await orderRepository.FindOrderById(orderId).ConfigureAwait(false) ?? throw new AggregateException("Invalid request");
    await context.Response.WriteAsJsonAsync(order).ConfigureAwait(false);
});

app.MapGet("/api/orders/", async ([FromServices] OrderRepository orderRepository, HttpContext context) =>
{
    IEnumerable<Order> orders = orderRepository.Orders.ToList();
    await context.Response.WriteAsJsonAsync(orders).ConfigureAwait(false);
});

app.Run();