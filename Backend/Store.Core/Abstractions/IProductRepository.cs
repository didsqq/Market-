using Store.Core.Models;

namespace Store.DataAccess.Repositories
{
    public interface IProductRepository
    {
        Task<Guid> Create(Product product);
        Task<Guid> Delete(Guid id);
        Task<List<Product>> Get();
        Task<Guid> Update(Guid id, string title, string description, decimal price);
    }
}