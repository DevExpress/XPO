# Bind the Data Grid to a large data source

[Step 3](/Tutorials/WinForms/Classic/implement-crud-functionality-with-xpo-objects.md)
&nbsp;&nbsp;&nbsp;
[Back to TOC](/Tutorials/WinForms/Classic/)

## Create the edit order Form
* Select the **EditCustomerForm** item in the **Solution Explorer** window and press **Ctrl+C** to copy the Form.
* Press **Ctrl+V** to create a copy of an EditCustomerForm and rename it to **EditOrderForm**.
* Change the class and constructor name to **EditOrderForm**. Open the *CustomersListForm.Designer.cs* file and rename the class there. If this file is hidden, use the **Show All Files** toolbar item in the Solution Explorer window.
* Open the `EditOrderForm` designer and change the `Text` property to **Edit Order**.
* Rename the `CustomerBindingSource` component to **OrderBindingSource**.
* Rebuild the project and set the `OrderBindingSource.ObjectClassInfo` property to **DxSample.DataAccess.Order**.
* Set the `OrderBindingSource.DisplayableProperties` property to **ProductName;OrderDate;Freight;Customer!Key**. 
  >The last property name (**Customer!Key** is a [virtual property](https://docs.devexpress.com/XPO/3113/concepts/property-descriptors) designed for LookUp editors. See also: [How to: Bind an XPCollection to a LookUp](https://docs.devexpress.com/XPO/2000/examples/how-to-bind-an-xpcollection-to-a-lookup)).
* Rename the `CustomerLayoutControl` component to **OrderLayoutControl**.
* Rebuild the project.
* Select the `OrderLayoutControl` component on the design surface. 
* Click the [smart-tag](https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/performing-common-tasks-using-smart-tags-on-wf-controls) glyph.
  >If the [smart-tag](https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/performing-common-tasks-using-smart-tags-on-wf-controls) glyph is not visible, press **Esc** several times to navigate from the selected `LayoutGroup` to the `LayoutControl`.
* Click the **Retrieve Fields** item to open the **Select Binding Source** wizard.
* Click the **Next** button to open the **Manage Data Bindings** screen.
* Assign `Editor Type` to each property as shown in the screenshot:
  ![](/Tutorials/images/WinForms.Classic/4.2.png)
* Click the **Finish** button, delete the **First Name** and **Last Name** layout items, reorder the rest layout items to create a layout similar to the `EditCustomerForm`, and save the changes.\
  ![](/Tutorials/images/WinForms.Classic/4.1.png)
* Add the `XPBindingSource` component to the `Form` and rename it to **CustomersBindingSource**.
* Rebuild the project.
* Set the `CustomersBindingSource.ObjectClassInfo` property to **DxSample.DataAccess.Customer**.
* Set the `CustomersBindingSource.DisplayableProperties` property to **Oid;ContactName**.
* Select the `lookUpEdit1` editor and click the [smart-tag](https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/performing-common-tasks-using-smart-tags-on-wf-controls) glyph. 
* Click the **Data Source** item to open the drop-down list and select the `CustomersBindingSource` component under the **Other Data Sources > EditOrderForm List Instances** node. 
* Select the **ContactName** and **Oid** properties as the **Display Member** and **Value Member** if they were not selected automatically.
* Open the code editor and change the code as follows:
    <details>
        <summary>Click to expand</summary>   

    ```csharp
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
    ```
    </details>
## Create the orders list Form
* Select the **CustomersListForm** item in the Solution Explorer window and press **Ctrl+C** to copy the Form.
* Press **Ctrl+V** to create a copy of a CustomersListForm copy and rename it to **OrdersListForm**.
* Change the class and constructor name to **OrdersListForm**.
* Open the `OrdersListForm` designer and change the `Text` property to **Orders**.
* Select the **Events** page in the **Properties** window.
* Right-click the `OrdersListForm.Load` event to open the context menu.
* Click the **Reset** menu item.
* Add the [XPInstantFeedbackView](https://docs.devexpress.com/XPO/DevExpress.Xpo.XPInstantFeedbackView) component from the Toolbox. Change its name to **OrdersInstantFeedbackView**. 
  > The [XPInstantFeedbackView](https://docs.devexpress.com/XPO/DevExpress.Xpo.XPInstantFeedbackView) component improves performance when working with large tables. Refer to the [Large Data Sources: Server and Instant Feedback Modes](https://docs.devexpress.com/WindowsForms/8398/controls-and-libraries/data-grid/data-binding/large-data-sources-server-and-instant-feedback-modes) article for for information.
* Rebuild the project and set the `OrdersInstantFeedbackView.ObjectType` property to **DxSample.DataAccess.Order**.
* Select the **Properties** property and click the ellipsis button to add the following properties:
    * Name = Oid, Property = [Oid]
    * Name = Product Name, Property = [ProductName]
    * Name = Order Date, Property = [OrderDate]
    * Name = Freight, Property = [Freight]
* Delete the `CustomersBindingSource` component.
* Change the `CustomersGridControl` name to **OrdersGridControl** and do the same for `CustomersGridView`.
* Set the `OrdersGridControl.DataSource` property to **OrdersInstantFeedbackView**.
* Select the `OrdersGridControl` control and click the [smart-tag](https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/performing-common-tasks-using-smart-tags-on-wf-controls) glyph. 
* Click the **Run Designer** menu item.
* Switch to the **Columns** page and click the **Retrieve Fields** button in the toolbar.
* Switch to the **Layout** page, drag the **Oid** grid column down, and release it when the cross icon appears. 
  > Do not delete this column from the [Columns](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Base.ColumnView.Columns) collection. It stores object keys required to show the Edit Form or delete an object. 
* Click **Apply**, close the designer, and save the changes.
* Open the code editor and change the code as follows:
    <details>
    <summary>Click to expand</summary>

    ```csharp
     using System;
     using DevExpress.Xpo;
     using DevExpress.XtraBars;
     using DevExpress.XtraBars.Docking2010;
     using DevExpress.XtraBars.Ribbon;
     using DevExpress.XtraGrid.Views.Grid;
     using WinFormsApplication.Forms;
     using XpoTutorial;
     
     namespace WinFormsApplication {
         public partial class OrdersListForm : RibbonForm {
             public OrdersListForm() {
                 InitializeComponent();
             }
             private void OrdersGridView_RowClick(object sender, RowClickEventArgs e) {
                 if(e.Clicks == 2) {
                     e.Handled = true;
                     int orderID = (int)OrdersGridView.GetRowCellValue(e.RowHandle, colOid);
                     ShowEditForm(orderID);
                 }
             }
     
             private void ShowEditForm(int? orderID) {
                 var form = new EditOrderForm(orderID);
                 form.FormClosed += EditFormClosed;
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
     
             private void EditFormClosed(object sender, EventArgs e) {
                 var form = (EditOrderForm)sender;
                 form.FormClosed -= EditFormClosed;
                 if (form.OrderID.HasValue) {
                     Reload();
                     OrdersGridView.FocusedRowHandle = OrdersGridView.LocateByValue("Oid", form.OrderID.Value,
                         rowHandle => OrdersGridView.FocusedRowHandle = (int)rowHandle);
                 }
             }
             
             private void Reload() {
                 OrdersInstantFeedbackView.Refresh();
             }
     
             private void BtnNew_ItemClick(object sender, ItemClickEventArgs e) {
                 ShowEditForm(null);
             }
     
             private void BtnDelete_ItemClick(object sender, ItemClickEventArgs e) {
                 using(Session session = new Session()) {
                     object orderId = OrdersGridView.GetFocusedRowCellValue(colOid);
                     Order order = session.GetObjectByKey<Order>(orderId);
                     session.Delete(order);
                 }
                 Reload();
             }
         }
     }
    ```
    </details>

* Use the Visual Studio **Refactor** tool to rename the `CustomersGridView_RowClick` event handler to `OrdersGridView_RowClick`. To do this, put the cursor before the method name and click the **Edit > Refactor > Rename** menu item or use **Ctrl+R,Ctrl+R**.   
* Select the `OrdersInstantFeedbackView` component and double click the `ResolveSession` event to add the event handler. Do the same for the `DismissSession` event.
* Add the following code to the event handlers:
    ```csharp
    private void OrdersInstantFeedbackView_ResolveSession(object sender, ResolveSessionEventArgs e) {
        e.Session = new Session();
    }

    private void OrdersInstantFeedbackView_DismissSession(object sender, ResolveSessionEventArgs e) {
        e.Session.Session.Dispose();
    }
    ```
## Create the navigation container Form
* Right-click the project item in the **Solution Explorer** to open the context menu.
* Click the **Add DevExpress Item > New Item** menu item.
* In the **DevExpress Template Gallery** window, select the **WinForms** category and switch to the **WinForms Popular UIs > UI-ready Form** page.
* Set the **UI Type** property to **Tabbed MDI**.
* Set the **View Type** property to **Navigation Container**.
* Set the **Item Name** property to **MainForm**.
* Click the **Add Item** button.
* Open the `MainForm` designer.
* Set the `MainForm.Text` property to **XPO Tutorial**.
* Set the `employeesAccordionControlElement.Name` property to **ordersAccordionControlElement**.
* Set the `ordersAccordionControlElement.Text` property to **Orders**.
* Select the `ribbonControl` component on the design surface. 
* Click the [smart-tag](https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/performing-common-tasks-using-smart-tags-on-wf-controls) glyph.
* Click the **Run Designer** item to open the **Ribbon Control Designer** dialog.
* In the **Toolbar > Ribbon Items** category, select the **Employees** item. Set its Caption and Name properties to **Orders** and **ordersBarButtonItem**, accordingly.
* Close the designer.
* Select the `documentManager` component on the design surface. 
* Click the [smart-tag](https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/performing-common-tasks-using-smart-tags-on-wf-controls) glyph.
* Click the **Run Designer** item to open the **DocumentManager Designer** dialog.
* In the **Main > Views** category, select the **tabbedView** item.
* Select the **Events** category in the property grid and right-click the **DocumentClosed** event to open te context menu.
* Click the **Reset** menu item.
* Close the designer.
* Set the `documentManager.MdiParent` property to **MainForm**.
* Open the `MainForm` code file and change the code as follows:

    <details>
        <summary>Click to expand</summary>
        
   ```csharp
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
    ```
    </details>

* For C# projects. 
    * Open the **Program.cs** file, and change 
      ```csharp
      Application.Run(new CustomersListForm());
      ```
      to
      ```csharp
      Application.Run(new MainForm());
      ```
* For VB.NET projects. 
    * Right-click the project item in the **Solution Explorer** window to open the context menu.
    * Click the **Properties** menu item (or use **Alt+Enter**). 
    * In the **Properties** window, switch to the **Application** page.
    * Set the **Startup Form** property to **MainForm**.
    * Open the `CustomersListForm` code, cut the `ConnectionHelper` and `DemoDataHelper` code, and paste it in the `MainForm` constructor.
        ```vbnet
        Public Sub New()
            ConnectionHelper.Connect(False)
            Using uow As New UnitOfWork()
                DemoDataHelper.Seed(uow)
            End Using
            InitializeComponent()
            ...
        End Sub
        ```
* Run the application and click the **Orders** navigation item to see the result.

[Step 3](/Tutorials/WinForms/Classic/implement-crud-functionality-with-xpo-objects.md)
&nbsp;&nbsp;&nbsp;
[Back to TOC](/Tutorials/WinForms/Classic/)
