using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Validation;
using AutoMapper;
using FluentValidation;
using MediatR;
using Rebus.Bus;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        public CreateSaleHandler(ISaleRepository saleRepository, IBus bus, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _bus = bus;
            _mapper = mapper;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var saleNumber = $"SALE-{DateTime.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid().ToString().Substring(0, 8)}";

            var sale = new Sale(
                saleNumber,
                request.Date.ToUniversalTime(),
                request.CustomerId,
                request.CustomerName,
                request.BranchId,
                request.BranchName
            );

            foreach ( var item in request.Items )
            {
                sale.AddItem(item.ProductId, item.ProductName, item.Quantity, item.UnitPrice);
            }

            var createSale = await _saleRepository.CreateAsync(sale, cancellationToken);

            await _bus.Publish(new SaleCreatedEvent(createSale.Id, createSale.SaleNumber));

            return new CreateSaleResult
            {
                Id = createSale.Id,
                SaleNumber = createSale.SaleNumber,
                TotalAmount = createSale.TotalAmount,
            };
        }
    }
}
