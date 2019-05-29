using DevExpress.Xpo;
using DevExpress.Xpo.DB.Exceptions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Collections;
using XpoTutorial;

namespace WinFormsApplication.Forms {
    public partial class EditCustomerForm : RibbonForm {
        public EditCustomerForm() {
            InitializeComponent();
        }

        private UnitOfWork Session;
        public int? CustomerId { get; set; }

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
            if (e.Reason == ObjectChangeReason.PropertyChanged)
                btnSave.Enabled = true;
        }

        private async void btnSave_ItemClick(object sender, ItemClickEventArgs e) {
            DisableButtons();
            try {
                await Session.CommitChangesAsync();
                Customer customer = (Customer)CustomersBindingSource.DataSource;
                CustomerId = customer.Oid; // a new object gets Oid from the database
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

        private void EnableButtons() {
            ICollection objectsToSave = Session.GetObjectsToSave();
            btnSave.Enabled = objectsToSave.Count > 0;
            btnRefresh.Enabled = true;
        }

        private void DisableButtons() {
            btnSave.Enabled = false;
            btnRefresh.Enabled = false;
        }
    }
}
