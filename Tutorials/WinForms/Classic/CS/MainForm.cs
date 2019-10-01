using System;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using System.Globalization;

namespace WinFormsApplication {
    public partial class MainForm : RibbonForm {
        const string OrdersFormName = "Orders";
        const string CustomersFormName = "Customers";
        Form ordersForm;
        Form customersForm;
        public MainForm() {
            InitializeComponent();
            ordersForm = CreateForm(OrdersFormName);
            customersForm = CreateForm(CustomersFormName);
            accordionControl.SelectedElement = ordersAccordionControlElement;
            tabbedView.DocumentActivated += TabbedView_DocumentActivated;
        }

        private void TabbedView_DocumentActivated(object sender, DocumentEventArgs e) {
            SetAccordionSelectedElement(e.Document.Caption);
        }

        Form CreateForm(string name) {
            Form result = null;
            switch(name) {
                case OrdersFormName:
                    result = new OrdersListForm();
                    break;
                case CustomersFormName:
                    result = new CustomersListForm();
                    break;
                default:
                    string msg = string.Format(CultureInfo.CurrentUICulture, "Unknown view name: {0}", name);
                    throw new ArgumentException(msg);
            }
            return result;
        }
        void accordionControl_SelectedElementChanged(object sender, SelectedElementChangedEventArgs e) {
            if(e.Element == null)
                return;
            Form form = null;
            switch(e.Element.Text) {
                case OrdersFormName:
                    form = ordersForm;
                    break;
                case CustomersFormName:
                    form = customersForm;
                    break;
            }
            if(form != null) {
                tabbedView.AddDocument(form);
                tabbedView.ActivateDocument(form);
            }
        }
        void barButtonNavigation_ItemClick(object sender, ItemClickEventArgs e) {
            SetAccordionSelectedElement(e.Item.Caption);
        }
        void tabbedView_DocumentClosed(object sender, DocumentEventArgs e) {
            RecreateForms(e);
        }
        void SetAccordionSelectedElement(string name) {
            switch(name) {
                case OrdersFormName:
                    accordionControl.SelectedElement = ordersAccordionControlElement;
                    break;
                case CustomersFormName:
                    accordionControl.SelectedElement = customersAccordionControlElement;
                    break;
            }
        }
        void RecreateForms(DocumentEventArgs e) {
            switch(e.Document.Caption) {
                case OrdersFormName:
                    ordersForm = CreateForm(OrdersFormName);
                    break;
                case CustomersFormName:
                    customersForm = CreateForm(CustomersFormName);
                    break;
            }
        }
    }
}
