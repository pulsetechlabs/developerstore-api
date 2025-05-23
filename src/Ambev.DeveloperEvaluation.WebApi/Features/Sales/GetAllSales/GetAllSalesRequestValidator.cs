using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;

public class GetAllSalesRequestValidator : AbstractValidator<GetAllSalesRequest>
{
    public GetAllSalesRequestValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0)
            .WithMessage("P�gina deve ser maior que 0");

        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .LessThanOrEqualTo(100)
            .WithMessage("Tamanho da p�gina deve estar entre 1 e 100");
    }
}