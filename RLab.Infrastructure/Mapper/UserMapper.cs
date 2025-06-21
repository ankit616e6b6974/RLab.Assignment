using RLab.Core.Entities;
using RLab.DTO;
using RLab.Interface;

namespace RLab.Infrastructure.Mapper
{
    public class UserMapper: IUserMapper
    {
        public User MapToEntity(ExternalUser dto)
        {
            if (dto == null)
            {
                return new User();
            }
            return new User
            {
                ExternalId = dto.Id,
                Email = dto.Email,
                FirstName = dto.First_Name, 
                LastName = dto.Last_Name,
                Avatar = dto.Avatar,
            };
        }
    }
}
