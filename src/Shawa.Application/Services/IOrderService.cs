using Shawa.Domain.Order;

namespace Shawa.Application.Services;

public interface IOrderService
{
    Task<Order> GetById(string id,
        CancellationToken cancellationToken = default);

    Task<Order> Create(string name, string restaurantId,
        string restaurantMenuId, string channelId, string creator,
        CancellationToken cancellationToken = default);

    Task<Order> UpdateDetailAsync(string orderId, string detailId,
        Visitor visitor,
        IDictionary<string, IEnumerable<string>> foodIngredients,
        CancellationToken cancellationToken = default);
}