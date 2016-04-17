using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using YABS.Model;


namespace YABS.DesktopClient.ViewModels {
    interface IOrdersListViewModel {

        ObservableCollection<Order> Orders { get; } 

        ICommand ChangeClientCommand { get; }

        Order SelectedOrder { get; set; }


        DelegateCommand AcceptOrderCommand { get; }

        DelegateCommand<Order> EditOrderCommand { get; }

        DelegateCommand<Order> CancelOrderCommand { get; }

    }
}