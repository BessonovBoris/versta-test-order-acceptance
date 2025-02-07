using Application.Models;
using Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repository;

public class UserRepository : DbContext, IUserRepository
{
    public UserRepository(DbContextOptions<UserRepository> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public Task<User?> FindByUsernameAsync(string username, string password)
    {
        try
        {
            return Users.SingleOrDefaultAsync(user => user.Name == username && user.Password == password);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"More that one user with name: {username}, password: {password}" + e);
            throw;
        }
    }

    public void Add(User user)
    {
        Users.Add(user);
        SaveChangesAsync().ConfigureAwait(false);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { UserId = 1, Name = "Andrew", Password = "AndrewPassword" },
            new User { UserId = 2, Name = "Tom", Password = "TomPassword" },
            new User { UserId = 3, Name = "Bob", Password = "BobPassword" },
            new User { UserId = 4, Name = "Sam", Password = "SamPassword" });
    }
}