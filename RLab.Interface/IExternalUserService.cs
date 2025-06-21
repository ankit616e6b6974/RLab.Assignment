using RLab.Core.Entities;
using RLab.DTO;
using RLab.DTO.Common;

namespace RLab.Interface
{
    public interface IExternalUserService
    {
        Task<ApiResponse<IEnumerable<User>>> GetUserByPage(int page);
        Task<ApiResponse<User?>> GetUserById(int id);
    }
}
