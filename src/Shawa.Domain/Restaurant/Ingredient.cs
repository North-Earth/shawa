namespace Shawa.Domain.Restaurant;

public class Ingredient
{
    public string? Id { get; }
    
    public string Name { get; }
    
    public string Emoji { get; }
    
    public decimal Cost { get; }
    
    public Ingredient(string name, 
        string emoji, decimal cost)
    {
        Id = null;
        Name = name;
        Emoji = emoji;
        Cost = cost;
    }

    public Ingredient(string id, string name, 
        string emoji, decimal cost)
    {
        Id = id;
        Name = name;
        Emoji = emoji;
        Cost = cost;
    }
}