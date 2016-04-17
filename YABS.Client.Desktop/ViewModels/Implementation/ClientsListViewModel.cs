using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Dccelerator;
using Prism.Commands;
using YABS.BusinessLayer;
using YABS.DesktopClient.Helpers;
using YABS.Model;


namespace YABS.DesktopClient.ViewModels.Implementation {


    class ClientsListViewModel : IClientsListViewModel {
        readonly IClientsManager _manager;
        Client _selectedClient;
        bool _canDeleteSelectedClient;
        bool _canEditSelectedClient;

        public ObservableCollection<Client> Clients { get; } = new ObservableCollection<Client>();
        public event EventHandler ClientSelected;


        public ICommand AddClientCommand { get; }
        public DelegateCommand<Client> EditClientCommand { get; }

        public DelegateCommand<Client> DeleteClientCommand { get; }

        public Func<Client, Task<Client>> PerformClientEditing { get; }


        /// <exception cref="Exception" accessor="set">A delegate callback throws an exception.</exception>
        public virtual Client SelectedClient {
            get { return _selectedClient; }
            set {
                _selectedClient = value;
                _canDeleteSelectedClient = false;
                DeleteClientCommand.RaiseCanExecuteChanged();

                if (value != null)
                    ClientSelected?.Invoke(this, new ClientChangedArgs(value));

                UpdateCommandStatesAsync();
            }
        }


        async void UpdateCommandStatesAsync() {
            _canDeleteSelectedClient = await _manager.CanDelete(_selectedClient);
            _canEditSelectedClient = await _manager.CanEdit(_selectedClient);

            EditClientCommand.RaiseCanExecuteChanged();
            DeleteClientCommand.RaiseCanExecuteChanged();
        }


        public ClientsListViewModel(IClientsManager manager, Func<Client, Task<Client>> performClientEditingCallback) {
            _manager = manager;
            PerformClientEditing = performClientEditingCallback;

            AddClientCommand = DelegateCommand.FromAsyncHandler(AddClientAsync);
            EditClientCommand = DelegateCommand<Client>.FromAsyncHandler(EditClient, client => _canEditSelectedClient);
            DeleteClientCommand = DelegateCommand<Client>.FromAsyncHandler(DeleteClient, client => _canDeleteSelectedClient);

            LoadClients();
        }


        async void LoadClients() {
            Clients.Clear();
            Clients.AddRange(await _manager.GetAllClients());
        }


        async Task EditClient(Client client) {
            _canEditSelectedClient = false;
            EditClientCommand.RaiseCanExecuteChanged();

            try {
                var editedOrder = await PerformClientEditing(client);
                await _manager.Edit(editedOrder);
            }
            finally {
                _canEditSelectedClient = await _manager.CanEdit(client);
                EditClientCommand.RaiseCanExecuteChanged();
            }
        }


        async Task AddClientAsync() {
#if DEBUG
            var client = await PerformClientEditing(RandomMaker.Make<Client>(includeGuids:true));
#else
            var client = await PerformClientEditing(new Client {Id = Guid.NewGuid()});
#endif
            if (await _manager.Add(client))
                Clients.Add(client);
        }


        async Task DeleteClient(Client client) {
            _canDeleteSelectedClient = false;
            DeleteClientCommand.RaiseCanExecuteChanged();

            if (await _manager.Delete(client))
                Clients.Remove(client);
        }
    }
}