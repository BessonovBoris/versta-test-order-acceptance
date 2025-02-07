using Application.Models;
using Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repository;

public class OrderRepository : DbContext, IOrderRepository
{
    public OrderRepository(DbContextOptions<OrderRepository> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public Task<Order?> FindOrderById(int orderId)
    {
        ValueTask<Order?> order = Orders.FindAsync(orderId);
        return order.AsTask();
    }

    public Task<IEnumerable<Order>> GetUserOrders(int userId)
    {
        Task<IEnumerable<Order>> a = Orders.Where(o => o.UserId == userId).ToListAsync().ContinueWith(task => (IEnumerable<Order>)task.Result, TaskScheduler.Current);
        return a;
    }

    public void AddOrder(Order order)
    {
        Orders.Add(order);
        SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var dateTime = DateTime.SpecifyKind(DateTime.Today, DateTimeKind.Utc);

        modelBuilder.Entity<Order>().HasData(
            new Order(1, 1, "Saint-Petersburg", "Kolmogorov, 11", "Moscow", "Popova, 5", .5d, dateTime),
            new Order(2, 1, "Saint-Petersburg", "Kolmogorov, 11", "Voronezh", "Kronverskiy, 10", .5d, dateTime),
            new Order(3, 3, "Novgorod", "Petrushka, 5", "Saint-Petersburg", "Tutova, 1", 1d, dateTime),
            new Order(4, 2, "Tula", "Retrogradka, 90", "Norilsk", "Tamova, 9", 1.2d, dateTime));
    }
}