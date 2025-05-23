using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelItem
{
    public class CancelItemValidator : AbstractValidator<CancelItemCommand>
    {
        public CancelItemValidator()
        {
            RuleFor(x => x.SaleId).NotEmpty()
                .WithMessage("ID da venda é obrigatório");

            RuleFor(x => x.ItemId).NotEmpty()
                .WithMessage("ID do item é obrigatório");
        }
    }
}
