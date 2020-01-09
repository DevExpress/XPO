using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Xpo.DB.Exceptions;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using XpoTutorial;

namespace WinFormsApplication.Forms {
    public partial class EditCustomerForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public EditCustomerForm() {
            InitializeComponent();
        }
        public EditCustomerForm(int? customerId) : this() {
            CustomerID = customerId;
        }

        public int? CustomerID { get; private set; }

        protected UnitOfWork UnitOfWork { get; private set; }
        private void EditCustomerForm_Load(object sender, EventArgs e) {
            Reload();
        }

        private void Reload() {
            UnitOfWork = new UnitOfWork();
            if(CustomerID.HasValue)
                CustomerBindingSource.DataSource = UnitOfWork.GetObjectByKey<Customer>(CustomerID.Value);
            else
                CustomerBindingSource.DataSource = new Customer(UnitOfWork);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            try {
                UnitOfWork.CommitChanges();
                CustomerID = ((Customer)CustomerBindingSource.DataSource).Oid;
                Close();
            }
            catch(LockingException) {
                XtraMessageBox.Show(this, "The record was modified or deleted. Click Reload and try again.", "XPO Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            Reload();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            Close();
        }
    }
}
