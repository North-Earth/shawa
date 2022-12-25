using Shawa.Domain.Restaurant;

namespace Shawa.Application.Services;

public interface IRestaurantService
{
    Task<Restaurant> GetById(string id, 
        CancellationToken cancellationToken = default);
    
    Task<IEnumerable<Restaurant>> GetAll(
        CancellationToken cancellationToken = default);
    
    Task<Restaurant> Create(Restaurant restaurant, 
        CancellationToken cancellationToken = default);
    
    Task<Restaurant> Update(Restaurant restaurant, 
        CancellationToken cancellationToken = default);
    
    Task Delete(string id, 
        CancellationToken cancellationToken = default);
}