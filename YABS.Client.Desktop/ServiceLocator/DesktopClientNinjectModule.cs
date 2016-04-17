using System;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using Ninject.Parameters;
using YABS.BusinessLayer;
using YABS.DesktopClient.Dialogs;
using YABS.DesktopClient.ViewModels;
using YABS.DesktopClient.ViewModels.Implementation;
using YABS.Model;


namespace YABS.DesktopClient.ServiceLocator
{

    class DesktopClientNinjectModule : NinjectModuleBase {

        /// <summary>
        /// Types of other <see cref="NinjectModule"/>s, that is required to be loaded for using this module.
        /// </summary>
        protected override Type[] DependsOnModules { get; } = {typeof (BusinessNinjectModule)};


        /// <summary>
        /// Actually loads module into the kernel.
        /// </summary>
        protected override void LoadConfiguration() {

            Bind<IClientsListViewModel>().To<ClientsListViewModel>().InSingletonScope();
            Bind<IOrdersListViewModel>().To<OrdersListViewModel>().InSingletonScope();

            Bind<Func<Client, Task<Client>>>().ToMethod(x => (client) => {
                var completion = new TaskCompletionSource<Client>();

                var editDialog = x.Kernel.Get<ClientEditDialog>(new ConstructorArgument("client", client));
                editDialog.Confirmed += completion.SetResult;
                editDialog.Canceled += completion.SetCanceled; //todo: add cancelation logic
                editDialog.Show();

                return completion.Task;
            });


            Bind<Func<Order, Task<Order>>>().ToMethod(x => (order) => { //todo: use an interface with named bindings
                var completion = new TaskCompletionSource<Order>();

                var editDialog = x.Kernel.Get<OrderEditDialog>(new ConstructorArgument("order", order));
                editDialog.Confirmed += completion.SetResult;
                editDialog.Canceled += completion.SetCanceled; //todo: add cancelation logic
                editDialog.Show();

                return completion.Task;

            });

        }
    }

    
}