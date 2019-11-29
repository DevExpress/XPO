using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using XpoTutorial;

namespace WinFormsApplication {
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConnectionHelper.Connect();
            using(UnitOfWork uow = new UnitOfWork()) {
                DemoDataHelper.Seed(uow);
            }
            Application.Run(new MainView());
        }
    }
}
