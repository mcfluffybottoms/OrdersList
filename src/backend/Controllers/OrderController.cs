using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;
using OrdersList.DTOs;
using OrdersList.Models;
using OrdersList.Services;
 
namespace OrdersList.Controllers;

[ApiController]
[Route("orders")]
public class OrderController(OrderService service) : ControllerBase
{
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateOrder(OrderCreateDto order)
    {
        await service.AddOrderAsync(order);
        return Created();
    }

    [HttpGet]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllOrdersAsync()
    {
        var orders = await service.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{order_id}")]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllOrdersAsync(long order_id)
    {
        var orderResult = await service.GetOrder(order_id);
        return orderResult is not null ? Ok(orderResult) : NotFound();
    }
}
