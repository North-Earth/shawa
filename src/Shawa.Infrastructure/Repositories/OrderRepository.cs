using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shawa.Application.Repositories;
using Shawa.Domain.Order;
using Shawa.Infrastructure.Configuration;
using Shawa.Infrastructure.Entities.Order;

namespace Shawa.Infrastructure.Repositories;

public class OrderRepository: IOrderRepository
{
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;
    private readonly ILogger<OrderRepository> _logger;
    private readonly IMongoCollection<OrderEntity> _collection;
    
    public OrderRepository(IMapper mapper, IMemoryCache cache, 
        ILogger<OrderRepository> logger, IOptions<MongoSettings> mongoSettings)
    {
        _mapper = mapper;
        _cache = cache;
        _logger = logger;

        var mongoClient = new MongoClient(
            mongoSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mongoSettings.Value.DatabaseName);
        
        _collection = mongoDatabase.GetCollection<OrderEntity>(
            mongoSettings.Value.OrdersCollectionName);
    }
    
    public async Task<Order> FindByIdAsync(string id, 
        CancellationToken cancellationToken = default)
    {
        var entity = await _collection
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        
        if (entity is null)
        {
            throw new NotImplementedException();
        }
        
        var result = _mapper.Map<Order>(entity);

        return result;
    }

    public async Task<Order> ReplaceOneAsync(Order order, 
        CancellationToken cancellationToken = default)
    {
        var document = _mapper.Map<OrderEntity>(order);

        if (document is null)
        {
            throw new NotImplementedException();
        }

        var filter = Builders<OrderEntity>.Filter
            .Eq(x => x.Id, document.Id);

        var options = new FindOneAndReplaceOptions<OrderEntity>
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
        
        var result = _mapper.Map<Order>(entity);

        return result;
    }

    public Task<Order> ReplaceOneDetailAsync(string orderId, 
        OrderDetail orderDetail, 
        CancellationToken cancellationToken = default)
    {
        var document = _mapper.Map<OrderDetail>(orderDetail);
        
        if (document is null)
        {
            throw new NotImplementedException();
        }

        var filter = Builders<OrderEntity>.Filter
            .Eq(x => x.Id, orderId);
        
        var options = new FindOneAndReplaceOptions<OrderEntity>
        {
            ReturnDocument = ReturnDocument.After,
            IsUpsert = true
        };
        
        throw new NotImplementedException();
    }
}