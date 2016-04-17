using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using YABS.Model;


namespace YABS.DesktopClient.ViewModels {
    interface IClientsListViewModel
    {
        ObservableCollection<Client> Clients { get; }

        event EventHandler ClientSelected;

        Client SelectedClient { get; set; }


        /*IOrdersListViewModel OrdersModel { get; }*/




        ICommand AddClientCommand { get; }

        DelegateCommand<Client> EditClientCommand { get; }

        DelegateCommand<Client> DeleteClientCommand { get; }


    }
}