﻿using BarberShop.Services.Catalog.Application.Responses;
using MediatR;

namespace BarberShop.Services.Catalog.Application.Commands
{
    public record CreateProductCommand : IRequest<ProductResponse>
    {
        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public Guid BrandId { get; set; }

        public int TypeId { get; set; }
    }
}
