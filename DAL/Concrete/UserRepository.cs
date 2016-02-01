using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class UserRepository : Repository<DalUser, User>, IUserRepository
    {
        #region Constructor
        public UserRepository(DbContext context)
            : base(context) { }
        #endregion

        #region Methods

        public DalUser GetByLogin(string login)
        {
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }
            var user = context.Set<User>().FirstOrDefault(item => item.Login == login);
            return user == null ? null : user.ToDalUser();
        }

        #region Public

        public override void Create(DalUser dalEntity)
        {
            if (dalEntity == null)
            {
                throw new ArgumentNullException("dalEntity");
            }
            User user = dalEntity.ToUser();
            user.Roles = FilterRoles(dalEntity);
            context.Set<User>().Add(user);
        }
        #endregion

        #region Protected
        protected override DalUser MapToDalEntity(User entity)
        {
            return entity.ToDalUser();
        }

        protected override User MapToEntity(DalUser dalEntity)
        {
            return dalEntity.ToUser();
        }

        protected override void CopyEntityFields(DalUser source, User target)
        {
            target.Roles = FilterRoles(source);
            source.CopyFieldsTo(target);
        }
        #endregion

        #region Private
        private List<Role> FilterRoles(DalUser dalEntity)
        {
            var ids = dalEntity.Roles.Select(role => role.Id);
            return context.Set<Role>().Where(role => ids.Contains(role.Id)).ToList();
        }
        #endregion

        #endregion
    }
}
