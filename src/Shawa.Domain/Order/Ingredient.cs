namespace Shawa.Domain.Order;

public class Ingredient
{
    protected string Id { get; }
    
    protected string Name { get; }
    
    protected decimal Cost { get; }
    
    public Ingredient(string id, string name, decimal cost)
    {
        Id = id;
        Name = name;
        Cost = cost;
    }
}