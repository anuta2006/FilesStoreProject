using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DependencyResolver;
using Ninject;

namespace MvcPL.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        #region Fields

        private readonly IKernel kernel;

        #endregion

        #region Constructor

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel(new ResolverModule());
        }

        #endregion

        #region Methods

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        #endregion
    }
}