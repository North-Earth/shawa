using Shawa.Domain.Restaurant;

namespace Shawa.Application.Services;

public interface IRestaurantService
{
    Task<Restaurant> Create(Restaurant restaurant, 
        CancellationToken cancellationToken = default);
}