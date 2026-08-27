using OrdersList.Data;
using OrdersList.DTOs;

namespace OrdersList.Services;

public class OrderService(IOrderRepository repo)
{
    public async Task AddOrderAsync(OrderDto order) {
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