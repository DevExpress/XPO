using DevExpress.Xpf.Core;
using DevExpress.Xpo;
using System;
using System.Windows;
using System.Windows.Threading;
using XpoTutorial;

namespace WpfApplicationMvvm {
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            ConnectionHelper.Connect();
            using (UnitOfWork uow = new UnitOfWork()) {
                DemoDataHelper.Seed(uow);
            }
        }
        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) {
            e.Handled = true;
            Exception exception = UnwrapException(e.Exception);
            DXMessageBox.Show(MainWindow, exception.Message, "XPO Tutorial - Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private Exception UnwrapException(Exception exception) {
            if (exception.InnerException == null) return exception;
            else return UnwrapException(exception.InnerException);
        }
    }
}
