using CSharpFunctionalExtensions;

namespace Store.Core.Models
{
    public class Image
    {
        private Image(Guid id, string fileName, string filePath)
        {
            Id = id;
            FileName = fileName;
            FilePath = filePath;
        }

        public Guid Id { get; }
        public string FileName { get; } = string.Empty;
        public string FilePath { get; } = string.Empty;

        public static Result<Image> Create(Guid id, string fileName, string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return Result.Failure<Image>("FilePath can not be empty");
            }
            if (string.IsNullOrEmpty(fileName))
            {
                return Result.Failure<Image>("FileName can not be empty");
            }

            var image = new Image(id, fileName, filePath);

            return Result.Success(image);
        }
    }
}
