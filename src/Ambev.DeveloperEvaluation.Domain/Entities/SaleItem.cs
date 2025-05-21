using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public Guid SaleId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalPrice { get; private set; }
        public bool IsCancelled {  get; private set; }

        public Sale Sale { get; private set; }

        protected SaleItem() { }

        public SaleItem(Guid saleId, Guid productId, string productName, int quantity, decimal unitPrice)
        {
            SaleId = saleId;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            IsCancelled = false;

            CalculatediscountAndTotal();
        }

        public void Cancel()
        {
            IsCancelled = true;
            TotalPrice = 0;
        }

        private void CalculateDiscountAndTotal()
        {
            if (Quantity > 20)
                throw new DomainException("Não é possível vender mais de 20 itens idênticos.");

            decimal discountPercentage = 0;

            if (Quantity >= 10 && Quantity <= 20)
            {
                discountPercentage = 0.2m;
            }
            else if (Quantity >= 4)
            {
                discountPercentage = 0.1m;
            }

            decimal subtotal = Quantity * UnitPrice;
            Discount = subtotal * discountPercentage;
            TotalPrice = subtotal - Discount;
        }
    }
}
