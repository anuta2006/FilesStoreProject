using System;
using System.Linq;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalUserMapper
    {
        public static DalUser ToDalUser(this User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return new DalUser()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Roles = user.Roles.Select(role => role.ToDalRole()).ToList()
            };
        }

        public static User ToUser(this DalUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return new User()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Roles = user.Roles.Select(role => role.ToRole()).ToList()
            };
        }

        public static void CopyFieldsTo(this DalUser source, User target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }
            target.Login = source.Login;
            target.Roles = source.Roles.Select(item => item.ToRole()).ToList();
        }
    }
}
