namespace Shawa.Api.Models.Order;

public class FoodIngredientsDto
{
    public string Id { get; set; }
    
    public IEnumerable<string> IngredientsIds { get; set; }
}