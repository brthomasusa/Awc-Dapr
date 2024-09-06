namespace Awc.Dapr.Web.Shopping.HttpAggregator.Services;

public class CatalogService(HttpClient httpClient) : ICatalogService
{
    private readonly HttpClient _httpClient = httpClient;

    public Task<IEnumerable<CatalogItem>?> GetCatalogItemsAsync(IEnumerable<int> ids)
    {
        var requestUri = $"api/v1/catalog/items/by_ids?ids={string.Join(",", ids)}";

        return _httpClient.GetFromJsonAsync<IEnumerable<CatalogItem>>(requestUri);
    }
}
