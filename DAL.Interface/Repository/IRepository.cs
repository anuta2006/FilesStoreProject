using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity : DalEntity
    {
        IEnumerable<TEntity> GetAll();
       
        TEntity GetById(int id);
        
        TEntity GetByPredicate(Expression<Func<TEntity, bool>> f);
        
        void Create(TEntity entity);
        
        void Delete(TEntity entity);
        
        void Update(TEntity entity);
    }
}
