using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Dccelerator;
using GalaSoft.MvvmLight.Command;
using Prism.Commands;
using YABS.BusinessLayer;
using YABS.DesktopClient.Helpers;
using YABS.Model;


namespace YABS.DesktopClient.ViewModels.Implementation {
    class OrdersListViewModel : IOrdersListViewModel {
        public Func<Order, Task<Order>> PerformOrderEditing { get; }
        readonly IOrdersManager _manager;

        Client _currentClient;
        Order _selectedOrder;
        bool _canCancelSelectedOrder;
        bool _canEditSelectedOrder;

        public ObservableCollection<Order> Orders { get; } = new ObservableCollection<Order>();
        public ICommand ChangeClientCommand { get; }
        public DelegateCommand AcceptOrderCommand { get; }
        public DelegateCommand<Order> EditOrderCommand { get; }
        public DelegateCommand<Order> CancelOrderCommand { get; }


        public Order SelectedOrder {
            get { return _selectedOrder; }
            set {
                _selectedOrder = value;
                UpdateCommandStatesAsync();
            }
        }


        async void UpdateCommandStatesAsync() {
            _canCancelSelectedOrder = await _manager.CanCancel(_selectedOrder);
            _canEditSelectedOrder = await _manager.CanEdit(_selectedOrder);

            CancelOrderCommand.RaiseCanExecuteChanged();
            EditOrderCommand.RaiseCanExecuteChanged();
        }


        public OrdersListViewModel(IOrdersManager manager, Func<Order, Task<Order>> performOrderEditingCallback) {
            PerformOrderEditing = performOrderEditingCallback;
            _manager = manager;


            AcceptOrderCommand = DelegateCommand.FromAsyncHandler(AcceptOrderAsync, () =>
            _currentClient != null);

            ChangeClientCommand = new RelayCommand<ClientChangedArgs>(ReloadOrders);

            EditOrderCommand = DelegateCommand<Order>.FromAsyncHandler(EditOrderAsync, order => _canEditSelectedOrder);

            CancelOrderCommand = DelegateCommand<Order>.FromAsyncHandler(CancelOrderAsync, order => _canCancelSelectedOrder);
        }


        async void ReloadOrders(ClientChangedArgs obj) {
            _currentClient = obj.Client;
            
            Orders.Clear();
            if (_currentClient == null)
                return;

            var orders = await _manager.GetOrdersOf(_currentClient);
            Orders.AddRange(orders);
            AcceptOrderCommand.RaiseCanExecuteChanged();
        }


        async Task EditOrderAsync(Order order) {
            _canEditSelectedOrder = false;
            EditOrderCommand.RaiseCanExecuteChanged();

            try {
                var editedOrder = await PerformOrderEditing(order);
                await _manager.Edit(editedOrder);
            }
            finally {
                _canEditSelectedOrder = await _manager.CanEdit(order);
                EditOrderCommand.RaiseCanExecuteChanged();
            }
        }


        async Task AcceptOrderAsync() {
#if DEBUG
            var order = await PerformOrderEditing(RandomMaker.Make<Order>(x => x.ClientId = _currentClient.Id));
#else
            var order = await PerformOrderEditing(new Order { ClientId = _currentClient.Id });
#endif
            if (await _manager.Accept(order))
                Orders.Add(order);
        }


        async Task CancelOrderAsync(Order order) {
            _canEditSelectedOrder = false;
            CancelOrderCommand.RaiseCanExecuteChanged();

            if (await _manager.Cancel(order))
                Orders.Remove(order);
        }
        

    }
    
}