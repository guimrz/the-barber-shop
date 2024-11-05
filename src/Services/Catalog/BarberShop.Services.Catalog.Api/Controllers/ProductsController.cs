using BarberShop.Services.Catalog.Application;
using BarberShop.Services.Catalog.Application.Objects.Requests;
using BarberShop.Services.Catalog.Application.Objects.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BarberShop.Services.Catalog.Api.Controllers
{
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly ICatalogService _service;

        public ProductsController(ICatalogService service)
        {
            ArgumentNullException.ThrowIfNull(service);

            _service = service;
        }
 
        [HttpGet]
        [ProducesResponseType<ProductResponse[]>((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductsAsync(int page = 1, int pageSize = 20, string? search = null, CancellationToken cancellationToken = default)
        {
            var products = await _service.GetProductsAsync(page, pageSize, search, cancellationToken);

            return Ok(products);
        }

        [HttpGet("{productId:guid}")]
        [ProducesResponseType<ProductResponse>((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetProductAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            var product = await _service.GetProductAsync(productId, cancellationToken);

            if (product is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpPost]
        [ProducesResponseType<ProductResponse>((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequest request, CancellationToken cancellationToken = default)
        {
            ProductResponse productCreated = await _service.CreateProductAsync(request.Name, request.Description, cancellationToken);

            return Created(new Uri($"/products/{productCreated.Id}", UriKind.Relative), productCreated);
        }
    }
}
