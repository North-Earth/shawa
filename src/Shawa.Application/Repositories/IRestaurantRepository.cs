using Shawa.Domain.Restaurant;

namespace Shawa.Application.Repositories;

public interface IRestaurantRepository
{
    Task<Restaurant> FindByIdAsync(string id, 
        CancellationToken cancellationToken = default);
    
    Task<Menu> FindMenuByIdAsync(string restaurantId, string menuId, 
        CancellationToken cancellationToken = default);
    
    Task<IEnumerable<Restaurant>> FindAllAsync(
        CancellationToken cancellationToken = default);
    
    Task<Restaurant> ReplaceOneAsync(Restaurant restaurant,
        CancellationToken cancellationToken = default);
    
    Task DeleteOneAsync(string id, 
        CancellationToken cancellationToken = default);
}