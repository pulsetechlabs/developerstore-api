namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleResponse
{
    /// <summary>
    /// ID da venda criada
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Número da venda
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// Valor total da venda
    /// </summary>
    public decimal TotalAmount { get; set; }
}