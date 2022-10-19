namespace Shawa.Api.Models.Restaurant;

public class FoodDto
{
    public string Name { get; set; }
    
    public string Emoji { get; set; }
    
    public decimal Cost { get; set; }
    
    public IEnumerable<IngredientDto> Ingredients { get; set; }
}