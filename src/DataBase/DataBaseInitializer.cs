using DataBase.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataBase;

public static class DatabaseInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        try
        {
            OrderRepository orderRepository = scope.ServiceProvider.GetRequiredService<OrderRepository>();
            orderRepository.Database.Migrate();
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Order service didn't connect to data base" + e);
        }

        try
        {
            UserRepository userRepository = scope.ServiceProvider.GetRequiredService<UserRepository>();
            userRepository.Database.Migrate();
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("User service didn't connect to data base" + e);
        }
    }
}
