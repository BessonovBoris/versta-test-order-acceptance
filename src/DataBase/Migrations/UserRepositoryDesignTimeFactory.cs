using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataBase.Repository;

public class UserRepositoryDesignTimeFactory : IDesignTimeDbContextFactory<UserRepository>
{
    public UserRepository CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UserRepository>();
        string connectionString = "Host=localhost;Port=5432;Database=versta;Username=postgres;Password=postgres";
        optionsBuilder.UseNpgsql(connectionString);
        return new UserRepository(optionsBuilder.Options);
    }
}