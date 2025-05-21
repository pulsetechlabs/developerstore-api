﻿using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);
        Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);

        Task<Sale> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Sale> GetByNumberAsync(string saleNumber, CancellationToken cancellationToken = default);
        Task<IEnumerable<Sale>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
        Task<int> GetTotalCountAsync(CancellationToken cancellationToken = default);

        Task<bool> CancelSaleAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> CancelItemAsync(Guid saleId, Guid itemId, CancellationToken cancellationToken = default);
    }
}
