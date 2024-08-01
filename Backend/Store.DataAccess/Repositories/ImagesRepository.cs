using Microsoft.EntityFrameworkCore;
using Store.Core.Models;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Repositories
{
    public class ImagesRepository
    {
        private readonly StoreDbContext _context;
        public ImagesRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(Image image)
        {
            var imageEntity = new ImageEntity
            {
                Id = image.Id,
                FileName = image.FileName
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
