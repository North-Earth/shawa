using Shawa.Api.Models.Order;

namespace Shawa.Api.Models.Requests;

public class UpdateOrderDetailRequest
{
    public VisitorDto Visitor { get; set; }
    
    public IEnumerable<FoodIngredientsDto> Food { get; set; }
}