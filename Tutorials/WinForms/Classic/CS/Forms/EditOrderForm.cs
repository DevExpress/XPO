using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Xpo.DB.Exceptions;
using DevExpress.XtraEditors;
using XpoTutorial;

namespace WinFormsApplication.Forms {
    public partial class EditOrderForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public EditOrderForm() {
            InitializeComponent();
        }
        public EditOrderForm(int? orderId) : this() {
            OrderID = orderId;
        }
        public int? OrderID { get; private set; }
        protected UnitOfWork UnitOfWork { get; private set; }
        private void EditCustomerForm_Load(object sender, EventArgs e) {
            Reload();
        }

        private void Reload() {
            UnitOfWork = new UnitOfWork();
            if(OrderID.HasValue)
                OrderBindingSource.DataSource = UnitOfWork.GetObjectByKey<Order>(OrderID.Value);
            else
                OrderBindingSource.DataSource = new Order(UnitOfWork);
            CustomersBindingSource.DataSource = new XPCollection<Customer>(UnitOfWork);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            try {
                UnitOfWork.CommitChanges();
                OrderID = ((Order)OrderBindingSource.DataSource).Oid;
                Close();
            }
            catch(LockingException) {
                XtraMessageBox.Show(this, "The record was modified or deleted. Please click the Reload button and try again.", "XPO Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
