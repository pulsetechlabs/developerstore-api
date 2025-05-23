namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Representa uma requisição para criar uma nova venda
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// Data da venda
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// ID do cliente
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Nome do cliente
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Id da filial
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// Nome da filial
    /// </summary>
    public string BranchName { get; set; } = string.Empty;

    /// <summary>
    /// Itens da venda
    /// </summary>
    public List<CreateSaleItemRequest> Items { get; set; } = new List<CreateSaleItemRequest>();
}

public class CreateSaleItemRequest
{
    /// <summary>
    /// Id do produto
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Nome do produto
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Quantidade do produto
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Preço unitário do produto
    /// </summary>
    public decimal UnitPrice { get; set; }
}