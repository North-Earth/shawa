namespace Shawa.Api.Models.Requests;

public class CreateOrderRequest
{
    public string OrderName { get; set; }
    
    public string RestourantId { get; set; }
    
    public string RestourantMenuId { get; set; }
    
    public string ChannelId { get; set; }
    
    public string CreatorUserName { get; set; }
}