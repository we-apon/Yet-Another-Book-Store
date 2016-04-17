using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using YABS.Model;


namespace YABS.BusinessLayer.Implementation {
    class SafeOrdersManager : IOrdersManager {
        public Func<DbContext> GetContext { get; }


        public SafeOrdersManager(Func<DbContext> getContext) {
            GetContext = getContext;
        }


        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public async Task<List<Order>> GetOrdersOf(Client client) {
            if (client == null || client.Id == Guid.Empty)
                return new List<Order>();

            return await Task.Run(() => {
                return GetContext().Set<Order>().Where(x => x.ClientId == client.Id).ToList();
            });
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
        public async Task<bool> Accept(Order order) {
            if (order == null)
                return false;

            return await Task.Run(() => {
                var context = GetContext();

                context.Set<Order>().Add(order);
                return context.SaveChanges() > 0;
            });
        }


        public Task<bool> CanEdit(Order order) {
            return Task.Run(() => order != null && order.ClientId != Guid.Empty);
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
        public async Task<bool> Edit(Order order) {
            return await GetContext().SaveChangesAsync() > 0;
        }


        public Task<bool> CanCancel(Order order) {
            return Task.Run(() => order != null);
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
        public async Task<bool> Cancel(Order order) {
            if (order == null)
                return false;

            return await Task.Run(() => {
                var context = GetContext();

                context.Set<Order>().Add(order);
                return context.SaveChanges() > 0;
            });
        }

    }
}