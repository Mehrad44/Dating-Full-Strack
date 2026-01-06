using API.Dtos;
using API.Entities;

namespace API.Intefaces
{
    public interface IPhotoRepository
    {
         Task<IReadOnlyList<PhotoForApprovaldDto>> GetUnapprovedPhotos();
        Task<Photo?> GetPhotoById(int id);
        void RemovePhoto(Photo photo);
    }
}