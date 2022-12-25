using Shawa.Domain.Restaurant;

namespace Shawa.Domain.Order;

public class OrderDetail
{
    public string Id { get; }
    
    public Visitor Visitor { get; }
    
    public IEnumerable<Food> Food { get; private set; }

    public OrderDetail(string id, Visitor visitor, IEnumerable<Food> food)
    {
        Id = id;
        Visitor = visitor;
        Food = food;
    }
}