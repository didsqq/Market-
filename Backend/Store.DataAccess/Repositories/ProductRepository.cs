using Microsoft.EntityFrameworkCore;
using Store.Core.Models;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;
        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Get()
        {
            var productEntities = await _context.Products
                .AsNoTracking()
                .ToListAsync();
            var products = productEntities
                .Select(b => Product.Create(b.Id, b.Title, b.Description, b.Price, b.ImageId).Value)
                .ToList();

            return products;
        }

        public async Task<Guid> Create(Product product)
        {
            var productEntity = new ProductEntity
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                ImageId = product.ImageId
            };

            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();

            return productEntity.Id;
        }
        public async Task<Guid> Update(Guid id, string title, string description, decimal price)
        {
            await _context.Products
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, b => title)
                    .SetProperty(b => b.Description, b => description)
                    .SetProperty(b => b.Price, b => price));

            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Products
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
        public async Task<ProductEntity?> GetById(Guid id)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<ProductEntity>> GetByFilterTitle(string title)
        {
            var query = _context.Products.AsNoTracking();

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(t => t.Title.Contains(title));
            }

            return await query.ToListAsync();
        }
    }
}