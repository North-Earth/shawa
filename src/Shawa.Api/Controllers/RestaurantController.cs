using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shawa.Api.Models.Requests;
using Shawa.Application.Services;
using Shawa.Domain.Restaurant;

namespace Shawa.Api.Controllers;

[ApiController]
[ApiVersion(1.0)]
[Route("shawa/api/v{version:apiVersion}/restaurants")]
public class RestaurantController: ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<RestaurantController> _logger;
    private readonly IRestaurantService  _restaurantService;
    
    public RestaurantController(IMapper mapper, 
        ILogger<RestaurantController> logger, 
        IRestaurantService restaurantService)
    {
        _mapper = mapper;
        _logger = logger;
        _restaurantService = restaurantService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Restaurant>> GetRestaurants(
        CancellationToken cancellationToken = default)
    {
        var result = await _restaurantService.GetAll(cancellationToken);

        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Restaurant>> GetRestaurantById(string id, 
        CancellationToken cancellationToken = default)
    {
        var result = await _restaurantService.GetById(id, cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Restaurant>> CreateRestaurant(
        [FromBody] CreateRestaurantRequest request, 
        CancellationToken cancellationToken = default)
    {
        var restaurant = _mapper.Map<Restaurant>(request.Restaurant);

        var result = await _restaurantService
            .Create(restaurant, cancellationToken);

        return Created($"{result.Id}", result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Restaurant>> DeleteRestaurant(string id,
        CancellationToken cancellationToken = default)
    {
        await _restaurantService.Delete(id, cancellationToken);

        return NoContent();
    }
}