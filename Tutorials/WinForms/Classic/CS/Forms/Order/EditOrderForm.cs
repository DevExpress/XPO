using DevExpress.Xpo;
using DevExpress.Xpo.DB.Exceptions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Linq;
using System.Collections;
using XpoTutorial;

namespace WinFormsApplication.Forms {
    public partial class EditOrderForm : RibbonForm {
        public EditOrderForm() {
            InitializeComponent();
        }

        private UnitOfWork Session;
        public int? OrderId { get; set; }

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
                OrdersBindingSource.DataSource = OrderId.HasValue ? await Session.GetObjectByKeyAsync<Order>(OrderId.Value) : new Order(Session);
                CustomerEditor.Properties.DataSource = await Session.Query<Customer>().Select(c => new { c.Oid, c.ContactName }).ToListAsync();
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
                Order order = (Order)OrdersBindingSource.DataSource;
                OrderId = order.Oid; // a new object gets Oid from the database
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
