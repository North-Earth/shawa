using AutoMapper;

namespace Shawa.Infrastructure.AutoMapperProfiles;

public class EntityToDomain: Profile
{
    public EntityToDomain()
    {
        CreateMap<Entities.Restaurant.RestaurantEntity, Domain.Restaurant.Restaurant>();
        CreateMap<Entities.Restaurant.MenuEntity, Domain.Restaurant.Menu>();
        CreateMap<Entities.Restaurant.FoodEntity, Domain.Restaurant.Food>();
        CreateMap<Entities.Restaurant.IngredientEntity, Domain.Restaurant.Ingredient>();
    }
}