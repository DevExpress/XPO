using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using System.Configuration;
using System.Windows;
using XpoTutorial;

namespace WpfApplication {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            ConnectionHelper.Connect();
            using(UnitOfWork uow = new UnitOfWork(XpoDefault.DataLayer)) {
                DemoDataHelper.Seed(uow);
            }
        }
    }
}
