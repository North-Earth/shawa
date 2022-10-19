namespace Shawa.Domain.Restaurant;

public class Menu
{
    public string? Id { get; }
    
    public string Name { get; }
    
    public IEnumerable<Food> Food { get; private set; }

    public Menu(string name, IEnumerable<Food> food)
    {
        Id = null;
        Food = food;
        Name = name;
    }

    public Menu(string id, string name, IEnumerable<Food> food)
    {
        Id = id;
        Food = food;
        Name = name;
    }
    
    public void AddFood(Food food)
    {
        if (Food.Any(ing => ing.Id == food.Id))
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
}