using CSharpFunctionalExtensions;

namespace Store.Core.Models
{
    public class Product
    {
        public const int MAX_TITLE_LENGTH = 250;
        private Product(Guid id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }
/*        public static (Product Product, string Error) Create(Guid id, string title, string description, decimal price)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = "Title can not be empty or longer then 250 symbols";
            }

            var product = new Product(id, title, description, price);

            return (product, error);
        }*/

        public static Result<Product> Create (Guid id, string title, string description, decimal price)
        {
            if(string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                return Result.Failure<Product>($"Title cannot be null or empty or longer then 250 symbols");
            }

            var product = new Product(id, title, description, price);

            return Result.Success(product);
        }
    }
}
