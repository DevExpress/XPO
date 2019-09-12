# Create persistent classes and connect XPO to the database

&nbsp;&nbsp;&nbsp;
[Back to TOC](../../)
&nbsp;&nbsp;&nbsp;
[Step 2](/connect-data-grid-to-xpo-objects.md)   

* Create a new Windows Forms App project in Visual Studio.
* Add references to the following assemblies ([Manage references in a project](https://docs.microsoft.com/en-us/visualstudio/ide/managing-references-in-a-project)):  
  **DevExpress.Data**  
  **DevExpress.Xpo**  
  These assemblies are available under the **Assemblies > Extensions** category in the **Reference Manager**. 
* Create the **DataAccess** folder and add the `Customer` class to it. This class is a model for the Customer table in a database.
* Change the base class to `XPObject` and add a constructor with a `session` parameter:  
    ``` csharp
    using DevExpress.Xpo;

    namespace DxSample.DataAccess {
        public class Customer :XPObject {
            public Customer(Session session) : base(session) { }
        }
    }
    ```
    **See also:**   
    [XPO Classes Comparison](https://docs.devexpress.com/XPO/3311/concepts/xpo-classes-comparison)
* Add the `FirstName` and `LastName` properties to the `Customer` class. XPO maps these properties to columns in the Customer table.
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
    The `SetPropertyValue` method raises the `PropertyChanged` event that is used by data-bound controls to update their display text.
* Add the read-only `ContactName` property. XPO does not map read-only properties to database columns. Use the `FirstName` and `LastName` properties to calculate the `ContactName` property value.
    ```csharp
    public string ContactName {
        get { return string.Concat(FirstName, " ", LastName); }
    }
    ```
* Add the [PersistentAlias](https://docs.devexpress.com/XPO/DevExpress.Xpo.PersistentAliasAttribute) attribute to the `ContactName` property. 
  >The [PersistentAlias](https://docs.devexpress.com/XPO/DevExpress.Xpo.PersistentAliasAttribute) attribute specifies an expression that XPO should use instead of the property name in a SQL query. Use [Criteria Language](https://docs.devexpress.com/CoreLibraries/4928/devexpress-data-library/criteria-language-syntax) to build the expression. 
    ```csharp
    [PersistentAlias("concat(FirstName, ' ', LastName)")]
    public string ContactName {
        get { return string.Concat(FirstName, " ", LastName); }
    }
    ```
* Use the same approach to add the `Order` class with the `ProductName`(String), `OrderDate`(DateTime), and `Freight`(decimal) properties. The complete code is available here: [Order.cs](/Tutorials/WinForms/Classic/CS/DataAccess/Order.cs)  
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
* Add a reference to the **System.Configuration** assembly. This assembly contains classes used to access connection string settings from the application's configuration file [Connection Strings and Configuration Files](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files).
* Add the ([ConnectionHelper.cs](/Tutorials/WinForms/Classic/CS/DataAccess/ConnectionHelper.cs)) file to your project. 
  >This code initializes the [Data Access Layer](https://docs.devexpress.com/XPO/2121/Feature-Center/Connecting-to-a-Data-Store/Data-Access-Layer). Refer to the following article for more information: [Connecting to a Data Store](https://docs.devexpress.com/XPO/2020/feature-center/connecting-to-a-data-store).
* Open the *Program.cs* file and add the `ConnectionHelper.Connect` method call to the `Main` method.
  >Visual Studio does not create the *Program.vb* file in a VB.NET project, use the `Form1` class constructor, instead.
    ```csharp
    [STAThread]
    static void Main() {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        ConnectionHelper.Connect(false);
        Application.Run(new MainForm());
    }
    ```
* Open the application configuration file (*app.config*) and add the connection string. 
    ```xml
    <connectionStrings>
        <add name="XpoTutorial" connectionString="XpoProvider=InMemoryDataStore"/>
    </connectionStrings>
    ```
    >The [InMemoryDataStore](https://docs.devexpress.com/XPO/DevExpress.Xpo.DB.InMemoryDataStore) provider is for demo and testing purposes. You can use your database server or an embedded database (for example, [SQLite](https://www.sqlite.org/index.html)). XPO supports 14 database engines. Refer to the following articles for more information:\
    >[Database Systems Supported by XPO](https://docs.devexpress.com/XPO/2114/Fundamentals/Database-Systems-Supported-by-XPO)\
    >[K18445 - How to create a correct connection string for XPO providers](https://www.devexpress.com/Support/Center/Question/Details/K18445)
* To populate the database with the demo data, add the [DemoDataHelper.cs](/Tutorials/WinForms/Classic/CS/DataAccess/DemoDataHelper.cs) file to your project and put the following code after the `ConnectionHelper.Connect` method call.
    ```csharp
    using (UnitOfWork uow = new UnitOfWork()) {
        DemoDataHelper.Seed(uow);
    }
    ```
&nbsp;&nbsp;&nbsp;
[Back to TOC](../../)
&nbsp;&nbsp;&nbsp;
[Step 2](/connect-data-grid-to-xpo-objects.md)   
