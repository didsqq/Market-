namespace Store.DataAccess.Entities
{
    public class ImageEntity
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = string.Empty;

        public Guid ProductId { get; set; }
        public ProductEntity? Product { get; set; }
    }
}
