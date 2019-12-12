# Implement CRUD functionality with XPO objects

[Step 2 <<](/Tutorials/WinForms/Classic/connect-data-grid-to-xpo-objects.md) 
&nbsp;&nbsp;&nbsp;
[Back to TOC](/Tutorials/WinForms/Classic/)
&nbsp;&nbsp;&nbsp;
[>> Step 4](/Tutorials/WinForms/Classic/bind-the-data-grid-to-large-data-source.md)   

## Edit an object in a separate window and save changes
* Create the *Forms* folder
* Right-click the *Forms* folder in the **Solution Explorer** to open the context menu.
* Click the **Add DevExpress Item > New Item** menu item to open the **DevExpress Template Gallery** window. 
* Select the **WinForms** category.
* Switch to the **WinForms Common > Ribbon Form** page.
* Set the **Item Name** property to **EditCustomerForm**. 
* Click the **Add Item** button to open a new Form in a visual designer.
*  Set the Form's `Text` property to **Edit Customer**.
* Move the *Form1.cs* file to the *Forms* folder and rename it to *CustomersListForm.cs*. 
  >Visual Studio should ask whether to change the class name. If not, open the code editor and use the **Rename** menu command (**Ctrl+R, Ctrl+R**) to change the class name. Change the base class to `XtraForm`, open the designer, and set the `Text` property to **Customers**.
* Add the `XPBindingSource` and `DataLayoutControl` components from the Toolbox and change their names to **CustomerBindingSource** and **CustomerLayoutControl**.
* Rebuild the project.
* Set the `CustomerBindingSource.ObjectClassInfo` property to **XpoTutorial.Customer** *(select a value from the drop-down list and rebuild the project)*.
* Set the `CustomerBindingSource.DisplayableProperties` property to **FirstName;LastName**.
* Set the `CustomerLayoutControl.Dock` property to **Fill**.
* Select the `CustomerLayoutControl` component on the design surface.
* Click the [smart-tag](https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/performing-common-tasks-using-smart-tags-on-wf-controls) glyph.
  >If the [smart-tag](https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/performing-common-tasks-using-smart-tags-on-wf-controls) glyph is not visible, press **Esc** several times to navigate from the selected `LayoutGroup` to the `LayoutControl`.
* Click the **Choose Data Source** combo box and select the `CustomersBindingSource` component.
* Click the **Retrieve Fields** menu item to open the **Select Binding Source** wizard.
* Change the **Data Source Update Mode** property value to **OnPropertyChanged** and click the **Next** button.
* The **Manage Data Bindings** screen displays a list of available properties. Choose the **First Name** and **Last Name** properties, click the **Finish** button, and save the changes.
* Open the code editor and overload the constructor to accept a nullable integer value (a database record's identifier).
    ```csharp
    public EditCustomerForm() {
        InitializeComponent();
    }
    public EditCustomerForm(int? customerId) : this() {
        CustomerID = customerId;
    }
    public int? CustomerID { get; private set; }
    ```
* Open the `Form` designer and double click the `Form` header to add the `EditCustomerForm_Load` event handler (you can use the **Properties** window to add it). 
* Put the following code in the auto-generated `EditCustomerForm_Load` method:
    ```csharp
    using DevExpress.Xpo;
    // ...
    protected UnitOfWork UnitOfWork { get; private set; }
    private void EditCustomerForm_Load(object sender, EventArgs e) {
        UnitOfWork = new UnitOfWork();
        if (CustomerID.HasValue)
            CustomerBindingSource.DataSource = UnitOfWork.GetObjectByKey<Customer>(CustomerID.Value);
        else CustomerBindingSource.DataSource = new Customer(UnitOfWork);
    }
    ```
* Open the `CustomersListForm` designer, select the `CustomersGridView` component in the **Properties** window, and double-click the `RowClick` event in the **Events** section to create the event handler.
* Add this code to the event handler:
    ``` csharp
    using DevExpress.XtraGrid.Views.Grid
    // ...
    private void CustomersGridView_RowClick(object sender, RowClickEventArgs e) {
        if(e.Clicks == 2) {
            e.Handled = true;
            int customerID = (int)CustomersGridView.GetRowCellValue(e.RowHandle, colOid);
            ShowEditForm(customerID);
        }
    }

    private void ShowEditForm(int? customerID) {
        var form = new EditCustomerForm(customerID);
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
    ```
* Press **F5** to run the application and double-click a `GridView` record.
* Close both windows and open the `EditCustomerForm` designer.
  * Change the `ribbonPage1` text to **Home**.
  * Change the `ribbonPageGroup1` text to **Edit**.
  * Delete the `ribbonPageGroup2`.
  * Add the `BarButtonItem` item to the **Edit** group and change its name to **btnSave**.
  * Set the `btnSave.Caption` property to **Save**.\
  ![](/Tutorials/images/WinForms.Classic/3.1.png)
* Double click the `btnSave` button to add the `ItemClick` event handler (you can use the **Properties** window to add it).
* Add this code to the `btnSave_ItemClick` event handler:
    ```csharp
    private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
        UnitOfWork.CommitChanges();
        Close();
    }
    ```
* The [UnitOfwork.CommitChanges](https://docs.devexpress.com/XPO/DevExpress.Xpo.UnitOfWork.CommitChanges) method saves changes to the database. To refresh the CustomersList Form, change the code in the `ShowEditForm` method as follows: 
    ```csharp
    private void Form1_Load(object sender, EventArgs e) {
        Reload();
    }
    
    private void ShowEditForm(int? customerID) {
        var form = new EditCustomerForm(customerID);
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
        var form = (EditCustomerForm)sender;
        form.FormClosed -= EditFormClosed;
        if (form.CustomerID.HasValue) {
            Reload();
            CustomersGridView.FocusedRowHandle = CustomersGridView.LocateByValue("Oid", form.CustomerID.Value);
        }
    }

    private void Reload() {
        Session = new Session();
        CustomersBindingSource.DataSource = new XPCollection<Customer>(Session);
    }
    ```
* Use the Visual Studio **Refactor** tool to rename the `Form1_Load` event handler to `CustomersListForm_Load`. To do this, put the cursor before the method name and click the **Edit > Refactor > Rename** menu item or use **Ctrl+R,Ctrl+R**.   
* Add the `BarButtonItem` item to the **Edit** group and change its name to **btnClose**.
* Set the `btnClose.Caption` property to **Close**.
* Double click the `btnClose` button to add the `ItemClick` event handler (you can use the **Properties** window to add it).
* Add this code to the `btnClose_ItemClick` event handler:
    ```csharp
    private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
        Close();
    }
    ```
* Run the application, open the edit Form, change something, and click the **Save** button.
## Handle concurrent changes
>You can skip this part if you use [InMemoryDataStore](https://docs.devexpress.com/XPO/DevExpress.Xpo.DB.InMemoryDataStore) or an embedded database.
### Test with multiple users 
* Build the project and open the output folder (*bin\Debug*) in the file manager. Locate the application executable file and run two application instances.
* Double click a record in one window to open the edit dialog, and double click the same record in another window.
* Type something and save changes in each window. The first application saves changes successfully, but the second fails with the following error message: *"Cannot persist the object. It was modified or deleted (purged) by another application"*.
### Handle the exception and reload an object
* Open the `EditCustomerForm` designer.
* Add the `BarButtonItem` item to the **Edit** group of the **Ribbon Control** and change its name to **btnReload**.
* Set the `btnReload.Caption` property to **Reload**.\
  ![](/Tutorials/images/WinForms.Classic/3.2.png)
* Double click the `btnReload` button to add the `ItemClick` event handler (you can use the **Properties** window to add it).
* Select all lines in the `EditCustomerForm_Load` method and click the **Edit > Refactor > Extract Method** menu item or use **Ctrl+R,Ctrl+M**.
* Change the method name to **Reload** and call this method in the `btnReload_ItemClick` event handler.
* Modify the `btnSave_ItemClick` method.
    ```csharp
    using DevExpress.Xpo.DB.Exceptions;
    // ...
    private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
        try {
            UnitOfWork.CommitChanges();
            Close();
        } catch (LockingException) {
            XtraMessageBox.Show(this, "The record was modified or deleted. Click Reload and try again.", "XPO Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
    ```
## Create a new record
  * Open the `CustomersListForm` in the designer.
  * Click the [smart-tag](https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/performing-common-tasks-using-smart-tags-on-wf-controls) glyph.
  * Click the **Convert to RibbonForm** menu item.
  * Change the `ribbonPage1` text to **Home**.
  * Change the `ribbonPageGroup1` text to **Edit**.
  * Delete the `ribbonPageGroup2`.
  * Add the `BarButtonItem` item to the **Edit** group and change its name to **btnNew**.
  * Set the `btnNew.Caption` property to **New**.
  * Double-click the **New** button to create an event handler.
  * Select the `using` statement in the `CustomersGridView_RowClick` method and click the **Edit > Refactor > Extract Method** menu item (**Ctrl+R,Ctrl+M**).
  * Change the method name to **ShowEditForm**.
  * Change the `customerID` parameter type to `int?`.
  * Call the `ShowEditForm` method in the `btnNew_ItemClick` event handler and pass the `null` value as a parameter.
  * Open the `EditCustomerForm` code and add the following line to the `btnSave_Click` method after the `CommitChanges` method call:
    ```csharp
    CustomerID = ((Customer)CustomerBindingSource.DataSource).Oid;
    ```
    >A new object does not have an identifier initially - XPO assigns a value to it from the auto-incremented key column when a new object is saved to the database. 
  * Run the application, click the New button, fill editors, and click the **Save** button.
## Delete a selected record
  * Open the `CustomersListForm` and add the **Delete (btnDelete)** button to the `RibbonControl`.
  * Double-click the **Delete** button to add the event handler.

  * Add the `Session` property to the `CustomersListForm` class.
  * Change the `Reload` method to use the `Session` property instead of a local variable:
    ```csharp
    protected Session Session { get; private set; }
    private void Reload() {
        Session = new Session();
        CustomersBindingSource.DataSource = new XPCollection<Customer>(Session);
    }
    ```
    >Note: You cannot use the [Session.Delete](https://docs.devexpress.com/XPO/DevExpress.Xpo.Session.Delete(System.Object)) method with an object that belongs to a different [Session](https://docs.devexpress.com/XPO/2022/Feature-Center/Connecting-to-a-Data-Store/Session). 
* Use the [GridView.GetFocusedRow](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Base.ColumnView.GetFocusedRow) method to retrieve a focused object  and call the [Session.Delete](https://docs.devexpress.com/XPO/DevExpress.Xpo.Session.Delete(System.Object)) method to delete the object.
    ```csharp
    private void btnDelete_ItemClick(object sender, ItemClickEventArgs e) {
        object focusedObject = CustomersGridView.GetFocusedRow();
        Session.Delete(focusedObject);
    }
    ```
* Run the application and try to delete a record.

[Step 2 <<](/Tutorials/WinForms/Classic/connect-data-grid-to-xpo-objects.md) 
&nbsp;&nbsp;&nbsp;
[Back to TOC](/Tutorials/WinForms/Classic/)
&nbsp;&nbsp;&nbsp;
[>> Step 4](/Tutorials/WinForms/Classic/bind-the-data-grid-to-large-data-source.md)   
