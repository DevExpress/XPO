using DevExpress.Xpo;
using System;
using System.Configuration;
using System.Windows.Forms;
using XpoTutorial;

namespace WinFormsApplication {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConnectionHelper.Connect();
            using (UnitOfWork uow = new UnitOfWork()) {
                DemoDataHelper.Seed(uow);
            }
            Application.Run(new MainForm());
        }
    }
}
