using Store.Core.Models;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Mappings
{
    public static class ProductMapping
    {
        public static Product ToDomainProduct(this ProductEntity? productEntity)
        {
            Product product = Product.Create(
                productEntity.Id,
                productEntity.Title,
                productEntity.Description,
                productEntity.Price).Value;

            return product;
        }

        public static ProductEntity ToEntity(this Product product) 
        {
            ProductEntity entity = new ProductEntity { 
                Id = product.Id, 
                Title = product.Title, 
                Description = product.Description, 
                Price = product.Price };

            return entity;
        }
    }
}
