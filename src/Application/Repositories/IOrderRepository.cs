using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models;

namespace Application.Repositories;

public interface IOrderRepository
{
    Task<Order?> FindOrderById(int orderId);
    Task<IEnumerable<Order>> GetUserOrders(int userId);
    Task<IEnumerable<Order>> GetAllOrders();
    void AddOrder(Order order);
}