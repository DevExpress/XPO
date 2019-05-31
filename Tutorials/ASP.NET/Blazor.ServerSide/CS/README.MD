## Prerequisites

* [Visual Studio 2019 16.1 Preview 3 or later](https://visualstudio.com/preview) with the following workloads:
  * **ASP.NET and web development**
  * **.NET Core cross-platform development**
* [.NET Core SDK 3 Preview 5 or later](https://www.microsoft.com/net/download/all)
* [Blazor Templates and Extensions for Visual Studio 2019](https://docs.microsoft.com/en-us/aspnet/core/blazor/get-started?view=aspnetcore-3.0&tabs=visual-studio)
* [DevExpress UI Components for Blazor (CTP)](https://www.devexpress.com/blazor/)
* [Bootstrap 4.1](https://getbootstrap.com/docs/4.1/getting-started/download/) & [jQuery 3.4.1](https://jquery.com/download/) for Bootstrap's [modal dialog](https://getbootstrap.com/docs/4.1/components/modal/) (optional)

This app uses the [Server-side hosting model](https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-3.0#server-side).

# Step 1: Create a Blazor (server-side) web app

* From the Visual Studio **File** menu, select **New > Project**.
* Search for the **ASP.NET Core Web Application** template.

<p align="center">
  <img width="800" src="/Tutorials/images/Blazor.ServerSide/1.1.png">
</p>

* Click **Next**, set the project name to **BlazorServerSideApplication** and click **Create**.

<p align="center">
   <img width="800" src="/Tutorials/images/Blazor.ServerSide/1.2.png">
</p>

* Select **Blazor (server-side)** and click **Create**.

<p align="center">
   <img width="800" src="/Tutorials/images/Blazor.ServerSide/1.3.png">
</p>

* In **Solution Explorer**, remove the unnecessary **Data** folder and the following files from the **Pages** folder:
  * *Pages\Counter.razor*
  * *Models\FetchData.razor*

<p align="center">
  <img width="400" src="/Tutorials/images/Blazor.ServerSide/1.4.png">
</p>

* Open *Shared\NavMenu.razor* and comment out the following lines:
``` html
@*<li class="nav-item px-3">
    <NavLink class="nav-link" href="counter">
        <span class="oi oi-plus" aria-hidden="true"></span> Counter
    </NavLink>
</li>
<li class="nav-item px-3">
    <NavLink class="nav-link" href="fetchdata">
        <span class="oi oi-list-rich" aria-hidden="true"></span> Fetch data
    </NavLink>
</li>*@
```

* For more information, see the following:
  * [Introduction to Blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-3.0)
  * [DevExpress UI for Blazor (CTP) Demos](https://github.com/DevExpress/Blazor)

## Step 2: Add the DevExpress XPO ORM package with NuGet

You can install required packages using one of the following approaches:
* Package Manager Console
  * From the Visual Studio **Tools** menu, select **NuGet Package Manager > Package Manager Console**.
  * Make sure **Package source** is set to **All**, **nuget.org** or **DevExpress 19.1 Local** and run the following command: 
     ```console
    Install-Package DevExpress.Xpo -Version 19.1
    ```
OR

* NuGet Package Manager
  * In **Solution Explorer**, right-click the project name and select **Manage NuGet Packages**. <p align="center"><img width="400" src="/Tutorials/images/Blazor.ServerSide/2.1.png"></p>
  * Make sure **Package source** is set to **All**, **nuget.org** or **DevExpress 19.1 Local** on the right.
  * In the left top corner under **Browse**, search for the `DevExpress.Xpo` package and select its latest version, 19.1, on the right.
  * Click **Install** on the right and accept all the licenses in the **License Acceptance** dialogs. 
   
<p align="center">
  <img width="1000" src="/Tutorials/images/Blazor.ServerSide/2.2.png">
</p>
   
* For more information, see the following:
  * https://www.nuget.org/
  * https://nuget.devexpress.com/

## Step 3: Create ORM data model and seed initial data

* In **Solution Explorer**, create the **DataAccess** folder and add the *Customer.cs*, *Order.cs* and *DemoDataHelper.cs* code files. 

<p align="center">
  <img width="600" src="/Tutorials/images/Blazor.ServerSide/3.1.png">
</p>
<p align="center">
  <img width="400" src="/Tutorials/images/Blazor.ServerSide/3.2.png">
</p>

* Replace their contents with the code copied from the [corresponding files under this shared folder](https://github.com/DevExpress/XPO/tree/master/Tutorials/WinForms/Classic/CS/DataAccess). These files contain the following classes:
  * Customer and Order: form the persistent data model that maps to the corresponding tables in the database.
  * DemoDataHelper: provides the `Seed` method to create and save initial data in the database. This method will be called at the application startup in the next steps.

* For more information, see the following:
  * [Object Relational Mapping](https://docs.devexpress.com/XPO/2017/feature-center/object-relational-mapping)
  * [Persisting Objects](https://docs.devexpress.com/XPO/2025/feature-center/data-exchange-and-manipulation/persisting-objects)

## Step 4: Create helpers for JSON serialization and more

* In **Solution Explorer**, create the **Helpers** folder and add the *ApplicationBuilderExtensions.cs* and *JsonPopulateObjectHelper.cs* code files.
* Replace their contents with the code copied from [the corresponding files under this folder](https://github.com/DevExpress/XPO/tree/master/Tutorials/ASP.NET/MVC.Core/CS/Helpers). These files contain the following classes:
  * JsonPopulateObjectHelper: provides persistent type JSON serialization and deserialization.
  * ApplicationBuilderExtensions: declares the extension method `UseXpoDemoData`. It will call DemoDataHelper at the application startup in the next steps.

<p align="center">
  <img width="400" src="/Tutorials/images/Blazor.ServerSide/4.png">
</p>

* For more information, see the following:
  * [Serialization using ContractResolver](https://www.newtonsoft.com/json/help/html/ContractResolver.htm)
  * [XPClassInfo](https://docs.devexpress.com/XPO/DevExpress.Xpo.Metadata.XPClassInfo) | [XPMemberInfo](https://docs.devexpress.com/XPO/DevExpress.Xpo.Metadata.XPMemberInfo)

## Step 5: Configure database connection and plug in ORM data model

* In *Startup.cs*, modify the `Startup.ConfigureServices` method to configure Dependency Injection services for JSON serialization, database connection and CRUD operations using XPO.
Here is the modified code:

``` csharp
//...
//using BlazorServerSideApplication.Data; //Comment out.
using XpoTutorial;
using Microsoft.Extensions.Configuration;
using BlazorServerSideApplication.Services;

namespace BlazorServerSideApplication {
    public class Startup {
        //Added lines begin.
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        //Added lines end.

        public void ConfigureServices(IServiceCollection services) {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            //Added lines begin.
            //services.AddSingleton<WeatherForecastService>(); // Comment out.
            services.AddScoped<CustomerService>(); // See step 6.
            services.AddScoped<OrderService>(); // See step 6.
            services.AddXpoDefaultUnitOfWork(true, options => options
                    .UseConnectionString(Configuration.GetConnectionString("ImMemoryDataStore"))
                    .UseThreadSafeDataLayer(true)
                    .UseConnectionPool(false) // Remove this line if you use a database server like SQL Server, Oracle, PostgreSql etc.                    
                    .UseAutoCreationOption(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema) // Remove this line if the database already exists
                    .UseEntityTypes(typeof(Customer), typeof(Order)) // Pass all of your persistent object types to this method.
            );
            //Added lines end.
        }
//...
}
```

* In *Startup.cs*, modify the `Startup.Configure` method and add the `app.UseXpoDemoData();` call to create sample data discussed in steps 3 and 4.
Here is the modified code:
``` csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
    if(env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
    }
    else {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.UseEndpoints(endpoints => {
        endpoints.MapBlazorHub();
        endpoints.MapFallbackToPage("/_Host");
    });

    //Added lines begin.
    app.UseXpoDemoData();
    //Added lines end.
}
```

* In *appsettings.json*, add the connection string for an in-memory or any other [supported data store](https://docs.devexpress.com/XPO/2114/fundamentals/database-systems-supported-by-xpo).
Here is the modified code:

``` json
{
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "ConnectionStrings": {
    "ImMemoryDataStore": "XpoProvider=InMemoryDataStore;"
  }
}
```

* For more information, see the following:
  * [How to create a connection string for XPO providers](https://www.devexpress.com/Support/Center/Question/Details/K18445/how-to-create-a-correct-connection-string-for-xpo-providers)  
  * [Unit of Work](https://docs.devexpress.com/XPO/2138/feature-center/connecting-to-a-data-store/unit-of-work)
  * [Configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/index?view=aspnetcore-3.0)
  * [Dependency injection in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0)
  * [ASP.NET Core Dependency Injection in XPO](https://www.devexpress.com/Support/Center/Question/Details/T637597/asp-net-core-dependency-injection-in-xpo)


## Step 6: Manipulate data in services and bind it to Blazor components

* In **Solution Explorer**, create the **Services** folder and add the *CustomerService.cs* and *OrderService.cs* code files.
* Replace their contents with the code copied from [the corresponding files under this folder](https://github.com/DevExpress/XPO/tree/master/Tutorials/ASP.NET/Blazor.ServerSide/CS/Services). They contain the CustomerService and OrderService classes with the `Get`, `Add`, `Update`, and `Delete` API methods that represent [CRUD](https://en.wikipedia.org/wiki/Create,_read,_update_and_delete) operations with the Customer and Order persistent classes.
  * These services are registered using the `services.AddScoped<CustomerService>();` and `services.AddScoped<OrderService>();` calls in step 5.
  * The `Get` and GetCustomerOrders methods return the [IQueryable](https://docs.microsoft.com/en-us/dotnet/api/system.linq.iqueryable?view=netcore-3.0) source to load data from the database using [LINQ to XPO](https://docs.devexpress.com/XPO/4060/feature-center/querying-a-data-store/linq-to-xpo).
  * With IQueryable and DevExtreme.AspNet.Data, DxDataGrid can use the advanced features of [DevExtreme Data Layer](https://js.devexpress.com/Documentation/Guide/Data_Layer/Data_Layer/).
  * The `Add` and `Update` methods use the JsonPopulateObjectHelper class added in step 4 to populate persistent object properties with the request data. 
  * The following asynchronous XPO methods are used to implement CRUD operations in these controller methods: [Session.GetObjectByKeyAsync](https://docs.devexpress.com/XPO/DevExpress.Xpo.Session.GetObjectByKeyAsync.overloads), [Session.Delete](https://docs.devexpress.com/XPO/DevExpress.Xpo.Session.Delete.overloads), [UnitOfWork.CommitChangesAsync](https://docs.devexpress.com/XPO/DevExpress.Xpo.UnitOfWork.CommitChangesAsync.overloads).

* In the **wwwroot** folder, create the **lib** sub-folder. This is to store client-side libraries for DevExpress Blazor and other frameworks during development.
  * Download the *bootstrap.min.js* and *jquery-3.4.1.slim.min.js* JavaScript files for [Bootstrap 4.1](https://getbootstrap.com/docs/4.1/getting-started/download/) and [jQuery 3.4.1](https://jquery.com/download/) respectively. You can skip this step if you display modal dialogs without Bootstrap in the next steps.
  * Open https://github.com/DevExpress/Blazor, find the **"How to create a new project"** section and follow steps **2-5** to add DevExpress Blazor into the project.
  * Place the required DevExpress, Bootstrap and jQuery client-side libraries inside the **wwwroot/lib** sub-folder as follows:<p align="center"><img width="400" src="/Tutorials/images/Blazor.ServerSide/6.1.png"></p>
  * In *Pages/_Host.cshtml*, register DevExpress, Bootstrap and jQuery client-libraries using the **script** and **link** elements:

``` html
    <environment include="Development">
        <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" />
        @*//Added lines begin.*@
        <script src="/lib/jquery/jquery-3.4.1.slim.min.js"></script>/>
        <script src="/lib/bootstrap/bootstrap.min.js"></script>/>
        @*//Added lines end.*@
    </environment>
    </environment>
    @*...*@
    @*//Added lines begin.*@
    <link href="/lib/dx-blazor/dx-blazor.css" rel="stylesheet" />
    <script src="/lib/dx-blazor/dx-blazor.js"></script>
    @*//Added lines end.*@
</head>

```

* Replace the contents of *Pages/Index.razor* with the code copied from [the corresponding code file](https://github.com/DevExpress/XPO/blob/master/Tutorials/ASP.NET/Blazor.ServerSide/CS/Pages/Index.razor). It declares the Index page to display and edit the Customers list. 
  * [Razor syntax](https://www.w3schools.com/asp/razor_intro.asp) is used to configure DxDataGrid and other UI components.
  * [Templates](https://demos.devexpress.com/blazor/GridTemplate) are used to provide custom appearance and behavior for grid columns.
  * The `Data`, `RowUpdating`, `RowInserting` and `RowRemoving` grid parameters are used to bind grid to the Customer and Order services.
  * The `OnClickCustomerOrders` method is raised when the `Orders` button link is clicked. It updates the `SelectedCustomer` parameter and filters orders accordingly.
  * The Bootstrap's [modal dialog](https://getbootstrap.com/docs/4.1/components/modal/) is used to view and edit order data.
 
* For more information, see the following:
  * [Request a service in a component](https://docs.microsoft.com/en-us/aspnet/core/blazor/dependency-injection?view=aspnetcore-3.0#request-a-service-in-a-component)
  * [Create and use Razor components](https://docs.microsoft.com/en-us/aspnet/core/blazor/components?view=aspnetcore-3.0)
  * [FAQ: XPO Async/Await Method Support](https://www.devexpress.com/Support/Center/Question/Details/T683644/faq-xpo-async-await-method-support)
  * [Unit of Work](https://docs.devexpress.com/XPO/2138/feature-center/connecting-to-a-data-store/unit-of-work)


## Step 7: Run and test the app

* Build and run the application with **F5**. The web browser should show the Customers list. You can create, edit or delete customers.
* You can also view and edit their related orders in a separate form.
<p align="center">
  <img width="800" src="/Tutorials/images/Blazor.ServerSide/7.1.png">
</p>
<p align="center">
  <img width="800" src="/Tutorials/images/Blazor.ServerSide/7.2.png">
</p>

## Known issues
* The *Edit Orders* may display 'XXX  Wrong YYY data value type: ZZZ' instead of the OrderDate, Freight and other editors different from text boxes.
* The *System.ArgumentOutOfRangeException: 'Index was out of range. Must be non-negative and less than the size of the collection.'* error may occur at DevExtreme.AspNet.Data when deleting data under certain circumstances.
* A new order is always added to the source customer regardless of the Customer editor changes in the edit form.
