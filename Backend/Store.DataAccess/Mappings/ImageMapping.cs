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
    }
}
