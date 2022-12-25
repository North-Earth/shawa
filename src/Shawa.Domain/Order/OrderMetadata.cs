namespace Shawa.Domain.Order;

public class OrderMetadata
{
    public string RestaurantId { get; }
    
    public string RestaurantMenuId { get; }
    
    public string ChannelId { get; }
    
    public OrderMetadata(string channelId, string restaurantId, 
        string restaurantMenuId)
    {
        ChannelId = channelId;
        RestaurantId = restaurantId;
        RestaurantMenuId = restaurantMenuId;
    }
}