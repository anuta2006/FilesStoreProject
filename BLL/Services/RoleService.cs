using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class RoleService : Service<BllRole, DalRole>, IRoleService
    {
        #region Constructor
        public RoleService(IUnitOfWork uow, IRoleRepository repository)
            : base(uow, repository) { }
        #endregion

        #region Methods
        #region Public
        #endregion

        #region Protected
        protected override DalRole MapToDalEntity(BllRole entity)
        {
            return entity.ToDalRole();
        }

        protected override BllRole MapToBllEntity(DalRole entity)
        {
            return entity.ToBllRole();
        }
        #endregion
        #endregion
    }
}
