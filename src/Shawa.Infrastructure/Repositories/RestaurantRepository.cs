using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shawa.Application.Repositories;
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

    // public Task<Domain.Restaurant.Restaurant> GetByIdAsync(string id, 
    //     CancellationToken cancellationToken = default)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public async Task<IEnumerable<Domain.Restaurant.Restaurant>> GetAllAsync(
    //     CancellationToken cancellationToken = default)
    // {
    //     var entities = await _collection
    //         .Find(_ => true)
    //         .ToListAsync(cancellationToken: cancellationToken);
    //     
    //     if (entities is null || !entities.Any())
    //     {
    //         throw new NotImplementedException();
    //     }
    //     
    //     var data = _mapper.Map<IEnumerable<Domain.Restaurant.Restaurant>>(entities);
    //
    //     if (data is null)
    //     {
    //         throw new NotImplementedException();
    //     }
    //
    //     return data;
    // }
    //
    // public async Task<Domain.Restaurant.Restaurant> InsertOneAsync(Domain.Restaurant.Restaurant restaurant, 
    //     CancellationToken cancellationToken = default)
    // {
    //     var entity = _mapper.Map<RestaurantEntity>(restaurant);
    //
    //     var filter = 1;
    //     var options = 1;
    //
    //     await _collection.InsertOneAsync(entity, cancellationToken);
    //
    //     return restaurant;
    // }
    //
    // public Task<Domain.Restaurant.Restaurant> UpdateOneAsync(string id, 
    //     Domain.Restaurant.Restaurant restaurant, 
    //     CancellationToken cancellationToken = default)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public void DeleteByIdAsync(string id, 
    //     CancellationToken cancellationToken = default)
    // {
    //     throw new NotImplementedException();
    // }
}