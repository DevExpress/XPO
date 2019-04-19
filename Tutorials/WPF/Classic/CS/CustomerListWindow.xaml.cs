using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using WpfApplication.Wrappers;

namespace WpfApplication {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CustomerListWindow : ThemedWindow {
        CustomerListWrapper model;
        public CustomerListWindow() {
            InitializeComponent();
            model = new CustomerListWrapper();
            DataContext = model;
        }

        private async void ButtonAddCustomer_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            var editWindow = new CustomerEditWindow() {
                Owner = this
            };
            if(editWindow.ShowDialog() == true) {
                await model.ReloadAsync();
            }
        }

        private async void ButtonEditCustomer_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            await EditSelectedCustomerAsync();
        }

        private async void ButtonDeleteCustomer_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            await model.DeleteSelectedCustomerAsync();
        }

        private async void ButtonReload_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            await model.ReloadAsync();
        }

        private async void TableView_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e) {
            await EditSelectedCustomerAsync();
        }

        async Task EditSelectedCustomerAsync() {
            var editWindow = new CustomerEditWindow(model.SelectedCustomer.Oid) {
                Owner = this
            };
            if (editWindow.ShowDialog() == true) {
                await model.ReloadAsync();
            }
        }
    }
}