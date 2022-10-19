namespace Shawa.Domain.Restaurant;

public class Restaurant
{
    public string? Id { get; }
    
    public string Name { get; }
    
    public IEnumerable<Menu> Menus { get; }

    public Restaurant(string name, IEnumerable<Menu> menus)
    {
        Id = null;
        Name = name;
        Menus = menus;
    }

    public Restaurant(string id, string name, IEnumerable<Menu> menus)
    {
        Id = id;
        Name = name;
        Menus = menus;
    }
}