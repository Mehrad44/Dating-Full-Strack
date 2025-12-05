
using CloudinaryDotNet.Actions;

namespace API.Intefaces
{
    public interface IPhotoService
    {
         Task<ImageUploadResult> UploadPhotoAsync(IFormFile file);

         Task<DeletionResult> DeletPhooAsync(string publicId);
    }
}