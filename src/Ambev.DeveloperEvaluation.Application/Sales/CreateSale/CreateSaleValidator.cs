using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleValidator() 
        {
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.BranchId).NotEmpty();
            RuleFor(x => x.BranchName).NotEmpty().MaximumLength(100);

            RuleFor(x => x.Items).NotEmpty().WithMessage("A venda deve ter pelo menos um item");

            RuleForEach(x => x.Items).ChildRules(item =>
            {
                item.RuleFor(i => i.ProductId).NotEmpty();
                item.RuleFor(i => i.ProductName).NotEmpty().MaximumLength(100);
                item.RuleFor(i => i.Quantity).NotEmpty().LessThanOrEqualTo(20)
                .WithMessage("A quantidade deve estar entre 1 e 20");
                item.RuleFor(i => i.UnitPrice).GreaterThan(0);
            });
        }
    }
}
