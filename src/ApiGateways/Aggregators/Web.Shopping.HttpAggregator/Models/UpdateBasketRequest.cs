namespace Awc.Dapr.Web.Shopping.HttpAggregator.Models;

public record UpdateBasketRequest(IEnumerable<UpdateBasketRequestItemData> Items);
