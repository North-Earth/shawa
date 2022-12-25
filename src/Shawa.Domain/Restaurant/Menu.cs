namespace Shawa.Domain.Restaurant;

public class Menu
{
    public string? Id { get; }
    
    public string Name { get; }
    
    public IEnumerable<Food> Food { get; private set; }

    public Menu(string id, string name, IEnumerable<Food> food)
    {
        Id = id;
        Name = name;
        Food ??= Array.Empty<Food>();
        
        AddFood(food);
    }
    
    public Menu(string name, IEnumerable<Food> food): this(null, name, food) { }

    public void AddFood(Food food)
    {
        if (Food.Any(f => f.Id is not null && f.Id == food.Id))
        {
            throw new NotImplementedException();
        }

        if (Food.Any(f => f.Emoji == food.Emoji))
        {
            throw new NotImplementedException();
        }
        
        var list = Food.ToList();
        list.Add(food);

        Food = list.AsReadOnly();
    }

    public void RemoveFood(string id)
    {
        var list = Food.ToList();
        var food = list.SingleOrDefault(x => x.Id == id);

        if (food is null)
        {
            return;
        }
        
        list.Remove(food);
        
        Food = list.AsReadOnly();
    }

    private void AddFood(IEnumerable<Food> food) 
        => food.ToList().ForEach(AddFood);
}