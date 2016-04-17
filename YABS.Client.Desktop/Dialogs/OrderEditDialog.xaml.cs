using System;
using System.Windows;
using YABS.Model;


namespace YABS.DesktopClient.Dialogs
{
    /// <summary>
    /// Interaction logic for OrderEditDialog.xaml
    /// </summary>
    public partial class OrderEditDialog : Window
    {
        public OrderEditDialog(Order order) {
            InitializeComponent();
            DataContext = order;
        }


        public event Action<Order> Confirmed; //todo: an dialog interface
        public event Action Canceled;


        void Confirm(object sender, RoutedEventArgs e) {
            Confirmed?.Invoke((Order)DataContext);
            Close();
        }


        void Cancel(object sender, RoutedEventArgs e) {
            Canceled?.Invoke();
            Close();
        }
    }
}
