namespace Awc.Dapr.Web.Shopping.HttpAggregator.Services;

public interface IBasketService
{
    Task UpdateAsync(BasketData currentBasket, string accessToken);
}
