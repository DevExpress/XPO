## Overview

This tutorial demonstrates how to create a server-side Blazor application that uses the DevExpress ORM Library (XPO) to access and manage data. In this tutorial, we store data [in memory](https://docs.devexpress.com/XPO/DevExpress.Xpo.DB.InMemoryDataStore) in the JSON format.

<p align="center">
  <img width="562" src="/Tutorials/images/Blazor.ServerSide/7.1.png">
</p>
<p align="center">
  <img width="800" src="/Tutorials/images/Blazor.ServerSide/7.2.png">
</p>

## Prerequisites

* [Visual Studio 2019 16.4.5 or later](https://visualstudio.com/) with the following workloads:
  * **ASP.NET and web development**
  * **.NET Core cross-platform development**
* [.NET Core 3.1 SDK or later](https://www.microsoft.com/net/download/all)
* [Newtonsoft.Json library](https://www.newtonsoft.com/json)
* [DevExpress UI Components for Blazor](https://www.devexpress.com/blazor/)
* [Bootstrap 4.1](https://getbootstrap.com/docs/4.1/getting-started/download/) & [jQuery](https://jquery.com/download/) for Bootstrap's [modal dialog](https://getbootstrap.com/docs/4.1/components/modal/)


This app uses the [Server-side hosting model](https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-3.0#server-side).

## Step 1: Create a Blazor (Server-Side) Web App

1. Open Visual Studio and create a new project.
2. Search for the **Blazor App** template.

    <p align="center">
      <img width="800" src="/Tutorials/images/Blazor.ServerSide/1.1.png">
    </p>

    Click **Next** to proceed.
3. Set the project name to **BlazorServerSideApplication** and click **Create**.

    <p align="center">
      <img width="800" src="/Tutorials/images/Blazor.ServerSide/1.2.png">
    </p>

4. Select **Blazor Server App** and click **Create**.

    <p align="center">
      <img width="800" src="/Tutorials/images/Blazor.ServerSide/1.3.png">
    </p>

5. In the **Solution Explorer**, remove the unnecessary **Data** folder and the following files from the **Pages** folder:

    * *Pages\Counter.razor*
    * *Models\FetchData.razor*

    <p align="center">
      <img width="400" src="/Tutorials/images/Blazor.ServerSide/1.4.png">
    </p>

6. Open *Shared\NavMenu.razor* and comment out the following lines:
    ```html
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

For more information, see the following:

* [Introduction to Blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-3.0)
* [DevExpress UI for Blazor Demos](https://github.com/DevExpress/Blazor)

## Step 2: Add the Newtonsoft.Json and DevExpress XPO Packages

### Add the Newtonsoft.Json Package

In this tutorial, we store data in memory in the JSON format. To serialize and deserialize data, we use the [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) package. Run the following command in the Package Manager Console to install the package: 

```console
Install-Package Newtonsoft.Json -Version 12.0.3
```

### Add the XPO Package

Use any of the following approaches to install the XPO package:

**Package Manager Console**

  * From the Visual Studio **Tools** menu, select **NuGet Package Manager > Package Manager Console**.
  * Make sure **Package source** is set to **All**, **nuget.org** or **DevExpress 20.1 Local** and run the following command: 
     ```console
    Install-Package DevExpress.Xpo -Version 20.1
    ```

**NuGet Package Manager**

  * In **Solution Explorer**, right-click the project name and select **Manage NuGet Packages**. <p align="center"><img width="400" src="/Tutorials/images/Blazor.ServerSide/2.1.png"></p>
  * Make sure **Package source** is set to **All**, **nuget.org** or **DevExpress 20.1 Local** on the right.
  * In the top left corner under **Browse**, search for the `DevExpress.Xpo` package and select the latest version, v20.1, on the right.
  * Click **Install** and accept all licenses in the **License Acceptance** dialogs. 
    <p align="center">
      <img width="1000" src="/Tutorials/images/Blazor.ServerSide/2.2.png">
    </p>
   
For more information, see the following:

  * https://www.nuget.org/
  * https://nuget.devexpress.com/

## Step 3: Create ORM Data Model and Seed Initial Data

1. In the **Solution Explorer**, create the **DataAccess** folder and add the *Customer.cs*, *Order.cs* and *DemoDataHelper.cs* code files. 

<p align="center">
  <img width="600" src="/Tutorials/images/Blazor.ServerSide/3.1.png">
</p>
<p align="center">
  <img width="400" src="/Tutorials/images/Blazor.ServerSide/3.2.png">
</p>

2. Replace their contents with the code copied from the [corresponding files under this folder](https://github.com/DevExpress/XPO/tree/master/Tutorials/ASP.NET/Blazor.ServerSide/CS/DataAccess). These files contain the following classes:
    * `Customer` and `Order`: implement the persistent data model that maps to the corresponding tables in the database.
    * `DemoDataHelper`: implements the `Seed` method to create and save initial data in the database. This method is called at the application startup (see the next steps).

For more information, see the following:

  * [Object Relational Mapping](https://docs.devexpress.com/XPO/2017/feature-center/object-relational-mapping)
  * [Persisting Objects](https://docs.devexpress.com/XPO/2025/feature-center/data-exchange-and-manipulation/persisting-objects)

## Step 4: Create Helpers for JSON Serialization

1. In **Solution Explorer**, create the **Helpers** folder and add the *ApplicationBuilderExtensions.cs* and *JsonPopulateObjectHelper.cs* code files.
2. Replace their contents with the code copied from [the corresponding files under this folder](https://github.com/DevExpress/XPO/tree/master/Tutorials/ASP.NET/Blazor.ServerSide/CS/Helpers). These files contain the following classes:
    * `JsonPopulateObjectHelper`: implements persistent type JSON serialization and deserialization.
    * `ApplicationBuilderExtensions`: declares the `UseXpoDemoData` extension method. It calls `DemoDataHelper` at the application startup in the next steps.

<p align="center">
  <img src="/Tutorials/images/Blazor.ServerSide/4.png">
</p>

For more information, see the following:
  * [Serialization using ContractResolver](https://www.newtonsoft.com/json/help/html/ContractResolver.htm)
  * [XPClassInfo](https://docs.devexpress.com/XPO/DevExpress.Xpo.Metadata.XPClassInfo) | [XPMemberInfo](https://docs.devexpress.com/XPO/DevExpress.Xpo.Metadata.XPMemberInfo)

## Step 5: Configure Database Connection and Plug in the ORM Data Model

1. In *Startup.cs*, modify the `Startup.ConfigureServices` method to configure Dependency Injection services for JSON serialization, database connection, and CRUD operations with XPO.

    The modified code is as follows:

    ```csharp
    //...
    //using BlazorServerSideApplication.Data; //Comment out.
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
                //services.AddSingleton<WeatherForecastService>();
                services.AddScoped<CustomerService>();
                services.AddScoped<OrderService>();
                services.AddXpoDefaultDataLayer(ServiceLifetime.Singleton, dl => dl
                    .UseConnectionString(Configuration.GetConnectionString("InMemoryDataStore"))
                    .UseThreadSafeDataLayer(true)
                    .UseConnectionPool(false) // Remove this line if you use a database server like SQL Server, Oracle, PostgreSql, etc.
                    .UseAutoCreationOption(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema) // Remove this line if the database already exists
                    .UseEntityTypes(typeof(Customer), typeof(Order)) // Pass all your persistent object types to this method.
                );
                services.AddXpoDefaultUnitOfWork();
                //Added lines end.
            }
    //...
    }
    ```

2. In *Startup.cs*, modify the `Startup.Configure` method and add the `app.UseXpoDemoData();` call to create sample data discussed in steps 3 and 4.

    The modified code is as follows:
    ```csharp
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

3. In *appsettings.json*, add the connection string for an in-memory or other [supported database system](https://docs.devexpress.com/XPO/2114/fundamentals/database-systems-supported-by-xpo).

    The modified code is as follows:

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

For more information, see the following topics:
  * [How to create a connection string for XPO providers](https://www.devexpress.com/Support/Center/Question/Details/K18445/how-to-create-a-correct-connection-string-for-xpo-providers)  
  * [Unit of Work](https://docs.devexpress.com/XPO/2138/feature-center/connecting-to-a-data-store/unit-of-work)
  * [Configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/index?view=aspnetcore-3.0)
  * [Dependency injection in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0)
  * [ASP.NET Core Dependency Injection in XPO](https://www.devexpress.com/Support/Center/Question/Details/T637597/asp-net-core-dependency-injection-in-xpo)


## Step 6: Manipulate Data in Services and Bind Blazor Components to Data

1. In **Solution Explorer**, create the **Services** folder and add the *CustomerService.cs* and *OrderService.cs* code files.
2. Replace their contents with the code copied from [the corresponding files under this folder](https://github.com/DevExpress/XPO/tree/master/Tutorials/ASP.NET/Blazor.ServerSide/CS/Services). They contain the _CustomerService_ and _OrderService_ classes with the `Get`, `Add`, `Update`, and `Delete` API methods that represent [CRUD](https://en.wikipedia.org/wiki/Create,_read,_update_and_delete) operations with the `Customer` and `Order` persistent classes.

    * These services are registered by the `services.AddScoped<CustomerService>();` and `services.AddScoped<OrderService>();` calls in step 5.
    * The `Get` and GetCustomerOrders methods return the [IQueryable](https://docs.microsoft.com/en-us/dotnet/api/system.linq.iqueryable?view=netcore-3.0) source to load data from the database using [LINQ to XPO](https://docs.devexpress.com/XPO/4060/feature-center/querying-a-data-store/linq-to-xpo).
    * With IQueryable and DevExtreme.AspNet.Data, DxDataGrid can use the advanced features of the [DevExtreme Data Layer](https://js.devexpress.com/Documentation/Guide/Data_Layer/Data_Layer/).
    * The `Add` and `Update` methods use the JsonPopulateObjectHelper class added in step 4 to populate persistent object properties with the request data. 
    * The following asynchronous XPO methods are used to implement CRUD operations in these controller methods: [Session.GetObjectByKeyAsync](https://docs.devexpress.com/XPO/DevExpress.Xpo.Session.GetObjectByKeyAsync.overloads), [Session.Delete](https://docs.devexpress.com/XPO/DevExpress.Xpo.Session.Delete.overloads), [UnitOfWork.CommitChangesAsync](https://docs.devexpress.com/XPO/DevExpress.Xpo.UnitOfWork.CommitChangesAsync.overloads).

3. In the **wwwroot** folder, create the **lib** sub-folder. This is to store client-side libraries for DevExpress Blazor and other frameworks during development.
    * Download the *bootstrap.min.js* and *jquery-3.5.1.slim.min.js* JavaScript files from [Bootstrap 4.1](https://getbootstrap.com/docs/4.1/getting-started/download/) and [jQuery](https://jquery.com/download/) respectively. 
    * Open the [Getting Started - Configure a Blazor Application](https://docs.devexpress.com/Blazor/401057/getting-started/configure-a-blazor-application) tutorial, and follow steps **2-4** to add DevExpress UI components for Blazor into the project.
    * Place the Bootstrap and jQuery client-side libraries inside the **wwwroot/lib** sub-folder as follows: <p align="center"><img src="/Tutorials/images/Blazor.ServerSide/6.1.png"></p>
    * In *Pages/_Host.cshtml*, register DevExpress, Bootstrap and jQuery client-libraries using the **script** and **link** elements:

      ``` html
      <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title>BlazorServerSideApplication</title>
        <base href="~/" />
        <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" />
        <link href="css/site.css" rel="stylesheet" />
        <link href="_content/DevExpress.Blazor/dx-blazor.css" rel="stylesheet" />

          <script src="~/lib/jquery/jquery-3.5.1.slim.min.js"></script>
          <script src="~/lib/bootstrap/bootstrap.min.js"></script>
      </head>
      ```

4. Replace the contents of *Pages/Index.razor* with the code copied from [the corresponding code file](https://github.com/DevExpress/XPO/blob/master/Tutorials/ASP.NET/Blazor.ServerSide/CS/Pages/Index.razor). It declares the Index page to display and edit the Customers list. 

    * [Razor syntax](https://www.w3schools.com/asp/razor_intro.asp) is used to configure DxDataGrid and other UI components.
    * [Templates](https://demos.devexpress.com/blazor/GridTemplate) are used to provide custom appearance and behavior for grid columns.
    * The `Data`, `RowUpdating`, `RowInserting` and `RowRemoving` grid parameters are used to bind grid to the Customer and Order services.
    * The `OnClickCustomerOrders` method is raised when the `Orders` button link is clicked. It updates the `SelectedCustomer` parameter and filters orders accordingly.
    * The Bootstrap's [modal dialog](https://getbootstrap.com/docs/4.1/components/modal/) is used to view and edit order data.
 

For more information, see the following:
  * [Request a service in a component](https://docs.microsoft.com/en-us/aspnet/core/blazor/dependency-injection?view=aspnetcore-3.0#request-a-service-in-a-component)
  * [Create and use Razor components](https://docs.microsoft.com/en-us/aspnet/core/blazor/components?view=aspnetcore-3.0)
  * [FAQ: XPO Async/Await Method Support](https://www.devexpress.com/Support/Center/Question/Details/T683644/faq-xpo-async-await-method-support)
  * [Unit of Work](https://docs.devexpress.com/XPO/2138/feature-center/connecting-to-a-data-store/unit-of-work)


## Step 7: Run and Test the App

1. Build and run the application with **F5**. The web browser should show the _Customers_ list. You can create, edit or delete customers.
2. You can also view and edit customer related orders in a separate form.
<p align="center">
  <img width="562" src="/Tutorials/images/Blazor.ServerSide/7.1.png">
</p>
<p align="center">
  <img width="800" src="/Tutorials/images/Blazor.ServerSide/7.2.png">
</p>

## Known Issues

* The *Edit Orders* may display 'XXX  Wrong YYY data value type: ZZZ' instead of the OrderDate, Freight and other editors different from text boxes.
* The *System.ArgumentOutOfRangeException: 'Index was out of range. Must be non-negative and less than the size of the collection.'* error may occur at DevExtreme.AspNet.Data when deleting data under certain circumstances.
* A new order is always added to the source customer regardless of the Customer editor changes in the edit form.
