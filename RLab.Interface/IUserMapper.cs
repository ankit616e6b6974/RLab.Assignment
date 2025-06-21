using RLab.Core.Entities;
using RLab.DTO;

namespace RLab.Interface
{
    public interface IUserMapper
    {
        User MapToEntity(ExternalUser dto);
    }
}
