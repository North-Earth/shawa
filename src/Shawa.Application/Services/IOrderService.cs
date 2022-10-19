using Shawa.Domain.Order;

namespace Shawa.Application.Services;

public interface IOrderService
{
    Task<Order> GetOrder(string orderId);
    
    Task CreateOrder(string name);
    
    Task<Order> CompleteOrder(string orderId);
    
    Task AddOrderDetail();
    
    Task RemoveOrderDetail(string orderDetailId);
}