using API.Entities;
using Microsoft.EntityFrameworkCore;
using API.Intefaces;
using API.Dtos;
namespace API.Data

{
    public class PhotoRepository(AppDbContext context) : IPhotoRepository
    {
        public async Task<Photo?> GetPhotoById(int id)
        {
            return await context.Photos
                .IgnoreQueryFilters()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<PhotoForApprovaldDto>> GetUnapprovedPhotos()
        {
            return await context.Photos
                .IgnoreQueryFilters()
                .Where(p => p.IsApproved == false)
                .Select(u => new PhotoForApprovaldDto
                {
                Id = u.Id,
                UserId = u.MemberId,
                Url = u.Url,
                IsApproved = u.IsApproved
                }).ToListAsync();
        }

        public void RemovePhoto(Photo photo)
        {
            context.Photos.Remove(photo);
        }

    }
}