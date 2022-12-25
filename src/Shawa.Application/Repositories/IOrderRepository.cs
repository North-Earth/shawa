using Shawa.Domain.Order;

namespace Shawa.Application.Repositories;

public interface IOrderRepository
{
    Task<Order> FindByIdAsync(string id, 
        CancellationToken cancellationToken = default);

    Task<Order> ReplaceOneAsync(Order order,
        CancellationToken cancellationToken = default);

    Task<Order> ReplaceOneDetailAsync(string orderId, 
        OrderDetail orderDetail,
        CancellationToken cancellationToken = default);
}