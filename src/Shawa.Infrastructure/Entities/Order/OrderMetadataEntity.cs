using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shawa.Infrastructure.Entities.Order;

public class OrderMetadataEntity
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string RestaurantId { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    public string RestaurantMenuId { get; set; }
    
    public string ChannelId { get; set; }
}