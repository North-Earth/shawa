using Shawa.Application.Services;
using Shawa.Domain.Order;

namespace Shawa.Api.Services;

public class OrderService: IOrderService
{
    
    // TODO: order cache

    public OrderService()
    {
        
    }
    
    public Task<Order> GetOrder(string orderId)
    {
        throw new NotImplementedException();
    }

    Task IOrderService.CreateOrder(string name)
    {
        return CreateOrder(name);
    }

    public Task<Order> CreateOrder(string name)
    {
        var order = new Order(string.Empty, name, 
            DateTime.UtcNow, Array.Empty<OrderDetail>());
        
        // TODO: send to repository

        return Task.FromResult(order);
    }

    public Task<Order> CompleteOrder(string orderId)
    {
        // TODO: get from repository or cache
        
        // TODO: send update to repository
        
        throw new NotImplementedException();
    }

    public Task AddOrderDetail()
    {
        throw new NotImplementedException();
    }

    public Task RemoveOrderDetail(string orderDetailId)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateOrderDetail()
    {
        // TODO: get from repository or cache
        
        
        throw new NotImplementedException();
    }
}