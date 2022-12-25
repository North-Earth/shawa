using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shawa.Api.Models.Requests;
using Shawa.Application.Services;
using Shawa.Domain.Order;

namespace Shawa.Api.Controllers;

[ApiController]
[ApiVersion(1.0)]
[Route("shawa/api/v{version:apiVersion}/orders")]
public class OrderController: ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderService _orderService;

    public OrderController(IMapper mapper,
        ILogger<OrderController> logger, 
        IOrderService orderService)
    {
        _mapper = mapper;
        _logger = logger;
        _orderService = orderService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(string id, 
        CancellationToken cancellationToken = default)
    {
        var result = await _orderService.GetById(id, cancellationToken);

        return Ok(result);
    }
    
    [HttpPost("")]
    public async Task<ActionResult<Order>> CreateOrder([FromBody] CreateOrderRequest request, 
        CancellationToken cancellationToken = default)
    {
        var result = await _orderService
            .Create(request.OrderName, request.RestourantId,
                request.RestourantMenuId, request.ChannelId, request.CreatorUserName, 
                cancellationToken);

        return Created($"{result.Id}", result);
    }
    
    [HttpPut("{orderId}/details/{detailId}")]
    public async Task<ActionResult<Order>> UpdateOrderDetail(
        string orderId, 
        string orderDetailId,
        [FromBody] UpdateOrderDetailRequest request, 
        CancellationToken cancellationToken = default)
    {
        var foodIngredients = request
            .Food.ToDictionary(food => food.Id, food => food.IngredientsIds);
        var visitor = _mapper.Map<Visitor>(request.Visitor);

       var result = await _orderService.UpdateDetailAsync(orderId, 
            orderDetailId, visitor, foodIngredients, cancellationToken);

        return Ok(result);
    }
    
    
    
    // [HttpPost("{orderId}/complete")]
    // public Task<IActionResult> CompleteOrder(string orderId)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // [HttpPost("{orderId}/details/{orderDetailsId}")]
    // public Task<IActionResult> AddOrderDetails(string orderId, string orderDetailsId)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // [HttpDelete("{orderId}/details/{orderDetailsId}")]
    // public Task<IActionResult> RemoveOrderDetails(string orderId, string orderDetailsId)
    // {
    //     throw new NotImplementedException();
    // }
}