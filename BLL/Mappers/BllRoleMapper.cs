using System;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllRoleMapper
    {
        public static BllRole ToBllRole(this DalRole dalRole)
        {
            if (dalRole == null)
            {
                throw new ArgumentNullException("dalRole");
            }
            return new BllRole()
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };
        }

        public static DalRole ToDalRole(this BllRole bllRole)
        {
            if (bllRole == null)
            {
                throw new ArgumentNullException("bllRole");
            }
            return new DalRole()
            {
                Id = bllRole.Id,
                Name = bllRole.Name
            };
        }
    }
}
