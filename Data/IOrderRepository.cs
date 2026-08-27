using OrdersList.DTOs;

namespace OrdersList.Data;

public interface IOrderRepository
{
    Task AddOrderAsync(OrderDto order);
    Task<List<OrderDto>> GetAllOrdersAsync();
    Task<OrderDto?> GetOrder(long order_id);
}