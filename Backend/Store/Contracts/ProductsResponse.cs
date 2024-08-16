using Store.Core.Models;

namespace Store.Contracts
{
    public record ProductsResponse(
        Guid Id,
        string Title,
        string Description,
        decimal Price,
        string Filename);
}
