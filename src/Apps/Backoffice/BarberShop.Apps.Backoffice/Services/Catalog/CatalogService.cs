using BarberShop.Apps.Backoffice.Services.Catalog.Objects.Request;
using BarberShop.Apps.Backoffice.Services.Catalog.Objects.Responses;
using Newtonsoft.Json;

namespace BarberShop.Apps.Backoffice.Services.Catalog
{
    public class CatalogService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CatalogService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken = default)
        {
            var client = _httpClientFactory.CreateClient(nameof(CatalogService));

            var response = await client.GetAsync("/brands", cancellationToken);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync(cancellationToken);

            return JsonConvert.DeserializeObject<BrandResponse[]>(result)!;
        }

        public async Task<BrandResponse> CreateBrandAsync(CreateBrandRequest request, CancellationToken cancellationToken = default)
        {
            var client = _httpClientFactory.CreateClient(nameof(CatalogService));

            var response = await client.PostAsync("/brands", new StringContent(JsonConvert.SerializeObject(request), new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")), cancellationToken);

            response.EnsureSuccessStatusCode();

            using Stream responseStream = await response.Content.ReadAsStreamAsync(cancellationToken);

            return JsonConvert.DeserializeObject<BrandResponse>(await response.Content.ReadAsStringAsync())!;
        }
    }
}
