using BarberShop.Services.Catalog.Application;
using BarberShop.Services.Catalog.Application.Commands;
using BarberShop.Services.Catalog.Application.Queries;
using BarberShop.Services.Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BarberShop.Services.Catalog.Api.Controllers
{
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator);

            _mediator = mediator;
        }
 
        /// <summary>
        /// Get the products.
        /// </summary>
        /// <param name="query">The query arguments.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The collection of products.</returns>
        [HttpGet]
        [ProducesResponseType<ProductResponse[]>((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductsAsync(GetProductsQuery query, CancellationToken cancellationToken = default)
        {
            var products = await _mediator.Send(query, cancellationToken);

            return Ok(products);
        }

        /// <summary>
        /// Get the product details.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The details of the specified product.</returns>
        [HttpGet("{productId:guid}")]
        [ProducesResponseType<ProductResponse>((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetProductAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            var product = await _mediator.Send(new GetProductQuery(productId), cancellationToken);

            if (product is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="request">The product information.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The product created.</returns>
        [HttpPost]
        [ProducesResponseType<ProductResponse>((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand request, CancellationToken cancellationToken = default)
        {
            ProductResponse productCreated = await _mediator.Send(request, cancellationToken);

            return new ObjectResult(productCreated) { StatusCode = 201 };
        }
    }
}
