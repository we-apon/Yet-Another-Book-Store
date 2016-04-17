using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using YABS.Model;


namespace YABS.BusinessLayer {
    public interface IOrdersManager {

        Task<List<Order>> GetOrdersOf(Client client);
            
            
        Task<bool> Accept(Order order);

        Task<bool> CanEdit(Order order);
        Task<bool> Edit(Order order);



        Task<bool> CanCancel(Order order);
            
        Task<bool> Cancel(Order order);

    }
}