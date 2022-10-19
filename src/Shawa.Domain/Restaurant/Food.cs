namespace Shawa.Domain.Restaurant;

public class Food
{
    public string? Id { get; }
    
    public string Name { get; }
    
    public string Emoji { get; }
    
    public decimal Cost { get; }
    
    public IEnumerable<Ingredient> Ingredients { get; private set; }

    public Food(string name, string emoji, 
        decimal cost, IEnumerable<Ingredient> ingredients)
    {
        Id = null;
        Name = name;
        Emoji = emoji;
        Cost = cost;
        Ingredients = ingredients;
    }
    
    public Food(string id, string name, string emoji, 
        decimal cost, IEnumerable<Ingredient> ingredients)
    {
        Id = id;
        Name = name;
        Emoji = emoji;
        Cost = cost;
        Ingredients = ingredients;
    }

    public void AddIngredient(Ingredient ingredient)
    {
        if (Ingredients.Any(ing => ing.Id == ingredient.Id))
        {
            throw new NotImplementedException();
        }
        
        var list = Ingredients.ToList();
        list.Add(ingredient);

        Ingredients = list.AsReadOnly();
    }

    public void RemoveIngredient(string id)
    {
        var list = Ingredients.ToList();
        var ingredient = list.SingleOrDefault(x => x.Id == id);

        if (ingredient is null)
        {
            return;
        }
        
        list.Remove(ingredient);
        
        Ingredients = list.AsReadOnly();
    }
}