﻿using BarberShop.Services.Catalog.Domain;

namespace BarberShop.Services.Catalog.Repository
{
    public interface ICatalogServiceRepository
    {
        IQueryable<Product> Products { get; }

        Task<Product> InsertAsync(Product product, CancellationToken cancellationToken = default);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}