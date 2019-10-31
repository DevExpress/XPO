using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Xpo.DB.Exceptions;
using DevExpress.XtraEditors;
using XpoTutorial;

namespace WinFormsApplication.Forms {
    public partial class EditCustomerForm : XtraForm {
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
                customerXPBindingSource.DataSource = UnitOfWork.GetObjectByKey<Customer>(CustomerID.Value);
            else
                customerXPBindingSource.DataSource = new Customer(UnitOfWork);
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            try {
                UnitOfWork.CommitChanges();
                CustomerID = ((Customer)customerXPBindingSource.DataSource).Oid;
                Close();
            }
            catch(LockingException) {
                XtraMessageBox.Show(this, "The record was modified or deleted. Click Reload and try again.", "XPO Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnReload_Click(object sender, EventArgs e) {
            Reload();
        }
    }
}
