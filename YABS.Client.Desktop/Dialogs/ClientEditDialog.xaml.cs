using System;
using System.Windows;
using YABS.Model;


namespace YABS.DesktopClient
{
    /// <summary>
    /// Interaction logic for ClientEditDialog.xaml
    /// </summary>
    public partial class ClientEditDialog {
        public ClientEditDialog(Client client) {
            InitializeComponent();
            DataContext = client;
        }

        public event Action<Client> Confirmed;
        public event Action Canceled;


        public void SetupClient(Client client) {
            DataContext = client;
        }


        void Confirm(object sender, RoutedEventArgs e) {
            Confirmed?.Invoke((Client)DataContext);
            Close();
        }


        void Cancel(object sender, RoutedEventArgs e) {
            Canceled?.Invoke();
            Close();
        }
    }
}
