using System;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class UserService : Service<BllUser, DalUser>, IUserServise
    {
        #region Constructor

        public UserService(IUnitOfWork uow, IUserRepository repository)
            : base(uow, repository) { }
        #endregion

        #region Methods

        #region Public

        public BllUser GetByLogin(string login)
        {
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }
            var user = ((IUserRepository) repository).GetByLogin(login);
            return user == null ? null : user.ToBllUser();
        }
        #endregion
    
        #region Protected
        protected override DalUser MapToDalEntity(BllUser entity)
        {
            return entity.ToDalUser();
        }

        protected override BllUser MapToBllEntity(DalUser entity)
        {
            return entity.ToBllUser();
        }
        #endregion
        #endregion
    }
}
