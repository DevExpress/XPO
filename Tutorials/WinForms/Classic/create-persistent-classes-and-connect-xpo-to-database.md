# Create persistent classes and connect XPO to the database

&nbsp;&nbsp;&nbsp;
[Back to TOC](../../)
&nbsp;&nbsp;&nbsp;
[Step 2](/connect-data-grid-to-xpo-objects.md)   

* Create a new Windows Forms App project in Visual Studio.
* Add references to these assemblies ([Manage references in a project](https://docs.microsoft.com/en-us/visualstudio/ide/managing-references-in-a-project)):  
  **DevExpress.Data**  
  **DevExpress.Xpo**  
  These assemblies are available under the **Assemblies > Extensions** category in the **Reference Manager**. 
* Create the **DataAccess** folder and add the **Customer** class to it. This class is a model for the Customer table in a database.
* Change the base class to **XPObject** and add a constructor with a **session** parameter:  
    ``` csharp
    using DevExpress.Xpo;

    namespace DxSample.DataAccess {
        public class Customer :XPObject {
            public Customer(Session session) : base(session) { }
        }
    }
    ```
    ### See also:  
    [XPO Classes Comparison](https://docs.devexpress.com/XPO/3311/concepts/xpo-classes-comparison)
* Add the **FirstName** and **LastName** properties to the **Customer** class. XPO maps these proeprties to columns in the Customer table.
    ```csharp
    public string FirstName {
        get { return fFirstName; }
        set { SetPropertyValue(nameof(FirstName), ref fFirstName, value); }
    }

    private string fLastName;
    public string LastName {
        get { return fLastName; }
        set { SetPropertyValue(nameof(LastName), ref fLastName, value); }
    }
    ```
    The **SetPropertyValue** method raises the **PropertyChanged** event that is used by data bound controls to update their display text.
* Add the read-only **ContactName** property. This property is not mapped to any column. Use the `FirstName` and `LastName` properties to calcualate the `ContactName` property value.
    ```csharp
    public string ContactName {
        get { return string.Concat(FirstName, " ", LastName); }
    }
    ```
* Add the [PersistentAliasAttribute](https://docs.devexpress.com/XPO/DevExpress.Xpo.PersistentAliasAttribute) to the **ContactName** property. With this attribute, XPO will be able to include this property in a filter. The expression passed to the attribute constructor should follow the [Criteria Language Syntax](https://docs.devexpress.com/CoreLibraries/4928/devexpress-data-library/criteria-language-syntax). XPO uses the Persistent Alias expression to build a SQL command compatible with the target database.
    ```csharp
    [PersistentAlias("concat(FirstName, ' ', LastName)")]
    public string ContactName {
        get { return string.Concat(FirstName, " ", LastName); }
    }
    ```
* Use the same approach to add the **Order** class with the **ProductName**(String), **OrderDate**(DateTime), and **Freight**(decimal) properties. Check our example code in case of any difficulty:  
  [Order.cs](/Tutorials/WinForms/Classic/CS/DataAccess/Order.cs)  
  [Order.vb](/Tutorials/WinForms/Classic/VB/DataAccess/Order.vb)
* Add the `Orders` and `Customer` properties to create a [relationship](https://docs.devexpress.com/XPO/2041/concepts/relationships-between-objects) between the **Customer** and **Order** classes.
    ```csharp
    // Customer.cs
    [Association("CustomerOrders")]
    public XPCollection<Order> Orders {
        get { return GetCollection<Order>(nameof(Orders)); }
    }
    
    // Order.cs
    private Customer fCustomer;
    [Association("CustomerOrders")]
    public Customer Customer {
        get { return fCustomer; }
        set { SetPropertyValue(nameof(Customer), ref fCustomer, value); }
    }
    ```
* Add a reference to the **System.Configuration** assembly. It is required to read the connection string settings from the application configuration file [Connection Strings and Configuration Files][15].
* Add the **ConnectionHelper** class and copy the code from the [ConnectionHelper.cs](/Tutorials/WinForms/Classic/CS/DataAccess/ConnectionHelper.cs) ([ConnectionHelper.vb](/Tutorials/WinForms/Classic/VB/DataAccess/ConnectionHelper.vb)) file. In most cases, this generic helper can be used without modifications. The complete documentation about possible connection settings is provided in the XPO documentation: [Connecting to a Data Store](https://docs.devexpress.com/XPO/2020/feature-center/connecting-to-a-data-store).
* Open the *Program.cs* file and add the **ConnectionHelper.Connect** method call to the **Main** method (the *Program.vb* file does not exist in a VB.NET project by defult, use the **Form1** class constructor, instead):
    ```csharp
    [STAThread]
    static void Main() {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        ConnectionHelper.Connect(false);
        Application.Run(new MainForm());
    }
    ```
* Open the application configuration file (app.config) and add the connection string. The InMemoryDataStore provider is used in this tutorial for the sake of simplicity. The complete list of supported XPO providers is provided at [K18445 - How to create a correct connection string for XPO providers](https://www.devexpress.com/Support/Center/Question/Details/K18445).
    ```xml
    <connectionStrings>
        <add name="XpoTutorial" connectionString="XpoProvider=InMemoryDataStore"/>
    </connectionStrings>
    ```
* To populate the database with the initial demo data, add the [DemoDataHelper.cs](/Tutorials/WinForms/Classic/CS/DataAccess/DemoDataHelper.cs)/[DemoDataHelper.vb](/Tutorials/WinForms/Classic/VB/DataAccess/DemoDataHelper.vb) file to your project and put this code after the **ConnectionHelper.Connect** method call.
    ```csharp
    using (UnitOfWork uow = new UnitOfWork()) {
        DemoDataHelper.Seed(uow);
    }
    ```
&nbsp;&nbsp;&nbsp;
[Back to TOC](../../)
&nbsp;&nbsp;&nbsp;
[Step 2](/connect-data-grid-to-xpo-objects.md)   