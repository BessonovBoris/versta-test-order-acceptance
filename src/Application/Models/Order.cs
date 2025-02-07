using System;

namespace Application.Models;

public class Order
{
    public Order(int orderId, int userId, string senderCity, string senderAddress, string receiverCity, string receiverAddress, double cargoWeightKg, DateTime pickupDate)
    {
        OrderId = orderId;
        UserId = userId;
        SenderCity = senderCity;
        SenderAddress = senderAddress;
        ReceiverCity = receiverCity;
        ReceiverAddress = receiverAddress;
        CargoWeightKg = cargoWeightKg;
        PickupDate = pickupDate;
    }

    public int OrderId { get; set; }
    public int UserId { get; set; }
    public string? SenderCity { get; set; }
    public string? SenderAddress { get; set; }
    public string? ReceiverCity { get; set; }
    public string? ReceiverAddress { get; set; }
    public double CargoWeightKg { get; set; }
    public DateTime PickupDate { get; set; }
}