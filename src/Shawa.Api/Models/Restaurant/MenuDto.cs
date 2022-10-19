namespace Shawa.Api.Models.Restaurant;

public class MenuDto
{
    public string Name { get; set; }
    
    public IEnumerable<FoodDto> Food { get; set; }
}