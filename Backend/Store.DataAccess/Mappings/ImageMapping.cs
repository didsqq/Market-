using Store.Core.Models;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Mappings
{
    public static class ImageMapping
    {
        public static Image ToDomainImage(this ImageEntity? entity)
        {
            Image image = Image.Create(
                entity.Id, 
                entity.FileName,
                entity.Product.ToDomainProduct()).Value;

            return image;
        }
        public static ImageEntity ToEntityImage(this Image image)
        {
            var imageEntity = new ImageEntity
            {
                Id = image.Id,
                FileName = image.FileName,
                ProductId = image.ProductId,
                Product = image.Product.ToEntity()
            };

            return imageEntity;
        }
    }
}
