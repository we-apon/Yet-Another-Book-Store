using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using YABS.Model;


namespace YABS.BusinessLayer.Implementation
{
    class ClientsManager : IClientsManager { //bug: вообще из головы вылетело, что EF не умеет потоки
        readonly DbContext _context;


        public ObservableCollection<Client> Clients { get; }


        public ClientsManager(DbContext context) {
            _context = context;
            //_context.Set<Client>().LoadAsync();
            _context.Set<Client>().Load();

            Clients = _context.Set<Client>().Local;
        }




        public Task<bool> CanDelete(Client client) {
            return Task.Run(() => {
                if (client == null || client.Id == Guid.Empty)
                    return false;

                return !client.Orders.Any();
            });

        }


        /// <exception cref="DbUpdateException">An error occurred sending updates to the database.</exception>
        /// <exception cref="DbEntityValidationException">
        ///             The save was aborted because validation of entity property values failed.
        ///             </exception>
        /// <exception cref="DbUpdateConcurrencyException">
        ///             A database command did not affect the expected number of rows. This usually indicates an optimistic 
        ///             concurrency violation; that is, a row has been changed in the database since it was queried.
        ///             </exception>
        public async Task<bool> Delete(Client client) {
            if (client == null)
                return false;

            _context.Set<Client>().Remove(client);
            return await _context.SaveChangesAsync() > 0;
        }


        public Task<List<Client>> GetAllClients() {
            throw new NotImplementedException();
        }


        /// <exception cref="DbEntityValidationException">
        ///             The save was aborted because validation of entity property values failed.
        ///             </exception>
        /// <exception cref="DbUpdateConcurrencyException">
        ///             A database command did not affect the expected number of rows. This usually indicates an optimistic 
        ///             concurrency violation; that is, a row has been changed in the database since it was queried.
        ///             </exception>
        /// <exception cref="DbUpdateException">An error occurred sending updates to the database.</exception>
        public async Task<bool> Add(Client client) {
            if (client == null)
                return false;

            _context.Set<Client>().Add(client);
            return await _context.SaveChangesAsync() > 0;
        }


        public Task<bool> CanEdit(Client client) {
            return Task.Run(() => client != null && client.Id != Guid.Empty);
            //todo: add some business logic here
        }


        /// <exception cref="DbEntityValidationException">
        ///             The save was aborted because validation of entity property values failed.
        ///             </exception>
        /// <exception cref="DbUpdateConcurrencyException">
        ///             A database command did not affect the expected number of rows. This usually indicates an optimistic 
        ///             concurrency violation; that is, a row has been changed in the database since it was queried.
        ///             </exception>
        /// <exception cref="DbUpdateException">An error occurred sending updates to the database.</exception>
        public async Task<bool> Edit(Client client) {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}