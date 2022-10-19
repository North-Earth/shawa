using AutoMapper;
using Shawa.Api.Models.Restaurant;
using Shawa.Domain.Restaurant;

namespace Shawa.Api.AutoMapperProfiles;

public class DtoToDomain: Profile
{
    public DtoToDomain()
    {
        CreateMap<RestaurantDto, Restaurant>();
        CreateMap<MenuDto, Menu>();
        CreateMap<FoodDto, Food>();
        CreateMap<IngredientDto, Ingredient>();
    }
}