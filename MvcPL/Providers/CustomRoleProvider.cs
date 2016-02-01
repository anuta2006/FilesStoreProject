using System;
using System.Linq;
using System.Web.Security;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace MvcPL.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        #region Properties

        public IUserServise UserServise
        {
            get { return (IUserServise) System.Web.Mvc.DependencyResolver.Current.GetService(typeof (IUserServise)); }
        }

        public IRoleService RoleService
        {
            get { return (IRoleService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof (IRoleService)); }
        }
        #endregion

        #region Methods

        public override bool IsUserInRole(string login, string roleName)
        {
            var user = UserServise.GetAll().FirstOrDefault(u => u.Login == login);

            if (user == null) return false;

            var userRoles = user.Roles;

            if (userRoles == null) return false;

            foreach (var role in userRoles)
            {
                if (role.Name == roleName)
                    return true;
            }
            return false;
        }

        public override string[] GetRolesForUser(string login)
        {
            var user = UserServise.GetAll().FirstOrDefault(u => u.Login == login);

            if (user == null) return new string[]{};

            var userRoles = user.Roles;

            if (userRoles == null) return new string[]{};

            return userRoles.Select(role => role.Name).ToArray();
        }

        public override void CreateRole(string roleName)
        {
            var role = new BllRole() {Name = roleName};

            RoleService.Create(role);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
        #endregion
    }
}