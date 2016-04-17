using System;
using System.Data.Entity;
using Ninject;
using Ninject.Modules;
using YABS.BusinessLayer.Implementation;
using YABS.Model;


namespace YABS.BusinessLayer {
    public class BusinessNinjectModule : NinjectModuleBase {
        /// <summary>
        /// Types of other <see cref="NinjectModule"/>s, that is required to be loaded for using this module.
        /// </summary>
        protected override Type[] DependsOnModules { get; } = new Type[0];


        /// <summary>
        /// Actually loads module into the kernel.
        /// </summary>
        protected override void LoadConfiguration() {
            Bind<DbContext>().To<YetAnotherStoreDb>().InThreadScope();

            Bind<Func<DbContext>>().ToMethod(x => () => x.Kernel.Get<DbContext>());

            Bind<IClientsManager>().To<SafeClientsManager>();
            Bind<IOrdersManager>().To<SafeOrdersManager>();
        }
    }
}