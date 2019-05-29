using DevExpress.Data;
using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Windows.Forms;
using XpoTutorial;

namespace WinFormsApplication.Forms {
    public partial class CustomersListForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public CustomersListForm() {
            InitializeComponent();
        }

        private void CustomersListForm_Load(object sender, EventArgs e) {
            Reload();
        }

        private async void Reload() {
            btnRefresh.Enabled = false;
            try {
                CustomersBindingSource.DataSource = await new Session().Query<Order>().ToListAsync();
            } finally { btnRefresh.Enabled = true; }
        }

        private void OrdersView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e) {
            btnEdit.Enabled = e.Row != null;
        }

        private void btnNew_ItemClick(object sender, ItemClickEventArgs e) {
            EditCustomerForm form = new EditCustomerForm();
            form.MdiParent = this.MdiParent;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
            form.FormClosing += EditForm_FormClosing;
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e) {
            EditCustomerForm form = new EditCustomerForm();
            form.CustomerId = (int)OrdersView.GetFocusedRowCellValue("Oid");
            form.WindowState = FormWindowState.Maximized;
            form.MdiParent = this.MdiParent;
            form.Show();
            form.FormClosing += EditForm_FormClosing;
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e) {
            Reload();
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e) {
            EditOrderForm form = (EditOrderForm)sender;
            Reload();
            int rowHandle = OrdersView.LocateByValue("Oid", form.OrderId, new OperationCompleted(rh => SetFocusedRow((int)rh)));
            if (rowHandle != GridControl.InvalidRowHandle)
                SetFocusedRow(rowHandle);
        }

        private void SetFocusedRow(int rowHandle) {
            OrdersView.FocusedRowHandle = rowHandle;
        }
    }
}
