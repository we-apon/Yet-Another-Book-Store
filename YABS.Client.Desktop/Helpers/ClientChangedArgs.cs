using System;
using YABS.Model;


namespace YABS.DesktopClient.Helpers {
    class ClientChangedArgs : EventArgs {
        public Client Client { get; }


        public ClientChangedArgs(Client client) {
            Client = client;
        }
    }
}