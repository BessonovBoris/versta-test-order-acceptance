using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataBase.Repository;

public class OrderRepositoryDesignTimeFactory : IDesignTimeDbContextFactory<OrderRepository>
{
    public OrderRepository CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OrderRepository>();
        string connectionString = "Host=localhost;Port=5432;Database=versta;Username=postgres;Password=postgres";
        optionsBuilder.UseNpgsql(connectionString);
        return new OrderRepository(optionsBuilder.Options);
    }
}