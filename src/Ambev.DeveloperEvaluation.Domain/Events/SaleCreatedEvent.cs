using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleCreatedEvent
    {
        public Guid SaleId { get; }
        public string SaleNumber { get; }
        public DateTime OcurredOn { get; }

        public SaleCreatedEvent(Guid saleId, string saleNumber)
        {
            SaleId = saleId;
            SaleNumber = saleNumber;
            OcurredOn = DateTime.UtcNow;
        }

        public class SaleModifiedEvent
        {
            public Guid SaleId { get; }
            public string SaleNumber { get; }
            public DateTime OcurredOn { get; }

            public SaleModifiedEvent(Guid saleId, string saleNumber)
            {
                SaleId = saleId;
                SaleNumber = saleNumber;
                OcurredOn = DateTime.UtcNow;
            }
        }

        public class SaleCancelledEvent
        {
            public Guid SaleId { get; }
            public string SaleNumber { get; }
            public DateTime OccuredOn { get; }

            public SaleCancelledEvent(Guid saleId, string saleNumber)
            {

                SaleId = saleId;
                SaleNumber = saleNumber;
                OccuredOn = DateTime.UtcNow;
            }
        }

        public class ItemCancelledEvent
        {
            public Guid ItemId { get; }
            public Guid SaleId { get; }
            public string ProductName { get; }
            public DateTime OcurredOn { get; }

            public ItemCancelledEvent(Guid itemId, Guid saleId, string productName)
            {
                ItemId = itemId;
                SaleId = saleId;
                ProductName = productName;
                OcurredOn = DateTime.UtcNow;
            }
        }
    }
}
