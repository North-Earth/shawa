using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Shawa.Infrastructure.Entities.Restaurant;

public class RestaurantEntity
{
    [BsonId(IdGenerator = typeof(CombGuidGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }

    public string Owner { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string TelegramChannel { get; set; }

    public IEnumerable<MenuEntity> Menus { get; set; }
}