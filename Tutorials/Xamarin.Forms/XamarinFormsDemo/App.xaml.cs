using DevExpress.Xpo.DB;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using XamarinFormsDemo.Views;

namespace XamarinFormsDemo {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Connect to SQLite
            var filePath = Path.Combine(documentsPath, "xpoXamarinDemo.db");
            string connectionString = SQLiteConnectionProvider.GetConnectionString(filePath) + ";Cache=Shared;";

            XpoHelper.InitXpo(connectionString);

            if(Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            Debug.WriteLine(e.ExceptionObject);
        }
    }
}