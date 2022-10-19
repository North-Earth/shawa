using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Shawa.Infrastructure.Entities.Restaurant;

public class IngredientEntity
{
    [BsonId(IdGenerator = typeof(CombGuidGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public string Name { get; set; }
    
    public string Emoji { get; set; }
    
    public decimal Cost { get; set; }
}