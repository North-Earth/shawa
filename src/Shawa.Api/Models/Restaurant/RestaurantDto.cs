namespace Shawa.Api.Models.Restaurant;

public class RestaurantDto
{
    public string Name { get; set; }
    
    public IEnumerable<MenuDto> Menus { get; set; }
}