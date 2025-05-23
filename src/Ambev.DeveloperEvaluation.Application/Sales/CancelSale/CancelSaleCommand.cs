﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public record CancelSaleCommand : IRequest<CancelSaleResult>
    {
        public Guid Id { get; }

        public CancelSaleCommand(Guid id)
        {
            Id = id;
        }
    }
}
