using Ninject;
using Ninject.Modules;
using YABS.BusinessLayer;


namespace YABS.DesktopClient.ServiceLocator {
    class Kernel : StandardKernel {
        static IKernel _instance;
        internal static IKernel Instance => _instance ?? (_instance = new Kernel());

        static INinjectModule[] Modules => new INinjectModule[] {
            new BusinessNinjectModule(),
            new DesktopClientNinjectModule(), 
        };


        Kernel() : base(Modules) { }
    }
}