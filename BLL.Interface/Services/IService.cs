using System.Collections.Generic;

namespace BLL.Interface.Services
{
    public interface IService<TEntity>
    {
        void Create(TEntity entity);

        void Update(TEntity entity);

        TEntity GetById(int id);

        ICollection<TEntity> GetAll();

        void Delete(TEntity entity);
    }
}
