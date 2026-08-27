using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using OrdersList.DTOs;
using OrdersList.Models;

namespace OrdersList.Data;

public class SQLiteOrderRepository(AppDbContext context) : IOrderRepository
{
    public async Task AddOrderAsync(OrderDto orderDto)
    {
        var senderAddress = new Address
        {
            Locality = orderDto.SenderAddress.Locality,
            StreetAddress = orderDto.SenderAddress.StreetAddress
        };

        var receiverAddress = new Address
        {
            Locality = orderDto.ReceiverAddress.Locality,
            StreetAddress = orderDto.ReceiverAddress.StreetAddress
        };

        context.Addresses.AddRange(senderAddress, receiverAddress);
        await context.SaveChangesAsync();

        var order = new Order
        {
            SenderAddress = senderAddress,
            ReceiverAddress = receiverAddress,
            Weight = orderDto.Weight,
            PickupDate = orderDto.PickupDate,
            CreatedAt = DateTime.UtcNow
        };

        context.Orders.Add(order);
        await context.SaveChangesAsync();
    }
    public async Task<List<OrderDto>> GetAllOrdersAsync()
    {
        return await context.Orders
            .Select(order => new OrderDto(
                order.Id,
                new AddressDto(
                    order.SenderAddress.Locality,
                    order.SenderAddress.StreetAddress),

                new AddressDto(
                    order.ReceiverAddress.Locality,
                    order.ReceiverAddress.StreetAddress),

                order.Weight,
                order.PickupDate
            ))
            .ToListAsync();
    }
    public async Task<OrderDto?> GetOrder(long order_id)
    {
        var order = await context.Orders
            .Include(o => o.SenderAddress)
            .Include(o => o.ReceiverAddress)
            .FirstOrDefaultAsync(o => o.Id == order_id);
        return order is not null ? new OrderDto(
            order.Id,
            new AddressDto(
                order.SenderAddress.Locality,
                order.SenderAddress.StreetAddress),

            new AddressDto(
                order.ReceiverAddress.Locality,
                order.ReceiverAddress.StreetAddress),

            order.Weight,
            order.PickupDate
        ) : null;
    }
}