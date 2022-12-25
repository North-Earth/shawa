using Shawa.Application.Repositories;
using Shawa.Application.Services;
using Shawa.Domain.Order;
using Shawa.Domain.Restaurant;

namespace Shawa.Api.Services;

public class OrderService: IOrderService
{
    private readonly ILogger<OrderService> _logger;
    private readonly IOrderRepository _orderRepository;
    private readonly IRestaurantRepository _restaurantRepository;

    public OrderService(ILogger<OrderService> logger, 
        IOrderRepository orderRepository, 
        IRestaurantRepository restaurantRepository)
    {
        _logger = logger;
        _orderRepository = orderRepository;
        _restaurantRepository = restaurantRepository;
    }
    
    public Task<Order> GetById(string id, 
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new NotImplementedException();
        }

        return _orderRepository.FindByIdAsync(id, cancellationToken);
    }

    public Task<Order> Create(string name, string restaurantId, 
        string restaurantMenuId, string channelId, string creator,
        CancellationToken cancellationToken = default)
    {
        var metadata = new OrderMetadata(channelId, 
            restaurantId, restaurantMenuId);

        throw new NotImplementedException();
        // var order = new Order(name, creator, metadata);

        // return _orderRepository.ReplaceOneAsync(order, cancellationToken);
    }

    public async Task<Order> UpdateDetailAsync(string orderId, string detailId, 
        Visitor visitor,
        IDictionary<string, IEnumerable<string>> foodIngredients,
        CancellationToken cancellationToken = default)
    {
        var order = await _orderRepository.FindByIdAsync(orderId, cancellationToken);
        var menu = await _restaurantRepository.FindMenuByIdAsync(order.Metadata.RestaurantId,
            order.Metadata.RestaurantMenuId, cancellationToken);

        var food = foodIngredients.Select(foodIngredient 
            => menu.Food.FirstOrDefault(x => x.Id == foodIngredient.Key)?
                .AsOrderDetailsFood(foodIngredient.Value))
            .Where(orderDetailsFood => orderDetailsFood is not null)
            .ToList();
        
        // order.UpdateDetails();

        var detail = new OrderDetail(detailId, visitor, food);

        return await _orderRepository.ReplaceOneDetailAsync(orderId, detail, cancellationToken);
    }
}