using System;
using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllUserMapper
    {
        public static DalUser ToDalUser(this BllUser userEntity)
        {
            if (userEntity == null)
            {
                throw new ArgumentNullException("userEntity");
            }
            return new DalUser()
            {
                Id = userEntity.Id,
                Login = userEntity.Login,
                Password = userEntity.Password,
                Roles = userEntity.Roles.Select(item => item.ToDalRole()).ToList()
            };
        }

        public static BllUser ToBllUser(this DalUser dalUser)
        {
            if (dalUser == null)
            {
                throw new ArgumentNullException("dalUser");
            }
            return new BllUser()
            {
                Id = dalUser.Id,
                Login = dalUser.Login,
                Password = dalUser.Password,
                Roles = dalUser.Roles.Select(item => item.ToBllRole()).ToList()
            };
        }
    }
}
