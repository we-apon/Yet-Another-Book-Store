using Ninject;
using YABS.DesktopClient.ViewModels;


namespace YABS.DesktopClient.ServiceLocator {
    class NinjectServiceLocator {

        public IClientsListViewModel ClientsListViewModel => Kernel.Instance.Get<IClientsListViewModel>();


        public IOrdersListViewModel OrdersListViewModel => Kernel.Instance.Get<IOrdersListViewModel>();
    }
}