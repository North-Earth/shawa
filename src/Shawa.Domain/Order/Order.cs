namespace Shawa.Domain.Order;

public class Order
{
    protected string Id { get; }
    
    protected string Name { get; }
    
    protected IEnumerable<OrderDetail> Details { get; private set; }
    
    protected OrderStatus Status { get; private set; }
    
    protected DateTime Created { get; }

    protected DateTime? Completed { get; private set; }
    
    public Order(string id, string name, DateTime created, 
        IEnumerable<OrderDetail> orderDetails)
    {
        Id = id;
        Name = name;
        Created = created;
        Details = orderDetails;

        Status = OrderStatus.Open;
        Completed = null;
    }

    public void Complete()
    {
        if (Status is not OrderStatus.Open || Completed is not null)
        {
            throw new NotImplementedException();
        }

        Status = OrderStatus.Completed;
        Completed = DateTime.UtcNow;
    }

    public void UpdateDetails(IEnumerable<OrderDetail> orderDetails)
    {
        Details = orderDetails;
    }
}