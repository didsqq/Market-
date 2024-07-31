namespace Store.Contracts
{
    public record ProductsRequest(
        string Title,
        string Description,
        decimal Price);
}
