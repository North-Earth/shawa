using Shawa.Api.Models.Restaurant;

namespace Shawa.Api.Models.Requests;

public class CreateRestaurantRequest
{
    public RestaurantDto Restaurant { get; set; }
}