using Store.Core.Models;

namespace Store.DataAccess.Repositories
{
    public interface IImagesRepository
    {
        Task<Guid> Add(Image image);
        Task<Guid> Delete(Guid id);
        Task<Image> GetById(Guid id);
    }
}