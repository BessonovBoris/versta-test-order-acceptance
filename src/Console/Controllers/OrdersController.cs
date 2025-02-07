using Application.Contracts;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Console.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController(IOrderService orderService) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateOrder([FromBody] Order newOrder)
    {
        newOrder.PickupDate = DateTime.SpecifyKind(newOrder.PickupDate, DateTimeKind.Utc);
        orderService.AddOrder(newOrder);
        return Ok();
    }

    [HttpGet("{orderId:int}")]
    public async Task<IActionResult> GetOrder(int orderId)
    {
        Order? order = await orderService.GetOrderByIdAsync(orderId).ConfigureAwait(false);
        return order != null ? Ok(order) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        IEnumerable<Order> orders = await orderService.GetAllOrders().ConfigureAwait(false);
        return Ok(orders);
    }
}