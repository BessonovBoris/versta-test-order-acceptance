using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models;

namespace Application.Contracts;

public interface IOrderService
{
    void AddOrder(Order order);
    Task<Order?> GetOrderByIdAsync(int orderId);
    Task<IEnumerable<Order>> GetAllOrders();
}