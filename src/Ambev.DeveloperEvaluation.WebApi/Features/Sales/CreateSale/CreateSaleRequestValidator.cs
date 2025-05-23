using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(x => x.Date).NotEmpty().WithMessage("Data da venda é obrigatória");
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("ID do cliente é obrigatório");
        RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(100).WithMessage("Nome do cliente é obrigatório e deve ter no máximo 100 caracteres");
        RuleFor(x => x.BranchId).NotEmpty().WithMessage("ID da filial é obrigatório");
        RuleFor(x => x.BranchName).NotEmpty().MaximumLength(100).WithMessage("Nome da filial é obrigatório e deve ter no máximo 100 caracteres");

        RuleFor(x => x.Items).NotEmpty().WithMessage("A venda deve ter pelo menos um item");

        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.ProductId).NotEmpty().WithMessage("ID do produto é obrigatório");
            item.RuleFor(i => i.ProductName).NotEmpty().MaximumLength(100).WithMessage("Nome do produto é obrigatório e deve ter no máximo 100 caracteres");
            item.RuleFor(i => i.Quantity).GreaterThan(0).LessThanOrEqualTo(20).WithMessage("A quantidade deve estar entre 1 e 20");
            item.RuleFor(i => i.UnitPrice).GreaterThan(0).WithMessage("O preço unitário deve ser maior que 0");
        });
    }
}