using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync();
            return sale;
        }

        public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }

        public async Task<Sale> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Sales
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<Sale> GetByNumberAsync(string saleNumber, CancellationToken cancellationToken)
        {
            return await _context.Sales
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.SaleNumber == saleNumber, cancellationToken);
        }

        public async Task<IEnumerable<Sale>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Sales
                .Include(s => s.Items)
                .OrderByDescending(s=>s.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> GetTotalCountAsync(CancellationToken cancellationToken)
        {
            return await _context.Sales.CountAsync(cancellationToken);
        }

        public async Task<bool> CancelSaleAsync(Guid id, CancellationToken cancellationToken)
        {
            var sale = await GetByIdAsync(id, cancellationToken);
            if (sale == null) return false;

            sale.Cancel();
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> CancelItemAsync(Guid saleId, Guid itemId, CancellationToken cancellationToken)
        {
            var sale = await GetByIdAsync(saleId, cancellationToken);
            if (sale == null) return false;

            sale.CancelItem(itemId);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
