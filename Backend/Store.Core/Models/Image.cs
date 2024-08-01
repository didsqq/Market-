using CSharpFunctionalExtensions;

namespace Store.Core.Models
{
    public class Image
    {
        private Image(Guid id, string fileName)
        {
            Id = id;
            FileName = fileName;
        }

        public Guid Id { get; }
        public string FileName { get; } = string.Empty;

        public static Result<Image> Create(Guid id, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return Result.Failure<Image>("FileName can not be empty");
            }

            var image = new Image(id, fileName);

            return Result.Success(image);
        }
    }
}
