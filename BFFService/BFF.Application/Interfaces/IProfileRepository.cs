
using BFF.Application.Models;

namespace BFF.Application.Interfaces
{
    public interface IProfileRepository
    {
        Task<UserResponse> GetUser(int id);
        Task<PhotoResponse> GetPhoto(int id);
    }
}
