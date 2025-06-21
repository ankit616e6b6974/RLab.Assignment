using RLab.Core.Entities;
using RLab.DTO;

namespace RLab.Interface
{
    public interface IUserRepository
    {
        Task<User?> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUser();
    }
}
