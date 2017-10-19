using Microsoft.Data.Sqlite;
namespace DevExpress.Xpo.XamarinFormsDemo.UWP {
    public sealed partial class MainPage {
        public MainPage() {
            this.InitializeComponent();
            SQLitePCL.Batteries_V2.Init();
            LoadApplication(new DevExpress.Xpo.XamarinFormsDemo.App());
        }
    }
}