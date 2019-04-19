using System;
using DevExpress.Xpf.Core;
using WpfApplication.Wrappers;
using XpoTutorial;

namespace WpfApplication {
    /// <summary>
    /// Interaction logic for CustomerEditWindow.xaml
    /// </summary>
    public partial class CustomerEditWindow : ThemedWindow {
        readonly CustomerEditWrapper model;

        public CustomerEditWindow() {
            InitializeComponent();
            model = new CustomerEditWrapper();
            DataContext = model;
        }

        public CustomerEditWindow(int customerOid) {
            InitializeComponent();
            model = new CustomerEditWrapper(customerOid);
            DataContext = model;
        }

        private async void ButtonSave_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            await model.SaveAsync();
            DialogResult = true;
        }

        private void ButtonCancel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            DialogResult = false;
        }

        private async void ButtonReload_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            await model.ReloadAsync();
        }

        private void ButtonAddOrder_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            Order order = model.CreateNewOrder();
            OrderEditWindow editWindow = new OrderEditWindow(order) {
                Owner = this
            };
            if(editWindow.ShowDialog() != true) {
                model.DeleteSelectedOrder();
            }
        }

        private void ButtonEditOrder_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            EditSelectedOrder();
        }

        private void ButtonDeleteOrder_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            model.DeleteSelectedOrder();
        }

        private void TableView_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e) {
            EditSelectedOrder();
        }

        void EditSelectedOrder() {
            OrderEditWindow editWindow = new OrderEditWindow(model.SelectedOrder) {
                Owner = this
            };
            editWindow.ShowDialog();
        }
    }
}
