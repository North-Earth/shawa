namespace Shawa.Infrastructure.Configuration;

public class MongoSettings
{
    public string? ConnectionString { get; init; }
    
    public string? DatabaseName { get; init; }
    
    public string? RestaurantsCollectionName { get; init; }
    
    public string? OrdersCollectionName { get; init; }
}