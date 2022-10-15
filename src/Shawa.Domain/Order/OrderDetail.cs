namespace Shawa.Domain.Order;

public class OrderDetail
{
    protected string Id { get; }
    
    protected Visitor Visitor { get; }
    
    protected IEnumerable<Food> Food { get; private set; }

    public OrderDetail(string id, Visitor visitor, IEnumerable<Food> food)
    {
        Id = id;
        Visitor = visitor;
        Food = food;
    }
}