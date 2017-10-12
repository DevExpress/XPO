using DevExpress.Xpo.DB;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DevExpress.Xpo.XamarinFormsDemo {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            //MSSqlServer

            //string connectionString = MSSqlConnectionProvider.GetConnectionString("YOUR_SERVER_NAME", "sa", "", "XamarinDemo");

            //SQLite

            //var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //var filePath = Path.Combine(documentsPath, "xpoXamarinDemo.db");
            //string connectionString = SQLiteConnectionProvider.GetConnectionString(filePath);

            //In-memory data store with saving/loading from the xml file

            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, "xpoXamarinDemo.xml");
            string connectionString = InMemoryDataStore.GetConnectionString(filePath);

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