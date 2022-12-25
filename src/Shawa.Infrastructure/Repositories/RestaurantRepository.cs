using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shawa.Application.Repositories;
using Shawa.Domain.Restaurant;
using Shawa.Infrastructure.Configuration;
using Shawa.Infrastructure.Entities.Restaurant;

namespace Shawa.Infrastructure.Entities;

public class RestaurantRepository: IRestaurantRepository
{
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;
    private readonly ILogger<RestaurantRepository> _logger;
    private readonly IMongoCollection<RestaurantEntity> _collection;

    public RestaurantRepository(IMapper mapper, IMemoryCache cache, 
        ILogger<RestaurantRepository> logger, IOptions<MongoSettings> mongoSettings)
    {
        _mapper = mapper;
        _cache = cache;
        _logger = logger;
        
        var mongoClient = new MongoClient(
            mongoSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mongoSettings.Value.DatabaseName);
        
        _collection = mongoDatabase.GetCollection<RestaurantEntity>(
            mongoSettings.Value.RestaurantsCollectionName);
    }

    public async Task<Domain.Restaurant.Restaurant> FindByIdAsync(string id,
        CancellationToken cancellationToken = default)
    {
        var entity = await _collection
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        
        if (entity is null)
        {
            throw new NotImplementedException();
        }
        
        var result = _mapper.Map<Domain.Restaurant.Restaurant>(entity);

        return result;
    }

    public async Task<Menu> FindMenuByIdAsync(string restaurantId, string menuId, 
        CancellationToken cancellationToken = default)
    {
        var customProjection = Builders<RestaurantEntity>
            .Projection.Expression(r => r.Menus.FirstOrDefault(x => x.Id == menuId));
        
        var entity = await _collection
            .Find(x => x.Id == restaurantId)
            .Project(customProjection)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (entity is null)
        {
            throw new NotImplementedException();
        }
        
        var result = _mapper.Map<Menu>(entity);
        
        return result;
    }

    public async Task<IEnumerable<Domain.Restaurant.Restaurant>> FindAllAsync(
        CancellationToken cancellationToken = default)
    {
        var entities = await _collection
            .Find(_ => true)
            .ToListAsync(cancellationToken: cancellationToken);
        
        if (entities is null || entities.Count == 0)
        {
            throw new NotImplementedException();
        }

        var result = _mapper.Map<IEnumerable<Domain.Restaurant.Restaurant>>(entities);

        return result;
    }

    public async Task<Domain.Restaurant.Restaurant> ReplaceOneAsync(
        Domain.Restaurant.Restaurant restaurant, 
        CancellationToken cancellationToken = default)
    {
        var document = _mapper.Map<RestaurantEntity>(restaurant);

        if (document is null)
        {
            throw new NotImplementedException();
        }

        var filter = Builders<RestaurantEntity>.Filter
            .Eq(x => x.Id, document.Id);

        var options = new FindOneAndReplaceOptions<RestaurantEntity>
        {
            ReturnDocument = ReturnDocument.After,
            IsUpsert = true
        };

        var entity = await _collection.FindOneAndReplaceAsync(filter, document, 
            options, cancellationToken);

        if (entity is null)
        {
            throw new NotImplementedException();
        }
        
        var result = _mapper.Map<Domain.Restaurant.Restaurant>(entity);

        return result;
    }

    public async Task DeleteOneAsync(string id, 
        CancellationToken cancellationToken = default)
    {
        await _collection.DeleteOneAsync(x => x.Id == id, 
            cancellationToken: cancellationToken);
    }
}