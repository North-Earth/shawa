namespace Shawa.Domain.Order;

public class Food
{
    protected string Id { get; }
    
    protected string Name { get; }
    
    protected decimal Cost { get; }
    
    protected IEnumerable<Ingredient> Ingredients { get; }
    
    public Food(string id, string name, 
        IEnumerable<Ingredient> ingredients)
    {
        Id = id;
        Name = name;
        Ingredients = ingredients;
    }
}