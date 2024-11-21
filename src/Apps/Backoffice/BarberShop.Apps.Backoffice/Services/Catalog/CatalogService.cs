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

            return JsonConvert.DeserializeObject<BrandResponse>(await response.Content.ReadAsStringAsync())!;
        }

        public async Task<BrandResponse> GetBrandAsync(Guid brandId, CancellationToken cancellationToken = default)
        {
            var client = _httpClientFactory.CreateClient(nameof(CatalogService));

            var response = await client.GetAsync($"/brands/{brandId}", cancellationToken);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync(cancellationToken);

            return JsonConvert.DeserializeObject<BrandResponse>(result)!;
        }

        public async Task<IEnumerable<ProductTypeResponse>> GetProductTypesAsync(CancellationToken cancellationToken = default)
        {
            var client = _httpClientFactory.CreateClient(nameof(CatalogService));

            var response = await client.GetAsync("/product-types", cancellationToken);

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<IEnumerable<ProductTypeResponse>>(await response.Content.ReadAsStringAsync(cancellationToken)) ?? Array.Empty<ProductTypeResponse>();

        }
    }
}
