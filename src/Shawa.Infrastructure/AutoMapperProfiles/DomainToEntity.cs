using AutoMapper;
using MongoDB.Bson;

namespace Shawa.Infrastructure.AutoMapperProfiles;

public class DomainToEntity: Profile
{
    public DomainToEntity()
    {
        CreateMap<Domain.Restaurant.Restaurant, Entities.Restaurant.RestaurantEntity>()
            .ForMember(dest => dest.Id, 
                opt=> opt.MapFrom(x => string.IsNullOrWhiteSpace(x.Id) ? ObjectId.GenerateNewId().ToString() : x.Id));
        CreateMap<Domain.Restaurant.Menu, Entities.Restaurant.MenuEntity>()
            .ForMember(dest => dest.Id, 
                opt=> opt.MapFrom(x => string.IsNullOrWhiteSpace(x.Id) ? ObjectId.GenerateNewId().ToString() : x.Id));
        CreateMap<Domain.Restaurant.Food, Entities.Restaurant.FoodEntity>()
            .ForMember(dest => dest.Id, 
                opt=> opt.MapFrom(x => string.IsNullOrWhiteSpace(x.Id) ? ObjectId.GenerateNewId().ToString() : x.Id));
        CreateMap<Domain.Restaurant.Ingredient, Entities.Restaurant.IngredientEntity>()
            .ForMember(dest => dest.Id, 
                opt=> opt.MapFrom(x => string.IsNullOrWhiteSpace(x.Id) ? ObjectId.GenerateNewId().ToString() : x.Id));
        
        CreateMap<Domain.Order.Order, Entities.Order.OrderEntity>()
            .ForMember(dest => dest.Id, 
                opt=> opt.MapFrom(x => string.IsNullOrWhiteSpace(x.Id) ? ObjectId.GenerateNewId().ToString() : x.Id));
        CreateMap<Domain.Order.OrderMetadata, Entities.Order.OrderMetadataEntity>();
    }
}