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
            tabbedView.QueryControl += TabbedView_QueryControl;
            customersAccordionControlElement.Tag = customersBarButtonItem.Tag = typeof(CustomersListForm).Name;
            ordersAccordionControlElement.Tag = ordersBarButtonItem.Tag = typeof(OrdersListForm).Name;
            SetAccordionSelectedElement((string)customersAccordionControlElement.Tag);
        }

        private void TabbedView_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e) {
            if(e.Document.ControlName == typeof(CustomersListForm).Name)
                e.Control = new CustomersListForm();
            else if(e.Document.ControlName == typeof(OrdersListForm).Name)
                e.Control = new OrdersListForm();
            else throw new ArgumentException($"Unknown control name {e.Document.ControlName}");
        }

        private void TabbedView_DocumentActivated(object sender, DocumentEventArgs e) {
            SetAccordionSelectedElement(e.Document.ControlName);
        }
        void accordionControl_SelectedElementChanged(object sender, SelectedElementChangedEventArgs e) {
            if(e.Element == null)
                return;
            string controlName = (string)e.Element.Tag;
            BaseDocument document = tabbedView.Documents.FindFirst(d => d.ControlName == controlName);
            if (document == null)
                document = tabbedView.AddDocument(e.Element.Text, controlName);
            tabbedView.Controller.Activate(document);
        }
        void barButtonNavigation_ItemClick(object sender, ItemClickEventArgs e) {
            SetAccordionSelectedElement((string)e.Item.Tag);
        }
        void SetAccordionSelectedElement(string controlTypeName) {
            accordionControl.SelectedElement = accordionControl.GetElements()
                .Single(e => (string)e.Tag == controlTypeName);
        }
    }
}
