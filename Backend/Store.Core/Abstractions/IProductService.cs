using Store.Core.Models;

namespace Store.Application.Services
{
    public interface IProductService
    {
        Task<Guid> CreateProduct(Product product);
        Task<Guid> DeleteProduct(Guid id);
        Task<List<Product>> GetAllProducts();
        Task<Guid> UpdateProduct(Guid id, string title, string description, decimal price);
    }
}