namespace Shawa.Domain.Order;

public class Visitor
{
    protected string Id { get; private set; }
    
    protected string Name { get; private set; }
    
    public Visitor(string id, string name)
    {
        Id = id;
        Name = name;
    }
}