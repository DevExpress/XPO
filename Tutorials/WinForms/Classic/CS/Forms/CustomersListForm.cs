using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraGrid.Views.Grid;
using WinFormsApplication.Forms;
using XpoTutorial;

namespace WinFormsApplication {
    public partial class CustomersListForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public CustomersListForm() {
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
            var form = new EditCustomerForm(customerID);
            form.FormClosed += (s, e) => {
                if (form.CustomerID.HasValue) {
                    Reload();
                    CustomersGridView.FocusedRowHandle = CustomersGridView.LocateByValue("Oid", form.CustomerID.Value);
                }
            };
            var documentManager = DocumentManager.FromControl(MdiParent);
            if (documentManager != null) {
                documentManager.View.AddDocument(form);
            } else {
                try {
                    form.ShowDialog();
                } finally {
                    form.Dispose();
                }
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
