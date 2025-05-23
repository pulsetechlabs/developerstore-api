using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelItem
{
    public class CancelItemCommand : IRequest<CancelItemResult>
    {
        public Guid SaleId { get; }
        public Guid ItemId { get; }

        public CancelItemCommand(Guid saleId, Guid itemId)
        {
            SaleId = saleId;
            ItemId = itemId;
        }
    }
}
