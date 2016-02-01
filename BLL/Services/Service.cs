using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.DTO;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public abstract class Service<TBllEntity, TDalEntity> : IService<TBllEntity>
        where TBllEntity : BllEntity
        where TDalEntity : DalEntity
    {
        #region Fields

        protected readonly IUnitOfWork uow;
        protected readonly IRepository<TDalEntity> repository;
 
        #endregion

        #region Constructors

        protected Service(IUnitOfWork uow, IRepository<TDalEntity> repository)
        {
            this.uow = uow;
            this.repository = repository;
        }

        #endregion

        #region Methods
        #region Public
        public virtual void Create(TBllEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            repository.Create(MapToDalEntity(entity));
           
            uow.Commit();
        }

        public virtual void Update(TBllEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            repository.Update(MapToDalEntity(entity));

            uow.Commit();
        }

        public virtual TBllEntity GetById(int id)
        {
            return MapToBllEntity(repository.GetById(id));
        }

        public virtual ICollection<TBllEntity> GetAll()
        {
            return repository.GetAll().Select(MapToBllEntity).ToList();
        }

        public void Delete(TBllEntity entity)
        {
            repository.Delete(MapToDalEntity(entity));
            uow.Commit();
        }
        #endregion

        #region Protected

        protected abstract TDalEntity MapToDalEntity(TBllEntity entity);

        protected abstract TBllEntity MapToBllEntity(TDalEntity entity);

        #endregion

        #endregion
    }
}
