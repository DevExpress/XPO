using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using WinFormsApplication.Forms;
using XpoTutorial;

namespace WinFormsApplication {
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm {
        public Form1() {
            InitializeComponent();
        }
        protected Session Session { get; private set; }
        private void CustomersListForm_Load(object sender, EventArgs e) {
            Reload();
        }

        private void CustomersGridView_RowClick(object sender, RowClickEventArgs e) {
            if(e.Clicks == 2) {
                e.Handled = true;
                int customerID = (int)CustomersGridView.GetRowCellValue(e.RowHandle, colOid);
                ShowEditForm(customerID);
            }
        }

        private void ShowEditForm(int? customerID) {
            using(EditCustomerForm form = new EditCustomerForm(customerID)) {
                form.ShowDialog(this);
                Reload();
                CustomersGridView.FocusedRowHandle = CustomersGridView.LocateByValue("Oid", form.CustomerID.Value);
            }
        }

        private void Reload() {
            Session = new Session();
            CustomersBindingSource.DataSource = new XPCollection<Customer>(Session);
        }

        private void BtnNew_ItemClick(object sender, ItemClickEventArgs e) {
            ShowEditForm(null);
        }

        private void BtnDelete_ItemClick(object sender, ItemClickEventArgs e) {
            object focusedObject = CustomersGridView.GetFocusedRow();
            Session.Delete(focusedObject);
        }
    }
}
