using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;

namespace DAL.Concrete
{
    public abstract class Repository<TDalEntity, TEntity> : IRepository<TDalEntity> 
        where TDalEntity : DalEntity
        where TEntity : Entity
    {
        #region Fields

        protected readonly DbContext context;

        #endregion

        #region Constructors

        protected Repository(DbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Methods
        public virtual IEnumerable<TDalEntity> GetAll()
        {
            var set = context.Set<TEntity>().ToList();
            return set.Select(MapToDalEntity);
        }

        public virtual TDalEntity GetById(int id)
        {
            var entity = context.Set<TEntity>().FirstOrDefault(item => item.Id == id);
            if (entity == null)
            {
                throw new ArgumentException("There is no item with such id", "id");
            }
            return MapToDalEntity(entity);
        }

        public virtual TDalEntity GetByPredicate(Expression<Func<TDalEntity, bool>> f)
        {
            throw new NotImplementedException();
        }

        public virtual void Create(TDalEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Set<TEntity>().Add(MapToEntity(entity));
        }

        public virtual void Delete(TDalEntity dalEntity)
        {
            if (dalEntity == null)
            {
                throw new ArgumentNullException("dalEntity");
            }
            var entities = context.Set<TEntity>();
            var entity = entities.FirstOrDefault(item => item.Id == dalEntity.Id);
            if (entity == null)
            {
                return;
            }
            entities.Remove(entity);
        }

        public virtual void Update(TDalEntity dalEntity)
        {
            if (dalEntity == null)
            {
                throw new ArgumentNullException("dalEntity");
            }
            var entity = context.Set<TEntity>().FirstOrDefault(item => item.Id == dalEntity.Id);
            if (entity == null)
            {
                throw new ArgumentException("There is no element with such id", "dalEntity");
            }
            CopyEntityFields(dalEntity, entity);
        }

        #region Protected methods

        protected abstract TDalEntity MapToDalEntity(TEntity entity);

        protected abstract TEntity MapToEntity(TDalEntity dalEntity);

        protected abstract void CopyEntityFields(TDalEntity source, TEntity target);

        #endregion

        #endregion
    }
}
