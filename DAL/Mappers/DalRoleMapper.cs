using System;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalRoleMapper
    {
        public static DalRole ToDalRole(this Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
            };
        }

        public static Role ToRole(this DalRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            return new Role()
            {
                Id = role.Id,
                Name = role.Name,
            };
        }

        public static void CopyFieldsTo(this DalRole source, Role target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }
            target.Name = source.Name;
        }
    }
}
