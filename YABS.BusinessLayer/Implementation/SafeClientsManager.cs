using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using YABS.Model;


namespace YABS.BusinessLayer.Implementation {
    class SafeClientsManager : IClientsManager {
        public Func<DbContext> GetContext { get; set; }


        //public ObservableCollection<Client> Clients { get; }


        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public SafeClientsManager(Func<DbContext> getContext) {
            GetContext = getContext;
        }


        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public Task<bool> CanDelete(Client client) {
            return Task.Run(() => {
                if (client == null || client.Id == Guid.Empty)
                    return false;

                var context = GetContext();
                return context.Set<Order>().All(x => x.ClientId != client.Id);
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
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public async Task<bool> Delete(Client client) {
            if (client == null)
                return false;

            return await Task.Run(() => {
                var context = GetContext();
                context.Set<Client>().Remove(client);
                return context.SaveChanges() > 0;
            });
        }


        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public Task<List<Client>> GetAllClients() {
            return GetContext().Set<Client>().ToListAsync();
        }


        /// <exception cref="DbEntityValidationException">
        ///             The save was aborted because validation of entity property values failed.
        ///             </exception>
        /// <exception cref="DbUpdateConcurrencyException">
        ///             A database command did not affect the expected number of rows. This usually indicates an optimistic 
        ///             concurrency violation; that is, a row has been changed in the database since it was queried.
        ///             </exception>
        /// <exception cref="DbUpdateException">An error occurred sending updates to the database.</exception>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public async Task<bool> Add(Client client) {
            if (client == null)
                return false;


            return await Task.Run(() => {
                var context = GetContext();
                context.Set<Client>().Add(client);
                return context.SaveChanges() > 0;
            });
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
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public async Task<bool> Edit(Client client) {
            return await GetContext().SaveChangesAsync() > 0;
        }
    }
}