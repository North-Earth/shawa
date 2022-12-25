namespace Shawa.Domain.Order;

public class Order
{
    private List<OrderDetail> _details;

    public string? Id { get; }
    
    public string Name { get; }

    public string Creator { get; }
    
    public DateTime Created { get; }

    public OrderStatus Status { get; private set; }

    public DateTime? Completed { get; private set; }
    
    public OrderMetadata Metadata { get; }
    
    public IReadOnlyCollection<OrderDetail> Details => _details.AsReadOnly();
    
    public Order(string id, string name, 
        string creator, OrderMetadata metadata, 
        IEnumerable<OrderDetail> orderDetails)
    {
        Id = id;
        Name = name;
        Creator = creator;
        Metadata = metadata;

        Created = DateTime.UtcNow;
        Status = OrderStatus.Open;
        Completed = null;
        
        _details = orderDetails.ToList();
    }

    public Order(string name, string creator,
        OrderMetadata metadata, IEnumerable<OrderDetail> orderDetails) 
        : this(null, name, creator, metadata, orderDetails) { }

    public void Complete()
    {
        if (Status is not OrderStatus.Open || Completed is not null)
        {
            throw new NotImplementedException();
        }

        Status = OrderStatus.Completed;
        Completed = DateTime.UtcNow;
    }

    public void AddDetail(OrderDetail orderDetail)
    {
        if (_details.Exists(x => x.Id == orderDetail.Id))
        {
            throw new NotImplementedException();
        }
        
        _details.Add(orderDetail);
    }

    public void UpdateDetail(OrderDetail orderDetail)
    {
        if (!_details.Exists(x => x.Id == orderDetail.Id))
        {
            throw new NotImplementedException();
        }

        _details.RemoveAll(detail => detail.Id == orderDetail.Id);
        _details.Add(orderDetail);
    }

    public void UpdateDetails(IEnumerable<OrderDetail> orderDetails)
    {
        //Details = orderDetails;
    }
}