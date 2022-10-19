// using Asp.Versioning;
// using Microsoft.AspNetCore.Mvc;
// using Shawa.Application.Services;
//
// namespace Shawa.Api.Controllers;
//
// [ApiController]
// [ApiVersion(1.0)]
// [Route("shawa/api/v{version:apiVersion}/orders")]
// public class OrderController: ControllerBase
// {
//     private readonly ILogger<OrderController> _logger;
//     private readonly IOrderService _orderService;
//
//     public OrderController(ILogger<OrderController> logger, 
//         IOrderService orderService)
//     {
//         _logger = logger;
//         _orderService = orderService;
//     }
//
//     [HttpGet("{orderId}")]
//     public Task<IActionResult> GetOrder(string orderId)
//     {
//         throw new NotImplementedException();
//     }
//     
//     [HttpPost("")]
//     public Task<IActionResult> CreateOrder()
//     {
//         throw new NotImplementedException();
//     }
//     
//     [HttpPost("{orderId}/complete")]
//     public Task<IActionResult> CompleteOrder(string orderId)
//     {
//         throw new NotImplementedException();
//     }
//     
//     [HttpPost("{orderId}/details/{orderDetailsId}")]
//     public Task<IActionResult> AddOrderDetails(string orderId, string orderDetailsId)
//     {
//         throw new NotImplementedException();
//     }
//     
//     [HttpDelete("{orderId}/details/{orderDetailsId}")]
//     public Task<IActionResult> RemoveOrderDetails(string orderId, string orderDetailsId)
//     {
//         throw new NotImplementedException();
//     }
// }