using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Shawa.Api.Controllers;

[ApiController]
[ApiVersion(1.0)]
[Route("shawa/api/v{version:apiVersion}/orders")]
public class OrderController: ControllerBase
{
    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{orderId}")]
    public Task<IActionResult> GetOrder(string orderId)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("")]
    public Task<IActionResult> CreateOrder()
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("{orderId}/close")]
    public Task<IActionResult> CloseOrder(string orderId)
    {
        throw new NotImplementedException();
    }
}