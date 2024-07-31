namespace Store.Contracts
{
    public record ProductsResponse(
        Guid Id,
        string Title,
        string Description,
        decimal Price);
}
