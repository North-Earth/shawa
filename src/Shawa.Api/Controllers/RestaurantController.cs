using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Shawa.Api.Controllers;

[ApiController]
[ApiVersion(1.0)]
[Route("shawa/api/v{version:apiVersion}/restaurants")]
public class RestaurantController: ControllerBase
{
    [HttpGet]
    public Task<IActionResult> GetRestaurants()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("{restaurantId}")]
    public Task<IActionResult> GetRestaurant(string restaurantId)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("{restaurantId}")]
    public Task<IActionResult> CreateRestaurant(string restaurantId)
    {
        throw new NotImplementedException();
    }
    
    [HttpPut("{restaurantId}")]
    public Task<IActionResult> UpdateRestaurant(string restaurantId)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{restaurantId}")]
    public Task<IActionResult> DeleteRestaurant(string restaurantId)
    {
        throw new NotImplementedException();
    }
}