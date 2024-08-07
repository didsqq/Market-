using Microsoft.EntityFrameworkCore;
using Store.Core.Models;
using Store.DataAccess.Entities;
using Store.DataAccess.Mappings;

namespace Store.DataAccess.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly StoreDbContext _context;
        public ImagesRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<Image> GetById(Guid id)
        {
            var imageEntity = await _context.Images
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            return imageEntity.ToDomainImage();
        }
        public async Task<Guid> Add(Image image)
        {
            var imageEntity = new ImageEntity
            {
                Id = image.Id,
                FileName = image.FileName,
                ProductId = image.ProductId,
                Product = image.Product.ToEntity()
            };

            await _context.Images.AddAsync(imageEntity);
            await _context.SaveChangesAsync();

            return image.Id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Images
                .Where(i => i.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
