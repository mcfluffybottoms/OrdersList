using OrdersList.Data;
using OrdersList.DTOs;

namespace OrdersList.Services;

public class OrderService(IOrderRepository repo)
{
    public async Task AddOrderAsync(OrderCreateDto order) {
        if (order.Weight < 1)
            throw new ArgumentException("Weight must be at least 1 gram.");

        if (order.PickupDate.Date < DateTime.Today)
            throw new ArgumentException("Pickup date cannot be earlier than today.");

        if (string.IsNullOrWhiteSpace(order.SenderAddress.Locality) ||
            string.IsNullOrWhiteSpace(order.SenderAddress.StreetAddress))
            throw new ArgumentException("Sender address is required.");

        if (string.IsNullOrWhiteSpace(order.ReceiverAddress.Locality) ||
            string.IsNullOrWhiteSpace(order.ReceiverAddress.StreetAddress))
            throw new ArgumentException("Receiver address is required.");
        await repo.AddOrderAsync(order);
    }

    public async Task<List<OrderDto>> GetAllOrdersAsync()
    {
        return await repo.GetAllOrdersAsync();
    }

    public async Task<OrderDto?> GetOrder(long order_id)
    {
        return await repo.GetOrder(order_id);
    }
}