using Shawa.Domain.Restaurant;

namespace Shawa.Application.Repositories;

public interface IRestaurantRepository
{
    Task<Restaurant> ReplaceOneAsync(Restaurant restaurant,
        CancellationToken cancellationToken = default);
}