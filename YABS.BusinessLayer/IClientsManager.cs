using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using YABS.Model;


namespace YABS.BusinessLayer {
    public interface IClientsManager {

        //ObservableCollection<Client> Clients { get; }

        Task<List<Client>> GetAllClients(); // todo: add paging, or something

        Task<bool> Add(Client client);

        Task<bool> CanEdit(Client client);
        Task<bool> Edit(Client client);


        Task<bool> CanDelete(Client client);
            
        Task<bool> Delete(Client client);

    }
}