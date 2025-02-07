using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Models;
using Application.Repositories;

namespace Application.Application;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    public void AddOrder(Order order)
    {
        orderRepository.AddOrder(order);
    }

    public Task<Order?> GetOrderByIdAsync(int orderId)
    {
        return orderRepository.FindOrderById(orderId);
    }

    public Task<IEnumerable<Order>> GetAllOrders()
    {
        return orderRepository.GetAllOrders();
    }
}