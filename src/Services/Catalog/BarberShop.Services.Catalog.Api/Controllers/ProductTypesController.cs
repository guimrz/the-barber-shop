﻿using BarberShop.Services.Catalog.Application.Queries;
using BarberShop.Services.Catalog.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Services.Catalog.Api.Controllers
{
    [Route("product-types")]
    public class ProductTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductTypesController(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator);

            _mediator = mediator;
        }

        /// <summary>
        /// Get the product types.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The collection of product types.</returns>
        [HttpGet]
        [ProducesResponseType<ProductType[]>(200)]
        public async Task<IActionResult> GetProductTypesAsync(CancellationToken cancellationToken = default)
        {
            var productTypes = await _mediator.Send(new GetProductTypesQuery(), cancellationToken);

            return Ok(productTypes);
        }
    }
}
