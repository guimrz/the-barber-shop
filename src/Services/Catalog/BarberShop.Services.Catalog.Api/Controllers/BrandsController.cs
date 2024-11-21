using BarberShop.Services.Catalog.Application.Commands;
using BarberShop.Services.Catalog.Application.Queries;
using BarberShop.Services.Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BarberShop.Services.Catalog.Api.Controllers
{
    /// <summary>
    /// Defines a controller for brands management.
    /// </summary>
    [Route("brands")]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Creates a new instance of <see cref="BrandsController"/>.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public BrandsController(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator);

            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new brand.
        /// </summary>
        /// <param name="command">The brand information.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The brand created.</returns>
        [HttpPost]
        [ProducesResponseType<BrandResponse>((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateBrandAsync([FromBody] CreateBrandCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return new ObjectResult(result) { StatusCode = 201 };
        }

        /// <summary>
        /// Gets the brands.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The collection of brands.</returns>
        [HttpGet]
        [ProducesResponseType<BrandResponse[]>((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBrandsAsync(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetBrandsQuery(), cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Gets the specified brand.
        /// </summary>
        /// <param name="brandId">The brand identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The details of the specified brand.</returns>
        [HttpGet("{brandId:guid}")]
        [ProducesResponseType<BrandResponse>((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetBrandAsync(Guid brandId,CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetBrandQuery { BrandId = brandId }, cancellationToken);

            if(result is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
