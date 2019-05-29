using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System.Collections;
using XpoTutorial;

namespace WinFormsApplication.Forms {
    public partial class EditOrderNestedForm : RibbonForm {
        private EditOrderNestedForm() {
            InitializeComponent();
        }

        public EditOrderNestedForm(Session session) : this() {
            Session = session;
        }

        private Session Session;
        private NestedUnitOfWork UOW;
        public Order Order { get; set; }

        private void EditOrderForm_Load(object sender, System.EventArgs e) {
            Reload();
        }

        private void Reload() {
            DisableButtons();
            try {
                if (UOW != null) {
                    UOW.ObjectChanged -= Session_ObjectChanged;
                }
                UOW = Session.BeginNestedUnitOfWork();
                UOW.ObjectChanged += Session_ObjectChanged;
                OrdersBindingSource.DataSource = Order == null ? new Order(UOW) : UOW.GetNestedObject(Order);
            } finally { EnableButtons(); }
        }

        private void Session_ObjectChanged(object sender, ObjectChangeEventArgs e) {
            if (e.Reason == ObjectChangeReason.PropertyChanged)
                btnSave.Enabled = true;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e) {
            DisableButtons();
            try {
                UOW.CommitChanges();
                Order order = (Order)OrdersBindingSource.DataSource;
                Order = UOW.GetParentObject(order);
                Close();
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
