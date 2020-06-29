## Overview

This tutorial demonstrates how to create an ASP.NET Core MVC application that uses the DevExpress ORM Library (XPO) to access and manage data. In this tutorial, we store data in the [in-memory source](https://docs.devexpress.com/XPO/DevExpress.Xpo.DB.InMemoryDataStore) and use the JSON format to save and load data to/from the data source.

<p align="center">
  <img src="/Tutorials/images/MVC.Core/7.1.png">
</p>

<p align="center">
  <img src="/Tutorials/images/MVC.Core/7.2.png">
</p>


## Prerequisites

* [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) with the following workloads:
  * **ASP.NET and web development**
  * **.NET Core cross-platform development**
* [.NET Core SDK 3.1 or later](https://www.microsoft.com/net/download/all)
* [Newtonsoft.Json library](https://www.newtonsoft.com/json)
* [Unified Installer for .NET and HTML5 Developers](https://www.devexpress.com/Products/Try/)
  * We recommend that you select all the DevExpress products when you run the installation. It will register local NuGet package sources, item and project templates required for these tutorials. You can uninstall unnecessary components later.

## Step 1: Create an ASP.NET Core Web App with the DevExtreme Template

1. Open Visual Studio and create a new project.
2. Search for the **DevExtreme 20.1 ASP.NET Core Application (.NET Core)** template.<p align="center">  <img width="800" src="/Tutorials/images/MVC.Core/1.1.png"></p>
    
    Click **Next** to proceed.

3. Set the project name to **AspNetCoreMvcApplication** and click **Create**.

    <p align="center"><img src="/Tutorials/images/MVC.Core/1.2.png"></p>

4. Select **ASP.NET Core 3.1** and **MVC Views** and click Create.

    <p align="center"><img width="540" src="/Tutorials/images/MVC.Core/1.2.1.png"></p>

5. In **Solution Explorer**, remove unnecessary files:

    * *Controllers\SampleDataController.cs*
    * *Models\Order.cs*
    * *Models\SampleData.cs*


For more information, see the following:

  * [Overview of ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.0)
  * [DevExtreme-based ASP.NET Core controls | Getting Started](https://docs.devexpress.com/AspNetCore/400572/concepts/devextreme-based-controls/getting-started?v=20.1)
  
## Step 2: Add the Microsoft.AspNetCore.Mvc.NewtonsoftJson and DevExpress XPO Packages

### Add the Microsoft.AspNetCore.Mvc.NewtonsoftJson Package

In this tutorial, we store data in memory in the JSON format. To serialize and deserialize data, we use the [Newtonsoft.Json](https://www.newtonsoft.com/json) library shipped as a part of the [Microsoft.AspNetCore.Mvc.NewtonsoftJson](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/3.1.5) package. Run the following command in the Package Manager Console to install the package: 

```console
Install-Package Microsoft.AspNetCore.Mvc.NewtonsoftJson
```

### Add the XPO package

Use any of the following approaches to install the XPO package:

**Package Manager Console**

* From the Visual Studio **Tools** menu, select **NuGet Package Manager > Package Manager Console**.
* Make sure **Package source** is set to **All**, **nuget.org** or **DevExpress 20.1 Local** and run the following command: 
    ```console
  Install-Package DevExpress.Xpo -Version 20.1
  ```

**NuGet Package Manager**

* In **Solution Explorer**, right-click the project name and select **Manage NuGet Packages**. <p align="center"><img width="400" src="/Tutorials/images/MVC.Core/2.1.png"></p>
* Make sure **Package source** is set to **All**, **nuget.org** or **DevExpress 20.1 Local** on the right.
* In the top left corner under **Browse**, search for the `DevExpress.Xpo` package and select the latest version, v20.1, on the right.
* Click **Install** on the right and accept all the licenses in the **License Acceptance** dialogs. <p align="center">
<img width="1000" src="/Tutorials/images/MVC.Core/2.2.png">
</p>
   
For more information, see the following:
  * https://www.nuget.org/
  * https://nuget.devexpress.com/

## Step 3: Create ORM data model and Seed Initial Data

1. In the **Solution Explorer**, create the **DataAccess** folder and add the *Customer.cs*, *Order.cs* and *DemoDataHelper.cs* code files. 

    <p align="center"><img width="800" src="/Tutorials/images/MVC.Core/3.1.png"></p> 
    
    <p align="center"><img width="400" src="/Tutorials/images/MVC.Core/3.2.png"></p>

2. Replace their contents with the code copied from the [corresponding files under this folder](https://github.com/DevExpress/XPO/tree/master/Tutorials/ASP.NET/MVC.Core/CS/DataAccess). These files contain the following classes:
    * `Customer` and `Order` implement the persistent data model that maps to the corresponding tables in the database.
    * `DemoDataHelper`: implements the `Seed` method to create and save initial data in the database. This method is called at the application startup (see the next steps).

For more information, see the following:

* [Object Relational Mapping](https://docs.devexpress.com/XPO/2017/feature-center/object-relational-mapping)
* [Persisting Objects](https://docs.devexpress.com/XPO/2025/feature-center/data-exchange-and-manipulation/persisting-objects)

## Step 4: Create Helpers for JSON Serialization

1. In the **Solution Explorer**, create the **Helpers** folder and add the *ApplicationBuilderExtensions.cs*, *JsonPopulateObjectHelper.cs* and *JsonSerializationContractResolver.cs* code files.
2. Replace their contents with the code copied from [the corresponding files under this folder](https://github.com/DevExpress/XPO/tree/master/Tutorials/ASP.NET/MVC.Core/CS/Helpers). These files contain the following classes:
    * `JsonPopulateObjectHelper` and `SampleJsonSerializationContractResolver`: implement persistent type JSON serialization and deserialization. Make sure that all your persistent types (`Customer` and `Order` in this example) are passed to the `GetDataStoreSchema` method in the `SampleJsonSerializationContractResolver` constructor.
    * `ApplicationBuilderExtensions` and `SampleJsonMvcBuilderExtensions`: declare the extension methods `UseXpoDemoData` and `AddDxSampleModelJsonOptions` respectively. They call `DemoDataHelper` and `SampleJsonSerializationContractResolver` respectively at the application startup in the next steps.

    <p align="center">
      <img width="400" src="/Tutorials/images/MVC.Core/4.png">
    </p>

For more information, see the following:

  * [Serialization using ContractResolver](https://www.newtonsoft.com/json/help/html/ContractResolver.htm)
  * [XPClassInfo](https://docs.devexpress.com/XPO/DevExpress.Xpo.Metadata.XPClassInfo) | [XPMemberInfo](https://docs.devexpress.com/XPO/DevExpress.Xpo.Metadata.XPMemberInfo)

## Step 5: Configure Database Connection and Plug in the ORM Data Model

1. In *Startup.cs*, modify the `Startup.ConfigureServices` method to configure Dependency Injection services for JSON serialization and database connection with XPO.

    The modified code is as follows:

    ``` csharp
    using AspNetCoreMvcApplication.DataAccess;
    //...
    public void ConfigureServices(IServiceCollection services) {
        // Add framework services.
        services
            .AddControllersWithViews()
            .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null)
        // Added lines begin.
            .AddDxSampleModelJsonOptions();

        services
            .AddXpoDefaultUnitOfWork(true, options => options
                .UseConnectionString(Configuration.GetConnectionString("InMemoryDataStore"))
                .UseThreadSafeDataLayer(true)
                .UseConnectionPool(false) // Remove this line if you use a database server like SQL Server, Oracle, PostgreSql, etc.                    
                .UseAutoCreationOption(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema) // Remove this line if the database already exists
                .UseEntityTypes(typeof(Customer), typeof(Order)) // Pass all of your persistent object types to this method.
            );
        // Added lines end.
    }
    ```

2. In *Startup.cs*, modify the `Startup.Configure` method and add the `app.UseXpoDemoData();` call to create sample data discussed in steps 3 and 4.

    The modified code is as follows:

    ``` csharp
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        if(env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        } else {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
        //Added lines begin.
        app.UseXpoDemoData();
        //Added lines end.
    }
    ```

3. In *appsettings.json*, add the connection string for an in-memory or other [supported database system](https://docs.devexpress.com/XPO/2114/fundamentals/database-systems-supported-by-xpo).

    The modified code is as follows:

    ```json
    {
        "Logging": {
            "LogLevel": {
                "Default": "Information",
                "Microsoft": "Warning",
                "Microsoft.Hosting.Lifetime": "Information"
            }
        },
        "AllowedHosts": "*",

        "ConnectionStrings": {
            "InMemoryDataStore": "XpoProvider=InMemoryDataStore;"
        }
    }
    ```


For more information, see the following:

* [How to create a connection string for XPO providers](https://www.devexpress.com/Support/Center/Question/Details/K18445/how-to-create-a-correct-connection-string-for-xpo-providers)  
* [Unit of Work](https://docs.devexpress.com/XPO/2138/feature-center/connecting-to-a-data-store/unit-of-work)
* [Configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/index?view=aspnetcore-3.0)
* [Dependency injection in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0)
* [ASP.NET Core Dependency Injection in XPO](https://www.devexpress.com/Support/Center/Question/Details/T637597/asp-net-core-dependency-injection-in-xpo)


## Step 6: Manipulate Data in Controllers and Bind it to Views

1. In the **Controllers** folder, add the *CustomerController.cs* and *OrderController.cs* code files.
2. Replace their contents with the code copied from [the corresponding files under this folder](https://github.com/DevExpress/XPO/tree/master/Tutorials/ASP.NET/MVC.Core/CS/Controllers). They contain the *CustomerController* and *OrderController* classes with the `Get`, `Add`, `Update`, and `Delete` API methods that represent [CRUD](https://en.wikipedia.org/wiki/Create,_read,_update_and_delete) operations with the `Customer` and `Order` persistent classes. 

    * The `Get` method accepts the `loadOptions` argument to support the advanced features of [DevExtreme Data Layer](https://js.devexpress.com/Documentation/Guide/Data_Layer/Data_Layer/).
    * The [DataSourceLoader](https://devexpress.github.io/DevExtreme.AspNet.Data/net/api/DevExtreme.AspNet.Data.DataSourceLoader.html) class requires the [IQueryable](https://docs.microsoft.com/en-us/dotnet/api/system.linq.iqueryable?view=netcore-3.0) source to load data from the database using [LINQ to XPO](https://docs.devexpress.com/XPO/4060/feature-center/querying-a-data-store/linq-to-xpo).
    * The `Add` and `Update` methods use the `JsonPopulateObjectHelper` class added in step 4 to populate persistent object properties with the request data. 
    * The following asynchronous XPO methods are used to implement CRUD operations in these controller methods: [Session.GetObjectByKeyAsync](https://docs.devexpress.com/XPO/DevExpress.Xpo.Session.GetObjectByKeyAsync.overloads), [Session.Delete](https://docs.devexpress.com/XPO/DevExpress.Xpo.Session.Delete.overloads), [UnitOfWork.CommitChangesAsync](https://docs.devexpress.com/XPO/DevExpress.Xpo.UnitOfWork.CommitChangesAsync.overloads).

3. Replace the contents of *Views/Home/Index.cshtml* with the code copied from [the corresponding code file](https://github.com/DevExpress/XPO/blob/master/Tutorials/ASP.NET/MVC.Core/CS/Views/Home/Index.cshtml). It declares the *Index* view to display and edit the *Customers* list. 
    * [Razor syntax](https://www.w3schools.com/asp/razor_intro.asp) is used to configure [DevExtreme-based ASP.NET Core controls](https://docs.devexpress.com/AspNetCore/400571/concepts/devextreme-based-controls?v=20.1). 
    * The `DataSource` method is used to [bind data](https://docs.devexpress.com/AspNetCore/400575/concepts/devextreme-based-controls/data-binding?v=20.1) from the aforementioned Controller methods to the [DataGrid](https://js.devexpress.com/Documentation/Guide/Widgets/DataGrid/Overview/) control.
    * The [Popup](https://js.devexpress.com/Demos/Widgetsgallery/Demo/Popup/Overview/jQuery/Light/) control is used to view and edit data in detail forms.


For more information, see the following:

* [Handle requests with controllers in ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/actions?view=aspnetcore-3.0)
* [Views in ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/overview?view=aspnetcore-3.0)
* [DevExtreme-based ASP.NET Core controls | Getting Started](https://docs.devexpress.com/AspNetCore/400572/concepts/devextreme-based-controls/getting-started?v=20.1)
* [FAQ: XPO Async/Await Method Support](https://www.devexpress.com/Support/Center/Question/Details/T683644/faq-xpo-async-await-method-support)
* [Unit of Work](https://docs.devexpress.com/XPO/2138/feature-center/connecting-to-a-data-store/unit-of-work)


## Step 7: Run and Test the App

Press **F5** to build and run the application. The web browser should show the _Customers_ list. You can create, edit or delete customers.

<p align="center">
  <img src="/Tutorials/images/MVC.Core/7.1.png">
</p>

You can also view and edit customer related orders in a separate form.

<p align="center">
  <img src="/Tutorials/images/MVC.Core/7.2.png">
</p>
