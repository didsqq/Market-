using Store.Core.Models;
using Store.DataAccess.Repositories;

namespace Store.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImagesRepository _imagesRepository;
        public ImageService(IImagesRepository imagesRepository) 
        {
            _imagesRepository = imagesRepository;
        }
        public async Task<Guid> CreateImage(Image image)
        {
            return await _imagesRepository.Add(image);
        }
    }
}
