using System;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using System.Linq;

namespace WinFormsApplication {
    public partial class MainForm : RibbonForm {
        public MainForm() {
            InitializeComponent();
            tabbedView.DocumentActivated += TabbedView_DocumentActivated;
            tabbedView.DocumentClosed += TabbedView_DocumentClosed;
            tabbedView.QueryControl += TabbedView_QueryControl;
            customersAccordionControlElement.Tag = nameof(CustomersListForm);
            ordersAccordionControlElement.Tag = nameof(OrdersListForm);
            ActivateDocument("Customers", nameof(CustomersListForm));
        }

        private void TabbedView_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e) {
            switch (e.Document.ControlName) {
                case nameof(CustomersListForm):
                    e.Control = new CustomersListForm();
                    break;
                case nameof(OrdersListForm):
                    e.Control = new OrdersListForm();
                    break;
                default:
                    throw new ArgumentException($"Unknown control name {e.Document.ControlName}");
            }
        }

        private void TabbedView_DocumentActivated(object sender, DocumentEventArgs e) {
            accordionControl.SelectedElement = accordionControl.GetElements()
                .Single(t => (string)t.Tag == e.Document.ControlName);
            if (ribbonControl.MergedPages.Count > 0) {
                ribbonControl.SelectedPage = ribbonControl.MergedPages[0];
            }
        }

        private void TabbedView_DocumentClosed(object sender, DocumentEventArgs e) {
            if(tabbedView.Documents.Count == 0) {
                accordionControl.SelectedElement = null;
            }
        }
        void ActivateDocument(string caption, string controlName) {
            BaseDocument document = tabbedView.Documents.FindFirst(d => d.ControlName == controlName);
            if (document == null)
                document = tabbedView.AddDocument(caption, controlName);
            tabbedView.Controller.Activate(document);
        }

        private void customersAccordionControlElement_Click(object sender, EventArgs e) {
            ActivateDocument("Customers", nameof(CustomersListForm));
        }

        private void ordersAccordionControlElement_Click(object sender, EventArgs e) {
            ActivateDocument("Orders", nameof(OrdersListForm));
        }

        private void customersBarButtonItem_ItemClick(object sender, ItemClickEventArgs e) {
            ActivateDocument("Customers", nameof(CustomersListForm));
        }

        private void ordersBarButtonItem_ItemClick(object sender, ItemClickEventArgs e) {
            ActivateDocument("Orders", nameof(OrdersListForm));
        }
    }
}
