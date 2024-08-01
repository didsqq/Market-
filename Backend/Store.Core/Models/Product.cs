using CSharpFunctionalExtensions;

namespace Store.Core.Models
{
    public class Product
    {
        public const int MAX_TITLE_LENGTH = 250;
        private Product(Guid id, string title, string description, decimal price, Image image)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Image = image;
        }
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }
        public Guid ImageId { get; }
        public Image? Image { get; }

        public static Result<Product> Create (Guid id, string title, string description, decimal price, Guid imageId)
        {
            if(string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                return Result.Failure<Product>($"Title cannot be null or empty or longer then 250 symbols");
            }

            var product = new Product(id, title, description, price, imageId);

            return Result.Success(product);
        }
    }
}
