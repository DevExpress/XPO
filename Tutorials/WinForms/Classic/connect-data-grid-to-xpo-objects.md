# Connect Data Grid to XPO objects
[Step 1 <<](/Tutorials/WinForms/Classic/create-persistent-classes-and-connect-xpo-to-database.md) 
&nbsp;&nbsp;&nbsp;
[Back to TOC](/Tutorials/WinForms/Classic/)
&nbsp;&nbsp;&nbsp;
[>> Step 3](/Tutorials/WinForms/Classic/implement-crud-functionality-with-xpo-objects.md)   

* Open the `Form` designer.
* Add the `GridControl` component from the Toolbox and change its name to **CustomersGridControl**.
* Rebuild the project.
* Select the `CustomersGridControl` component on the design surface.
* Click the [smart-tag](https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/performing-common-tasks-using-smart-tags-on-wf-controls) glyph.
* Click the **Data Source Wizard** menu item to open the **Data Source Configuration Wizard** window.
* Select the **DevExpress ORM Tool (XPO)** Technology.
* Select the **Persistent Data Model** Data Source.\
  ![](/Tutorials/images/WinForms.Classic/2.1.png)
* Click the **Next** button.
* Select the **Client-Side Data Processing** item.\
  ![](/Tutorials/images/WinForms.Classic/2.2.png)
* Click the **Next** button.
* Select the **Customer** Object Type.
* Select the **Binding via the XPBindingSource component** Binding Type.\
  ![](/Tutorials/images/WinForms.Classic/2.3.png)
* Click the **Finish** button.
* The Wizard adds three components: `customerXPBindingSource`, 'unitOfWork1`, and `xpCollection1`. Delete the `unitOfWork1` and `xpCollection1` components.
* Rebuild the project.
* Set the `customerXPBindingSource.ObjectClassInfo` property to **DxSample.DataAccess.Customer** *(select a value from the drop-down list)* and rebuild the project.
* Set the `customerXPBindingSource.DisplayableProperties` property to **Oid;ContactName**.
* Set the `CustomersGridControl.Dock` property to **Fill**.
* Select the `gridView1` component in the **Properties** window and rename it to **CustomersGridView**.
* Change the `CustomersGridView.OptionsBehavior.Editable` property to `False`.
* Drag the **Oid** grid column down and release it when the cross icon appears.
    > Do not delete this column from the [Columns](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Base.ColumnView.Columns) collection. It holds object keys required to show the Edit Form or delete an object.
* Save changes. 
* Double click the Form header to add the `Form1_Load` event handler or use the **Properties** window to add it.
* Put this code in the auto-generated `Form1_Load` method:
    ```csharp
    using DevExpress.Xpo;
    // ...
    private void Form1_Load(object sender, EventArgs e) {
        Session session = new Session();
        customerXPBindingSource.DataSource = new XPCollection<Customer>(session);
    }
    ```
* Press the **F5** key to run the application.

[Step 1 <<](/Tutorials/WinForms/Classic/create-persistent-classes-and-connect-xpo-to-database.md) 
&nbsp;&nbsp;&nbsp;
[Back to TOC](/Tutorials/WinForms/Classic/)
&nbsp;&nbsp;&nbsp;
[>> Step 3](/Tutorials/WinForms/Classic/implement-crud-functionality-with-xpo-objects.md)   
