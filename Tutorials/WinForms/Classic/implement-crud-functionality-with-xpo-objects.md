# Implement CRUD functionality with XPO objects

[Step 2 <<](/connect-data-grid-to-xpo-objects.md) 
&nbsp;&nbsp;&nbsp;
[Back to TOC](../../)
&nbsp;&nbsp;&nbsp;
[>> Step 4](/bind-the-data-grid-to-large-data-source.md)   

## Edit an object in a separate window and save changes
* Create the **Forms** folder and invoke the context menu for it in the **Solution Explorer**. 
* Click the **Add DevExpress Item**  to open the **DevExpress Template Gallery** window. 
* In the **WinForms** tab page, select the **WinForms Common > Form** item and change the **Item Name** to **EditCustomerForm**. 
* Click the **Add Item** button to open a new Form in a visual designer.
*  Select the `Text` property in the **Properties** window and change it to **Edit Customer**.
* Move the *Form1.cs* file to the *Forms* folder and rename the file to *CustomersListForm.cs*. Visual Studio should prompt whether to change the class name as well. If not, open the code editor and use the **Rename** menu command (**Ctrl+R, Ctrl+R**) to change the class name . Change the base class to `XtraForm`, open the designer, and set the `Text` property to **Customers**.
* Drop the `XPBindingSource` and `DataLayoutControl` components from the toolbox and change their names to **CustomerBindingSource** and **CustomerLayoutControl**.
* Rebuild the project.
* Set the `CustomerBindingSource.ObjectClassInfo` property to **DxSample.DataAccess.Customer** *(select a value from the drop-down list and rebuild the project)*.
* Set the `CustomerBindingSource.DisplayableProperties` property to **FirstName;LastName**.
* Set the `CustomerLayoutControl.Dock` property to **Fill**.
* Select the `CustomerLayoutControl` component on the design surface.
* Click the **Retrieve Fields** smart tag command to open the **Select Binding Source** wizard (if the smart tag icon is not visible, press the **Esc** key to navigate from the root `LayoutGroup` to the `LayoutControl`).
* Change the **Data Source Update Mode** property value to **OnPropertyChanged** and click the **Next** button.
* The **Manage Data Bindings** screen displays a list of available properties. Choose the **First Name** and **Last Name** properties, click the **Finish** button, and save changes.
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
* Put this code in the auto-generated `EditCustomerForm_Load` method:
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
        if (e.Clicks == 2) {
            e.Handled = true;
            int customerID = (int)CustomersGridView.GetRowCellValue(e.RowHandle, colOid);
            using (EditCustomerForm form = new EditCustomerForm(customerID)) {
                form.ShowDialog(this);
            }
        }
    }
    ```
* Press the **F5** key to run the application, double-click a `GridView` record, and see the result.
* Close the both windows and open the `EditCustomerForm` in the designer. Drag a `SimpleButton` component from the toolbox and drop it to the `LayoutControl`. Add `EmptySpaceItem` elements to neatly align the button.
* Rename the `simpleButton1` control to **btnSave** and change its `Text` to **&Save** (the ampersand sign assigns a mnemonic command to the button).
* Double click the `btnSave` control to add the `Click` event handler (you can use the **Properties** window to add it).
* Add this code to the `btnSave_Click` event handler:
    ```csharp
    private void btnSave_Click(object sender, EventArgs e) {
        UnitOfWork.CommitChanges();
        Close();
    }
    ```
* The [UnitOfwork.CommitChanges](https://docs.devexpress.com/XPO/DevExpress.Xpo.UnitOfWork.CommitChanges) method saves changes to the database. To show changes in the Data Grid (`CustomersListForm`), change code as follows: 
    ```csharp
    private void Form1_Load(object sender, EventArgs e) {
        Reload();
    }
    private void CustomersGridView_RowClick(object sender, RowClickEventArgs e) {
        if (e.Clicks == 2) {
            e.Handled = true;
            int customerID = (int)CustomersGridView.GetRowCellValue(e.RowHandle, colOid);
            using (EditCustomerForm form = new EditCustomerForm(customerID)) {
                form.ShowDialog(this);
                Reload();
                CustomersGridView.FocusedRowHandle = CustomersGridView.LocateByValue("Oid", form.CustomerID.Value);
            }
        }
    }
    private void Reload() {
        CustomersBindingSource.DataSource = new XPCollection<Customer>(new Session());
    }
    ```
* Optionally, use the Visual Studio **Refactor** tool to rename the `Form1_Load` event handler to `CustomersListForm_Load`. Put the cursor at the method name and click the **Edit > Refactor > Rename** menu item or use **Ctrl+R,Ctrl+R**.   
* Run the application, open the edit Form, change something, and click the **Save** button to see the result.
## Handle concurrent changes    
### Test with multiple users
* Open the *App.config* file and change the connection string to use your database server ([K18445 - How to create a correct connection string for XPO providers](https://www.devexpress.com/Support/Center/Question/Details/K18445)). *You can skip this and the next 3 steps if you do not use a database server*.
* Build the project and open the output folder (*bin\Debug*) in the file manager. Locate the application executable file and run two application instances.
* Double click a record in one window to open the edit dialog, and double click the same record in another window.
* Type something and save changes in each window. The second time the application should crash and show this error message: *Cannot persist the object. It was modified or deleted (purged) by another application*. The next section demonstrates how to handle such situations gracefully.
### Handle the exception and reload an object
* Open the `EditCustomerForm` in the designer. Drag a `SimpleButton` component from the toolbox and drop it to the `LayoutControl`. Customize the layout to align all buttons neatly.
* Rename the `simpleButton1` control to **btnReload** and set the `Text` property to **&Reload**.
* Double click the `btnReload` control to add the `Click` event handler (you can use the **Properties** window to add it).
* Select all lines in the `EditCustomerForm_Load` method and click the **Edit > Refactor > Extract Method** menu item or use **Ctrl+R,Ctrl+M**.
* Change the method name to **Reload** and call this method in the `btnReload_Click` event handler.
* Modify the `btnSave_Click` method.
    ```csharp
    using DevExpress.Xpo.DB.Exceptions;
    // ...
    private void btnSave_Click(object sender, EventArgs e) {
        try {
            UnitOfWork.CommitChanges();
            Close();
        } catch (LockingException) {
            XtraMessageBox.Show(this, "The record was modified or deleted by another user. Please click the Reload button and try again.", "XPO Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
    ```
## Create a new record
  * Open the `CustomersListForm` in the designer.
  * Click the **Convert to RibbonForm** smart tag command.
  * Change the `ribbonPage1` text to **Home**.
  * Change the `ribbonPageGroup1` text to **Edit**.
  * Delete the `ribbonPageGroup2`.
  * Add the `BarButtonItem` item to the **Edit** group and change its name to **btnNew**.
  * Set the `btnNew.Caption` property to **New**.
  * Double-click the **New** button to create an event handler.
  * Select the `using` statement in the `CustomersGridView_RowClick` method and click the **Edit > Refactor > Extract Method** menu item (**Ctrl+R,Ctrl+M**).
  * Change the method name to **ShowEditForm**.
  * Change the `customerID` parameter type to `int?`.
  * Call the `ShowEditForm` method in the `btnNew_ItemClick` event handler and pass a `null` value as a parameter.
  * A new object initially does not have an identifier. XPO assigns a value to it from the auto-incremented key column when a new object is saved to the database. Open the `EditCustomerForm` code and add this line to the `btnSave_Click` method after the `CommitChanges` method call:
    ```csharp
    CustomerID = ((Customer)CustomerBindingSource.DataSource).Oid;
    ```
  * Run the application, click the New button, fill editors, and click the **Save** button to see the result.
## Delete a selected record
  * Open the `CustomersListForm` and add the **Delete (btnDelete)** button to the `RibbonControl`.
  * Double-click the **Delete** button to add the event handler.
  * Change the `Reload` method to make the `Session` instance available in the class scope:
    ```csharp
    protected Session Session { get; private set; }
    private void Reload() {
        Session = new Session();
        CustomersBindingSource.DataSource = new XPCollection<Customer>(Session);
    }
    ```
* Use the [GridView.GetFocusedRow](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Base.ColumnView.GetFocusedRow) method to retrieve a focused object  and call the [Session.Delete](https://docs.devexpress.com/XPO/DevExpress.Xpo.Session.Delete(System.Object)) method to delete the object.
    ```csharp
    private void btnDelete_ItemClick(object sender, ItemClickEventArgs e) {
        object focusedObject = CustomersGridView.GetFocusedRow();
        Session.Delete(focusedObject);
    }
    ```
* Run the application and try to delete a record to see the result.

[Step 2 <<](/connect-data-grid-to-xpo-objects.md) 
&nbsp;&nbsp;&nbsp;
[Back to TOC](../../)
&nbsp;&nbsp;&nbsp;
[>> Step 4](/bind-the-data-grid-to-large-data-source.md)   
