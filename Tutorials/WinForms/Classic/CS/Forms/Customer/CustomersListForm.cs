using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
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

        protected Session Session;

        private void Reload() {
            Session = new Session();
            CustomersBindingSource.DataSource = new XPCollection<Customer>(Session);
        }

        private void OrdersView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e) {
            btnEdit.Enabled = btnDelete.Enabled = e.Row != null;
        }

        private void btnNew_ItemClick(object sender, ItemClickEventArgs e) {
            EditCustomerForm form = new EditCustomerForm();
            form.MdiParent = this.MdiParent;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
            form.FormClosing += EditForm_FormClosing;
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e) {
            EditCustomer();
        }

        private void EditCustomer() {
            EditCustomerForm form = new EditCustomerForm();
            form.CustomerId = (int)CustomersView.GetFocusedRowCellValue("Oid");
            form.WindowState = FormWindowState.Maximized;
            form.MdiParent = this.MdiParent;
            form.Show();
            form.FormClosing += EditForm_FormClosing;
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e) {
            object toDelete = CustomersView.GetFocusedRow();
            Session.Delete(toDelete);
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e) {
            Reload();
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e) {
            EditCustomerForm form = (EditCustomerForm)sender;
            Customer modified = Session.GetLoadedObjectByKey<Customer>(form.CustomerId);
            if(modified == null) {
                XPBaseCollection collection = (XPBaseCollection)CustomersBindingSource.DataSource;
                collection.Reload();
                CustomersView.FocusedRowHandle = CustomersView.LocateByValue("Oid", form.CustomerId);
            }
            else Session.Reload(modified);
        }

        private void CustomersView_RowClick(object sender, RowClickEventArgs e) {
            if (e.Clicks == 2)
                EditCustomer();
        }
    }
}
