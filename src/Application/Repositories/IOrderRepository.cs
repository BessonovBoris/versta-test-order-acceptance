using Application.Models;

namespace Application.Repositories;

public interface IOrderRepository
{
    Task<Order?> GetOrderById(int orderId);
    Task<IEnumerable<Order>> GetUserOrders(int userId);
}