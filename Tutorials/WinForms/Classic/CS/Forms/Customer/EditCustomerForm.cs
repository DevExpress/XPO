using DevExpress.Xpo;
using DevExpress.Xpo.DB.Exceptions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Collections;
using XpoTutorial;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace WinFormsApplication.Forms {
    public partial class EditCustomerForm : RibbonForm {
        public EditCustomerForm() {
            InitializeComponent();
        }

        private UnitOfWork Session;
        public int? CustomerId { get; set; }
        protected Customer CurrentObject {
            get { return (Customer)CustomersBindingSource.DataSource; }
        }

        private void EditOrderForm_Load(object sender, System.EventArgs e) {
            Reload();
        }

        private async void Reload() {
            DisableButtons();
            try {
                if (Session != null) {
                    Session.ObjectChanged -= Session_ObjectChanged;
                }
                Session = new UnitOfWork();
                Session.ObjectChanged += Session_ObjectChanged;
                CustomersBindingSource.DataSource = CustomerId.HasValue ? await Session.GetObjectByKeyAsync<Customer>(CustomerId.Value) : new Customer(Session);
            } finally { EnableButtons(); }
        }

        private void Session_ObjectChanged(object sender, ObjectChangeEventArgs e) {
            if (e.Reason == ObjectChangeReason.PropertyChanged // the customer property modified
                || e.Reason == ObjectChangeReason.Reset // an order is modified
                )
                btnSave.Enabled = true;
        }

        private async void btnSave_ItemClick(object sender, ItemClickEventArgs e) {
            DisableButtons();
            try {
                await Session.CommitChangesAsync();
                CustomerId = CurrentObject.Oid; // a new object gets Oid from the database
                Close();
            } catch (LockingException) {
                XtraMessageBox.Show("XPO Tutorial", "The record was modified by another user. Please refresh data.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            } finally { EnableButtons(); }
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e) {
            Close();
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e) {
            Reload();
        }

        private void btnAddOrder_ItemClick(object sender, ItemClickEventArgs e) {
            EditOrderNestedForm form = new EditOrderNestedForm(Session);
            form.MdiParent = this.MdiParent;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
            form.FormClosing += EditForm_FormClosing;
        }

        private void btnEditOrder_ItemClick(object sender, ItemClickEventArgs e) {
            EditOrder();
        }

        private void EditOrder() {
            EditOrderNestedForm form = new EditOrderNestedForm(Session);
            form.MdiParent = this.MdiParent;
            form.WindowState = FormWindowState.Maximized;
            form.Order = (Order)OrdersView.GetFocusedRow();
            form.Show();
            form.FormClosing += EditForm_FormClosing;
        }

        private void EnableButtons() {
            ICollection objectsToSave = Session.GetObjectsToSave();
            btnSave.Enabled = objectsToSave.Count > 0;
            btnRefresh.Enabled = true;
        }

        private void DisableButtons() {
            btnSave.Enabled = false;
            btnRefresh.Enabled = false;
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e) {
            EditOrderNestedForm form = (EditOrderNestedForm)sender;
            if (form.Order != null) {
                form.Order.Customer = CurrentObject;
                OrdersView.FocusedRowHandle = OrdersView.FindRow(form.Order);
            }
        }

        private void SetFocusedRow(int rowHandle) {
            OrdersView.FocusedRowHandle = rowHandle;
        }

        private void btnDeleteOrder_ItemClick(object sender, ItemClickEventArgs e) {
            Order toDelete = (Order)OrdersView.GetFocusedRow();
            Session.Delete(toDelete);
        }

        private void OrdersView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e) {
            btnEditOrder.Enabled = btnDeleteOrder.Enabled = e.Row != null;
        }

        private void OrdersView_RowClick(object sender, RowClickEventArgs e) {
            if(e.Clicks == 2)
                EditOrder();
        }
    }
}
