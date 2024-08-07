using Store.Core.Models;

namespace Store.Application.Services
{
    public interface IImageService
    {
        Task<Guid> CreateImage(Image image);
    }
}