using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public string SaleNumber { get; private set; }
        public DateTime Date { get; private set; }
        public Guid CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public decimal TotalAmount { get; private set; }
        public Guid BranchId { get; private set; }
        public string BranchName { get; private set; }
        public bool IsCancelled { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public ICollection<SaleItem> Items { get; private set; } = new List<SaleItem>();

        protected Sale() { }

        public Sale(string saleNumber, DateTime date, Guid customerId, string customerName,
            Guid branchId, string branchName)
        {
            SaleNumber = saleNumber;
            Date = date;
            CustomerId = customerId;
            CustomerName = customerName;
            BranchId = branchId;
            BranchName = branchName;
            IsCancelled = false;
            CreatedAt = DateTime.UtcNow;

            TotalAmount = 0;
        }

        public void AddItem(Guid productId, string productName, int quantity, decimal unitPrice)
        {
            if (quantity > 20)
                throw new DomainException("Não é possível vender mais de 20 itens idênticos.");

            var item = new SaleItem(this.Id, productId, productName, quantity, unitPrice);
            Items.Add(item);

            RecalculateTotal();
        }

        public void Cancel()
        {
            if (IsCancelled)
                throw new DomainException("Esta venda já está cancelada.");

            IsCancelled = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void CancelItem(Guid itemId)
        {
            var item = Items.FirstOrDefault(i => i.Id == itemId);
            if (item == null)
                throw new DomainException("Item não encontrado.");

            if (item.IsCancelled)
                throw new DomainException("Este item já está cancelado.");

            item.Cancel();
            RecalculateTotal();
            UpdatedAt = DateTime.UtcNow;
        }

        public void RecalculateTotal()
        {
            TotalAmount = Items
                .Where(i => !i.IsCancelled)
                .Sum(i => i.TotalPrice);

            UpdatedAt = DateTime.UtcNow;
        }
    }
}
