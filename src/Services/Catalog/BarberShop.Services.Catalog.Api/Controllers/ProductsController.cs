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
 
        [HttpGet]
        [ProducesResponseType<ProductResponse[]>((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductsAsync(GetProductsQuery query, CancellationToken cancellationToken = default)
        {
            var products = await _mediator.Send(query, cancellationToken);

            return Ok(products);
        }

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

        [HttpPost]
        [ProducesResponseType<ProductResponse>((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand request, CancellationToken cancellationToken = default)
        {
            ProductResponse productCreated = await _mediator.Send(request, cancellationToken);

            return new ObjectResult(productCreated) { StatusCode = 201 };
        }
    }
}
