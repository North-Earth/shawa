namespace Shawa.Domain.Restaurant;

public class Restaurant
{
    public string? Id { get; }
    
    public string Name { get; }
    
    public IEnumerable<Menu> Menus { get; }
    
    public Restaurant(string id, string name, IEnumerable<Menu> menus)
    {
        Id = id;
        Name = name;
        Menus = menus;
    }

    public Restaurant(string name, IEnumerable<Menu> menus): this(null, name, menus) { }
}