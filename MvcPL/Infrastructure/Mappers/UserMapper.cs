using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using MvcPL.ViewModels;

namespace MvcPL.Infrastructure.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToMvcUserModel(this BllUser userEntity)
        {
            if (userEntity == null)
            {
                throw new ArgumentNullException("userEntity");
            }
            return new UserViewModel()
            {
                Id = userEntity.Id,
                Login = userEntity.Login,
                Password = userEntity.Password,
                RoleNames = userEntity.Roles.Select(item => item.Name).ToList()
            };
        }

        public static BllUser ToBllUser(this UserViewModel userViewModel, ICollection<RoleViewModel> roles)
        {
            if (userViewModel == null)
            {
                throw new ArgumentNullException("userViewModel");
            }
            return new BllUser()
            {
                Id = userViewModel.Id,
                Login = userViewModel.Login,
                Password = userViewModel.Password,
                Roles = roles.Select(item => item.ToBllRole()).ToList()
        };
        }
    }
}