##Prerequisites

1. Make sure that you have Visual Studio 2015+ with the latest updates. The instructions will be demonstrated using Visual Studio 2019.
2. Install ASP.NET Core 2.0+.
3. Download the Unified Installer for .NET and HTML5 Developers from https://www.devexpress.com/Products/Try/ and run it. For simplicity, we recommend that you select all the products for installation. It will register Nuget package sources, XPO, DevExtreme and other item and project templates required for these tutorials. You can uninstal not required products later.

##Step 1

Open Visual Studio 2019 and create a new project. Search for the "DevExtreme 19.1 ASP.NET Core Application (.NET Core)" template. 
<1>

##Step 2

Click Next, set the project name to "AspNetCoreMvcApplication" and click Create.
<2>

##Step 3

Remove the following files from the created project:
- Controllers\OrdersController.cs
- Models\Order.cs
- Models\SampleData.cs
<3 - redo>
  
##Step 4

Manage Nuget packages for the project.
<4>
Make sure that the Package source is set to "DevExpress v19.1 Local" or "nuget.org" and search for the "DevExpress.Xpo" package under the Browse tab. 
<4.1>
Install the latest v19.1 of the DevExpress.Xpo package and access all the licenses in the License Acceptance dialogs. For more information on Nuget, refer to https://nuget.devexpress.com/ or https://www.nuget.org/.

##Step 5

Create the "DataAccess" folder and add the Customer.cs, Order.cs and DemoDataHelper.cs code files. To provide their content, copy and paste the code from the corresponding code files [under this shared folder](https://github.com/DevExpress/XPO/tree/39dd7df7311933908627e55f4cf2fd7f769bdcfd/Tutorials/WinForms/Classic/CS/DataAccess).
This will form your persistent data model and also seed sample data in the database. For more information, refer to the [Object Relational Mapping](https://docs.devexpress.com/XPO/2017/feature-center/object-relational-mapping) and [Persisting Objects](https://docs.devexpress.com/XPO/2025/feature-center/data-exchange-and-manipulation/persisting-objects) articles in the online documentation.

##Step 6

Create the "Helpers" folder and add the ApplicationBuilderExtensions.cs, JsonPopulateObjectHelper.cs and JsonSerializationContractResolver.cs code files.
To provide their content, copy and paste the code from the corresponding code files [under this folder](https://github.com/DevExpress/XPO/tree/master/Tutorials/ASP.NET/MVC.Core/CS/Helpers).
These files surve the following purposes:
 - ApplicationBuilderExtensions.cs: registers the DemoDataHelper class created on the previous step.
 - JsonPopulateObjectHelper.cs and JsonSerializationContractResolver.cs: provide persistent type JSON serialization and deserialization.
Make sure that all your persistent types (Customer and Order in this example) are passed to the "GetDataStoreSchema" method in the SampleJsonSerializationContractResolver constructor. 


This step can be simplified when these APIs become a part of XPO.

##Step 7

In Startup.cs, modify the Startup.ConfigureServices method to configure Dependency Injection services. 
Here is the modified code:

```
public void ConfigureServices(IServiceCollection services)
{
    // Add framework services.
    services
        .AddMvc()
        .AddDxSampleModelJsonOptions();
    services
        .AddXpoDefaultUnitOfWork(true, options => options
            .UseConnectionString(Configuration.GetConnectionString("ImMemoryDataStore"))
            .UseThreadSafeDataLayer(true)
            .UseConnectionPool(false) // Remove this line if you use a network database like MSSQL, Oracle, PostgreSql etc.                    
            .UseAutoCreationOption(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema) // Remove this line if the database already exists.
            .UseEntityTypes(typeof(Customer), typeof(Order)) // Pass all of your persistent object types to this method.
        );

}
```

In the end of the Startup.Configure method, add the "app.UseXpoDemoData();" method call to create sample data at the application startup. 
Here is the modified code:
```
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseBrowserLink();
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
    }

    app.UseStaticFiles();

    app.UseMvc(routes =>
    {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
    });
    app.UseXpoDemoData();
}
```

##Step 8

In the appsettings.json file, add the connection string for an in-memory database.
Here is the modified code:

```
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
You can modify this connection string to point to other [supported databases](http://newdoc.devexpress.devx/XPO/2114/fundamentals/database-systems-supported-by-xpo?v=19.1&b=platform-specific-table&p=netstandard). For more information, refer to the [How to create a correct connection string for XPO providers](https://www.devexpress.com/Support/Center/Question/Details/K18445/how-to-create-a-correct-connection-string-for-xpo-providers) and [Configuration in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2) articles.

##Step 9

In the Controllers folder, add the CustomerController.cs and OrderController.cs code files.
To provide their content, copy and paste the code from the corresponding code files [under this folder](https://github.com/DevExpress/XPO/tree/master/Tutorials/ASP.NET/MVC.Core/CS/Controllers).
In the Views/Home/Index.cshtml file, copy and paste the content [from this file](https://github.com/DevExpress/XPO/blob/master/Tutorials/ASP.NET/MVC.Core/CS/Views/Home/Index.cshtml).

These files surve the following purposes:
 - CustomerController.cs and OrderController.cs: provide API Controllers for CRUD operations with Customer and Order persistent classes.
 - Index.cshtml: provides the Index view to display and edit the Customers list.

##Step 10
Build and run the application. It should show the Customers list.
<10>
