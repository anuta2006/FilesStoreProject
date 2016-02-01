using System.Data.Entity;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class RoleRepository : Repository<DalRole, Role>, IRoleRepository
    {
        #region Constructor
        public RoleRepository(DbContext context)
            : base(context) { }
        #endregion

        #region Methods
        #region Protected
        protected override DalRole MapToDalEntity(Role entity)
        {
            return entity.ToDalRole();
        }

        protected override Role MapToEntity(DalRole dalEntity)
        {
            return dalEntity.ToRole();
        }

        protected override void CopyEntityFields(DalRole source, Role target)
        {
            source.CopyFieldsTo(target);
        }
        #endregion
        #endregion
    }
}
