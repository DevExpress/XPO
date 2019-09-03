# Bind the Data Grid to a large data source

[Step 3](/implement-crud-functionality-with-xpo-objects.md)
&nbsp;&nbsp;&nbsp;
[Back to TOC](../../)

## Create the edit order Form
* Select the **EditCustomerForm** item in the **Solution Explorer** window and press **Ctrl+C** to copy the Form.
* Press **Ctrl+V** to create an EditCustomerForm copy. Rename it to **EditOrderForm**.
* Change the class and constructor name to **EditOrderForm**. Open the CustomersListForm.Designer.cs (vb) file and rename the class there. If this file is hidden, use the **Show All Files** toolbar item in the Solution Explorer window.
* Open the `EditOrderForm` designer and change the `Text` property to **Edit Order**.
* Rename the `CustomerBindingSource` component to **OrderBindingSource**.
* Rebuild the project and set the `OrderBindingSource.ObjectClassInfo` property to **DxSample.DataAccess.Order**.
* Set the `OrderBindingSource.DisplayableProperties` property to **ProductName;OrderDate;Freight;Customer!Key**. The last property name (**Customer!Key** is a [virtual property](https://docs.devexpress.com/XPO/3113/concepts/property-descriptors) designed for LookUp editors; see also: [How to: Bind an XPCollection to a LookUp](https://docs.devexpress.com/XPO/2000/examples/how-to-bind-an-xpcollection-to-a-lookup)).
* Rename the `CustomerLayoutControl` component to **OrderLayoutControl**.
* Rebuild the project and select the `OrderLayoutControl` component on the design surface.
* Click the **Retrieve Fields** smart tag command to open the **Select Binding Source** wizard.
* Click the **Next** button and choose these properties and editors on the **Manage Data Bindings** screen:
    * ProductName, TextEdit
    * OrderDate, DateEdit
    * Freight, CalcEdit
    * Customer, LookupEdit 
* Click the **Finish** button, delete the **First Name** and **Last Name** layout items, reorder the rest layout items to have the layout similar to the `EditCustomerForm`, and save changes.
* Add the `XPBindingSource` component to the `Form` and rename it to **CustomersBindingSource**.
* Rebuild the project.
* Set the `CustomersBindingSource.ObjectClassInfo` property to **DxSample.DataAccess.Customer**.
* Set the `CustomersBindingSource.DisplayableProperties` property to **Oid;ContactName**.
* Select the `lookUpEdit1` editor placed near the **Customer** label and open the **Data Source** smart tag menu. Find the `CustomersBindingSource` component under the **Other Data Sources > EditOrderForm List Instances** node and select it. 
* Select the **ContactName** and **Oid** properties as the **Display Member** and **Value Member** if they were not selected automatically.
* Open the code editor and change the code as follows
    <details>
        <summary>Click to expand</summary>   

    ```csharp
    using DevExpress.Xpo;
    using DevExpress.Xpo.DB.Exceptions;
    using DevExpress.XtraEditors;
    using DxSample.DataAccess;
    using System;
    using System.Windows.Forms;

    namespace DxSample.Forms {
        public partial class EditOrderForm : XtraForm {
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
                if (OrderID.HasValue)
                    OrderBindingSource.DataSource = UnitOfWork.GetObjectByKey<Order>(OrderID.Value);
                else OrderBindingSource.DataSource = new Order(UnitOfWork);
                CustomersBindingSource.DataSource = new XPCollection<Customer>(UnitOfWork);
            }

            private void btnSave_Click(object sender, EventArgs e) {
                try {
                    UnitOfWork.CommitChanges();
                    OrderID = ((Order)OrderBindingSource.DataSource).Oid;
                    Close();
                } catch (LockingException) {
                    XtraMessageBox.Show(this, "The record was modified or deleted by another user. Please click the Reload button and try again.", "XPO Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            private void btnReload_Click(object sender, EventArgs e) {
                Reload();
            }
        }
    }
    ```
    </details>
## Create the orders list Form
* Select the **CustomersListForm** item in the Solution Explorer window and press **Ctrl+C** to copy the Form.
* Press **Ctrl+V** to create a CustomersListForm copy. Rename it to **OrdersListForm**.
* Change the class name and constructor name to **OrdersListForm**.
* Open the `OrdersListForm` designer and change the `Text` property to **Orders**.
* Select the **Events** tab page in the **Properties** window, right click the `OrdersListForm.Load` event to invoke the context menu and select the **Reset** menu item.
* Add the `XPInstantFeedbackView` component from the toolbox. Change its name to **OrdersInstantFeedbackView**. This component is used with large data sources (see also: [Large Data Sources: Server and Instant Feedback Modes](https://docs.devexpress.com/WindowsForms/8398/controls-and-libraries/data-grid/data-binding/large-data-sources-server-and-instant-feedback-modes)).
* Rebuild the project and set the `OrdersInstantFeedbackView.ObjectType` property to **DxSample.DataAccess.Order**.
* Select the **Properties** property and click the ellipsis button to add these properties:
    * Name = Oid, Property = [Oid]
    * Name = Product Name, Property = [ProductName]
    * Name = Order Date, Property = [OrderDate]
    * Name = Freight, Property = [Freight]
* Delete the `CustomersBindingSource` component.
* Change the `CustomersGridControl` name to **OrdersGridControl** and do the same for `CustomersGridView`.
* Set the `OrdersGridControl.DataSource` property to **OrdersInstantFeedbackView**.
* Select the `OrdersGridControl` control on the design surface and click the **Run Designer** smart tag command.
* Select the **Columns** item in the navigation panel and click the **Retrieve Fields** button in the toolbar.
* Select the **Layout** item in the navigation panel, drag the **Oid** grid column down, and release it when the cross icon appears. The hidden **Oid** column will be used later to obtain object identifiers. Click the **Apply** button, close the designer, and save changes.
* Open the code editor and change the code as follows:
    <details>
    <summary>Click to expand</summary>

    ```csharp
    using DevExpress.Xpo;
    using DevExpress.XtraBars;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraGrid.Views.Grid;
    using DxSample.Forms;
    using System;

    namespace DxSample {
        public partial class OrdersListForm : RibbonForm {
            public OrdersListForm() {
                InitializeComponent();
            }
            private void CustomersGridView_RowClick(object sender, RowClickEventArgs e) {
                if (e.Clicks == 2) {
                    e.Handled = true;
                    int orderID = (int)OrdersGridView.GetRowCellValue(e.RowHandle, colOid);
                    ShowEditForm(orderID);
                }
            }

            private void ShowEditForm(int? orderID) {
                using (EditOrderForm form = new EditOrderForm(orderID)) {
                    form.ShowDialog(this);
                    Reload();
                    OrdersGridView.FocusedRowHandle = OrdersGridView.LocateByValue("Oid", form.OrderID.Value,
                        rowHandle => OrdersGridView.FocusedRowHandle = (int)rowHandle);
                }
            }
            private void Reload() {
                OrdersInstantFeedbackView.Refresh();
            }

            private void btnNew_ItemClick(object sender, ItemClickEventArgs e) {
                ShowEditForm(null);
            }

            private void btnDelete_ItemClick(object sender, ItemClickEventArgs e) {
                using (Session session = new Session()) {
                    object orderId = OrdersGridView.GetFocusedRowCellValue(colOid);
                    Order order = session.GetObjectByKey<Order>(orderId);
                    session.Delete(order);
                }
            }
        }
    }
    ```
    </details>

* Select the `OrdersInstantFeedbackView` component and double click the `ResolveSession` event to add the event handler. Do the same for the `DismissSession` event.
* Put this code in the event handlers:
    ```csharp
    private void OrdersInstantFeedbackView_ResolveSession(object sender, ResolveSessionEventArgs e) {
        e.Session = new Session()
    }

    private void OrdersInstantFeedbackView_DismissSession(object sender, ResolveSessionEventArgs e) {
        e.Session.Session.Dispose()
    }
    ```
## Create the navigation container Form
* Right-click the project item in the **Solution Explorer** to invoke the context menu and select the **Add DevExpress Item > New Item** menu item.
* In the **DevExpress Template Gallery** window, select the **WinForms** tab and click the **WinForms Popular UIs > UI-ready Form** item in the navigation control.
* In the **Settings** section, select the **Tabbed MDI** UI Type, select the **Navigation Container** View Type, and change the **Item Name** to **MainForm**.
* Open the `MainForm` designer.
* Set the `MainForm.Text` property to **XPO Tutorial**.
* Set the `employeesAccordionControlElement.Name` property to **ordersAccordionControlElement**.
* Set the `ordersAccordionControlElement.Text` property to **Orders**.
* Set the `documentManager.MdiParent` property to **MainForm**.
* Open the `MainForm` code file and change the code as follows:

    <details>
        <summary>Click to expand</summary>
        
    ```csharp
    using DevExpress.XtraBars.Docking2010.Views;
    using DevExpress.XtraBars;
    using DevExpress.XtraBars.Navigation;
    using DevExpress.XtraBars.Ribbon;
    using System.Windows.Forms;
    using System;
    using System.Globalization;

    namespace DxSample {
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
                switch (name) {
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
                if (e.Element == null) return;
                Form form = null;
                switch (e.Element.Text) {
                    case OrdersFormName:
                        form = ordersForm;
                        break;
                    case CustomersFormName:
                        form = customersForm;
                        break;
                }
                if (form != null) {
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
                switch (name) {
                    case OrdersFormName:
                        accordionControl.SelectedElement = ordersAccordionControlElement;
                        break;
                    case CustomersFormName:
                        accordionControl.SelectedElement = customersAccordionControlElement;
                        break;
                }
            }
            void RecreateForms(DocumentEventArgs e) {
                switch (e.Document.Caption) {
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
    ```
    </details>

* For C# projects only. Open the **Program.cs** file, and change this line
    ```csharp
    Application.Run(new CustomersListForm());
    ```
    to
    ```csharp
    Application.Run(new MainForm());
    ```
* Form VB.NET projects only. 
    * Right-click the project item in the **Solution Explorer** window to invoke the context menu and select the **Properties** menu item (you can use **Alt+Enter** instead). In the **Properties** window, select the **Application** page and change the **Startup Form** property to `MainForm`.
    * Open the `CustomersListForm` code, cut the `ConnectionHelper` and `DemoDataHelper` code, and paste it to the `MainForm` constructor
        ```vbnet
        Public Sub New()
            ConnectionHelper.Connect(False)
            Using uow As New UnitOfWork()
                DemoDataHelper.Seed(uow)
            End Using
            InitializeComponent()
            ordersForm = CreateForm(OrdersFormName)
            customersForm = CreateForm(CustomersFormName)
            accordionControl.SelectedElement = ordersAccordionControlElement
        End Sub
        ```
* Run the application and click the **Orders** navigation item to see the result.

[Step 3](/implement-crud-functionality-with-xpo-objects.md)
&nbsp;&nbsp;&nbsp;
[Back to TOC](../../)
