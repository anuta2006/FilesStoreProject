using System;
using BLL.Interface.Entities;
using MvcPL.ViewModels;

namespace MvcPL.Infrastructure.Mappers
{
    public static class RoleMapper
    {
        public static RoleViewModel ToMvcRoleModel(this BllRole roleEntity)
        {
            if (roleEntity == null)
            {
                throw new ArgumentNullException("roleEntity");
            }
            return new RoleViewModel()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name
            };
        }

        public static BllRole ToBllRole(this RoleViewModel roleViewModel)
        {
            if (roleViewModel == null)
            {
                throw new ArgumentNullException("roleViewModel");
            }
            return new BllRole()
            {
                Id = roleViewModel.Id,
                Name = roleViewModel.Name
            };
        }
    }
}