using Store.Core.Models;
using Store.DataAccess.Repositories;

namespace Store.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.Get();
        }
        public async Task<Guid> CreateProduct(Product product)
        {
            return await _productRepository.Create(product);
        }
        public async Task<Guid> UpdateProduct(Guid id, string title, string description, decimal price)
        {
            return await _productRepository.Update(id, title, description, price);
        }
        public async Task<Guid> DeleteProduct(Guid id)
        {
            return await _productRepository.Delete(id);
        }
    }
}
