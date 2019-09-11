# Connect Data Grid to XPO objects
[Step 1 <<](/create-persistent-classes-and-connect-xpo-to-database.md) 
&nbsp;&nbsp;&nbsp;
[Back to TOC](../../)
&nbsp;&nbsp;&nbsp;
[>> Step 3](/implement-crud-functionality-with-xpo-objects.md)   

* Open the `Form` designer, add the `XPBindingSource` and `GridControl` components from Toolbox, and change their names to **CustomersBindingSource** and **CustomersGridControl**.
* Rebuild the project.
* Set the `CustomersBindingSource.ObjectClassInfo` property to **DxSample.DataAccess.Customer** *(select a value from the drop-down list)* and rebuild the project.
* Set the `CustomersBindingSource.DisplayableProperties` property to **Oid;ContactName**.
* Set the `CustomersGridControl.Dock` property to **Fill**.
* Set the `CustomersGridControl.DataSource` property to **CustomersSoruce**.
* Select the `gridView1` component in the **Properties** window and rename it to **CustomersGridView**.
* Change the `CustomersGridView.OptionsBehavior.Editable` property to `False`.
* Drag the **Oid** grid column down and release it when the cross icon appears.
    > Do not delete this column from the [Columns](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Base.ColumnView.Columns) collection. It is required to retrieve record indentifiers using the [GetRowCellValue](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Grid.GridView.GetRowCellValue.overloads) method.
* Save changes. 
* Double click the Form header to add the `Form1_Load` event handler or use the **Properties** window to add it.
* Put this code in the auto-generated `Form1_Load` method:
    ```csharp
    using DevExpress.Xpo;
    // ...
    private void Form1_Load(object sender, EventArgs e) {
        CustomersBindingSource.DataSource = new XPCollection<Customer>(new Session());
    }
    ```
* Press the **F5** key to run the application.

[Step 1 <<](/create-persistent-classes-and-connect-xpo-to-database.md) 
&nbsp;&nbsp;&nbsp;
[Back to TOC](../../)
&nbsp;&nbsp;&nbsp;
[>> Step 3](/implement-crud-functionality-with-xpo-objects.md)   
