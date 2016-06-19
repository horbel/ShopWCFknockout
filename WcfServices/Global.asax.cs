using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Ninject.Extensions.Wcf;
using Ninject.Web.Common;
using Ninject;
using DataLayer.Abstract;
using DataLayer.Concrete;

namespace WcfServices
{
    public class Global : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IProductRepository>().To<ProductRepository>().InSingletonScope();
            return kernel;
        }
        
    }
}