using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Shawa.Infrastructure.Entities.Restaurant;

public class MenuEntity
{
    [BsonId(IdGenerator = typeof(CombGuidGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public string Name { get; set; }
    
    public IEnumerable<FoodEntity> Food { get; set; }
}