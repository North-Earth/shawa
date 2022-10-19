using Shawa.Application.Repositories;
using Shawa.Application.Services;
using Shawa.Domain.Restaurant;

namespace Shawa.Api.Services;

public class RestaurantService: IRestaurantService
{
    private readonly ILogger<RestaurantService> _logger;
    private readonly IRestaurantRepository _repository;
        
    public RestaurantService(ILogger<RestaurantService> logger, 
        IRestaurantRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public Task<Restaurant> Create(Restaurant restaurant, 
        CancellationToken cancellationToken = default)
    {
        if (restaurant.Id is not null)
        {
            throw new NotImplementedException();
        }
        
        return _repository.ReplaceOneAsync(restaurant, cancellationToken);
    }
}