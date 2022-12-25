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

    public Task<Restaurant> GetById(string id, 
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new NotImplementedException();
        }

        return _repository.FindByIdAsync(id, cancellationToken);
    }

    public Task<IEnumerable<Restaurant>> GetAll(
        CancellationToken cancellationToken = default)
    {
        return _repository.FindAllAsync(cancellationToken);
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

    public Task<Restaurant> Update(Restaurant restaurant, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id, 
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new NotImplementedException();
        }

        return _repository.DeleteOneAsync(id, cancellationToken);
    }
}