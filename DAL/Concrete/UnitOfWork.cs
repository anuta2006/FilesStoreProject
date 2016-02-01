using System.Data.Entity;
using DAL.Interface.Repository;

namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Property
        public DbContext Context { get; private set; }
        #endregion

        #region Constructor

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Methods
        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }

        public void Commit()
        {
            if (Context != null)
                Context.SaveChanges();
        }
        #endregion
    }
}
