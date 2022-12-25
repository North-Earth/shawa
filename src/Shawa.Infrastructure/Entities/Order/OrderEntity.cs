using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Shawa.Domain.Order;

namespace Shawa.Infrastructure.Entities.Order;

public class OrderEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    public string Name { get; set; }

    public string Creator { get; set; }
    
    public DateTime Created { get; set; }
    
    public OrderStatus Status { get; set; }

    public DateTime? Completed { get; set; }
    
    public OrderMetadataEntity Metadata { get; set; }
    
    public OrderDetailEntity OrderDetail { get; set; }
}