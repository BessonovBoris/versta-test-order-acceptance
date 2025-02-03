namespace Application.Models;

public record Order(int OrderId, string SenderCity, string SenderAddress, string ReceiverCity, string ReceiverAddress, double CargoWeightKg, DateTime PickupDate);