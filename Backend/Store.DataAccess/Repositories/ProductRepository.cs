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
                .Select(b => Product.Create(b.Id, b.Title, b.Description, b.Price).Value)
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
            };

            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();

            return productEntity.Id;
        }
        public async Task<Guid> Update(Guid id, string title, string description, decimal price)
        {
/*            var product = await _context.Products.FirstOrDefaultAsync(b => b.Id == id);
            if (product != null)
            {
                product.Title = title;
                product.Description = description;
                product.Price = price;
                await _context.SaveChangesAsync();
            }*/
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
/*            var product = await _context.Products.FirstOrDefaultAsync(b => b.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }*/
            await _context.Products
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}