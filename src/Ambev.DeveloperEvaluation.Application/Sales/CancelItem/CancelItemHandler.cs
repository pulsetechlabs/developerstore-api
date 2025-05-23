using MediatR;
using Microsoft.Extensions.Logging;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelItem
{
    public class CancelItemHandler : IRequestHandler<CancelItemCommand, CancelItemResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ILogger<CancelItemHandler> _logger;

        public CancelItemHandler(ISaleRepository saleRepository, ILogger<CancelItemHandler> logger)
        {
            _saleRepository = saleRepository;
            _logger = logger;
        }

        public async Task<CancelItemResult> Handle(CancelItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new CancelItemValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = await _saleRepository.GetByIdAsync(request.SaleId);
            if (sale == null)
                throw new KeyNotFoundException($"Venda com ID {request.SaleId} não encontrada");

            var item = sale.Items.FirstOrDefault(i => i.Id == request.ItemId);
            if (item == null)
                throw new KeyNotFoundException($"Item com ID {request.ItemId} não encontrado");

            sale.CancelItem(request.ItemId);
            await _saleRepository.UpdateAsync(sale, cancellationToken);

            _logger.LogInformation("ItemCancelled: {ItemId} from Sale {SaleId} - Product: {ProductName}",
                request.ItemId, request.SaleId, item.ProductName);

            return new CancelItemResult { Success = true };
        }
    }
}
