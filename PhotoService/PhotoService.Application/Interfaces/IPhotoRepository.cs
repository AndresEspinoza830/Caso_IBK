using PhotoService.Domain.Entities;

namespace PhotoService.Application.Interfaces
{
    public interface IPhotoRepository
    {
        Task<UserPhoto> GetUserPhoto(int id);
    }
}
