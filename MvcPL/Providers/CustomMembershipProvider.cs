using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Security;
using BLL.Interface.Services;
using BLL.Interface.Entities;

namespace MvcPL.Providers
{
    public class CustomMembershipProvider : MembershipProvider
    {
        #region Properties

        public IUserServise UserServise
        {
            get { return (IUserServise)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserServise)); }
        }

        public IRoleService RoleService
        {
            get { return (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService)); }
        }

        #endregion

        #region Methods

        public MembershipUser CreateUser(string login, string password)
        {
            MembershipUser membershipUser = GetUser(login, false);

            if (membershipUser != null) return null;

            var user = new BllUser()
            {
                Login = login,
                Password = Crypto.HashPassword(password)
            };

            var role = RoleService.GetAll().FirstOrDefault(r => r.Name == "Пользователь");
            if (role != null)
            {
                user.Roles.Add(role);
            }

            UserServise.Create(user);
            membershipUser = GetUser(login, false);
            return membershipUser;
        }

        public override MembershipUser GetUser(string login, bool userIsOnline)
        {
            var user = UserServise.GetByLogin(login);

            if (user == null) return null;

            var memberUser = new MembershipUser("CustomMembershipProvider", user.Login,
                null, null, null, null,
                false, false, DateTime.MinValue, 
                DateTime.MinValue, DateTime.MinValue, 
                DateTime.MinValue, DateTime.MinValue);

            return memberUser;
        }

        public override bool ValidateUser(string login, string password)
        {
            var user = UserServise.GetByLogin(login);

            return user != null && Crypto.VerifyHashedPassword(user.Password, password);
        }
        #region Stabs
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
            bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
        #endregion
    }
}