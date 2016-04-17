using System.Windows;
using Ninject;
using YABS.DesktopClient.ServiceLocator;


namespace YABS.DesktopClient {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        void ApplicationStartup(object sender, StartupEventArgs e) {
/*

            var exceptionHandler = Kernel.Instance.Get<IExceptionHandler>();
            AppDomain.CurrentDomain.UnhandledException += exceptionHandler.Handle;
            Current.DispatcherUnhandledException += exceptionHandler.Handle;
*/

            Current.Exit += ApplicationExit;
            var window = Kernel.Instance.Get<MainWindow>();
            window.Show();
        }


        void ApplicationExit(object sender, ExitEventArgs exitEventArgs) {
            Kernel.Instance.Dispose();
        }
    }
}
