using CSharpFunctionalExtensions;

namespace Store.Core.Models
{
    public class Image
    {
        private Image(Guid id, string fileName, Product product)
        {
            Id = id;
            FileName = fileName;
            Product = product;
            ProductId = id;
        }

        public Guid Id { get; }
        public string FileName { get; } = string.Empty;
        public Guid ProductId { get; }
        public Product Product { get; }

        public static Result<Image> Create (Guid id, string fileName, Product product)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return Result.Failure<Image>("FileName can not be empty");
            }

            var image = new Image(id, fileName, product);

            return Result.Success(image);
        }
    }
}
