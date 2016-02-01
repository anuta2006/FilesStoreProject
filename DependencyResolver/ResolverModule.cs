using System.Data.Entity;
using BLL.Interface.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interface.Repository;
using Ninject.Modules;
using ORM;

namespace DependencyResolver
{
    public class ResolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<DbContext>().To<EntityModel>().InSingletonScope();

            Bind<IUserRepository>().To<UserRepository>();
            Bind<IRoleRepository>().To<RoleRepository>();
            Bind<IFileRepository>().To<FileRepository>();

            Bind<IUserServise>().To<UserService>();
            Bind<IRoleService>().To<RoleService>();
            Bind<IFileService>().To<FileService>();
        }
    }
}
