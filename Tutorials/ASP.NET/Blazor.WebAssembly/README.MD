## Overview

This tutorial explains how to create a client-side Blazor application that uses the DevExpress ORM Library (XPO) to access and manage data. In this tutorial, we use an [intermediate Web API service](Tutorials/ASP.NET/WebApi) to communicate with the database.

<p align="center">
  <img width="562" src="/Tutorials/images/Blazor.ClientSide/1.1.png">
</p>
<p align="center">
  <img width="800" src="/Tutorials/images/Blazor.ClientSide/1.2.png">
</p>

## Prerequisites

* [Visual Studio 2019 16.4.5 or later](https://visualstudio.com/) with the following workloads:
  * **ASP.NET and web development**
  * **.NET Core cross-platform development**
* [.NET Core 5.0 SDK or later](https://www.microsoft.com/net/download/all)
* [DevExpress UI Components for Blazor](https://www.devexpress.com/blazor/)

This app uses the [WebAssembly hosting model](https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-5.0#blazor-webassembly).

## Step 1: Create a Blazor (Server-Side) Web App

1. Open Visual Studio and create a new project.
2. Find and select the **Blazor App** template. Click **Next** to proceed.
3. Specify the project name and click **Create**.
4. Select **.NET 5.0** and **Blazor WebAssembly App** and click **Create**.

## Step 2: Add the XPO Package

Use any of the following approaches to install the XPO package:

**Package Manager Console**

  * From Visual Studio's **Tools** menu, select **NuGet Package Manager > Package Manager Console**.
  * Make sure **Package source** is set to **All**, **nuget.org** or **DevExpress 20.2 Local** and run the following command: 
     ```console
    Install-Package DevExpress.Xpo -Version 20.2
    ```

**NuGet Package Manager**

  * In the **Solution Explorer**, right-click the project name and select **Manage NuGet Packages**.
  * Make sure **Package source** is set to **All**, **nuget.org** or **DevExpress 20.2 Local** on the right.
  * In the top left corner under **Browse**, search for the `DevExpress.Xpo` package and select the latest version (v20.2) on the right.
  * Click **Install** and accept all licenses in the **License Acceptance** dialogs. 

See also:

  * https://www.nuget.org/
  * https://nuget.devexpress.com/

## Step 3: Create ORM Data Model

If you want to let XPO create a new database for you, refer to the following help for instructions how to accomplish this task: [Create a Data Model](https://docs.devexpress.com/XPO/401951/create-a-data-model).

If you want to connect your application to an existing database, use the [Data Model Wizard](https://docs.devexpress.com/XPO/14810/design-time-features/data-model-wizard) to generate XPO classes.

See also:

  * [Object Relational Mapping](https://docs.devexpress.com/XPO/2017/feature-center/object-relational-mapping)
  * [Persisting Objects](https://docs.devexpress.com/XPO/2025/feature-center/data-exchange-and-manipulation/persisting-objects)

## Step 5: Configure Database Connection

1. If you created an ASP.NET Core hosted application, configure the database connection and add controllers in the service project as described here: [How to create an ASP.NET Core Web API Data Store service](/Tutorials/ASP.NET/WebApi/). Otherwise, add [WebApiApplication](/Tutorials/ASP.NET/WebApi/CS) project to your solution and modify the connection settings in the Startup.cs file.
2. In the client app, open the Program.cs file and add the following code to the Main method:
    ```csharp
    builder.Services.AddXpoDefaultUnitOfWork(true, options =>
      options.UseConnectionString(WebApiDataStoreClient.GetConnectionString("https://localhost:44307/xpo/"))
      .UseConnectionPool(false)
      .UseThreadSafeDataLayer(false)
      .UseEntityTypes(typeof(Customer), typeof(Order)));
    ```

See also:
[ASP.NET Core Dependency Injection in XPO](https://supportcenter.devexpress.com/ticket/details/t637597)

## Step 6: Add views and implement data access methods

1. Use the @inject directive to add [UnitOfWork](https://docs.devexpress.com/XPO/DevExpress.Xpo.UnitOfWork) to a view.
2. Use [LINQ to XPO](https://docs.devexpress.com/XPO/4060/query-and-shape-data/linq-to-xpo) to build a data query.
3. Use the [ToListAsync](https://docs.devexpress.com/XPO/DevExpress.Xpo.XPQueryExtensions.ToListAsync--1(System.Linq.IQueryable---0--System.Threading.CancellationToken)) extension method to execute a query.
4. Use the [UnitOfWork.GetObjectByKeyAsync](https://docs.devexpress.com/XPO/DevExpress.Xpo.Session.GetObjectByKeyAsync.overloads) method to retrieve a single object.
5. Use the [UnitOfWork.CommitChangesAsync](https://docs.devexpress.com/XPO/DevExpress.Xpo.UnitOfWork.CommitChangesAsync.overloads) method to save changes.

For information about implementation, refer to the files in the following folder: [Blazor.Client/Pages](/Tutorials/ASP.NET/Blazor.Client/CS/Pages).

In this example, we used [DevExpress UI components for Blazor](https://demos.devexpress.com/blazor/). Refer to the following help topic for additional information: [Get Started > Create an Application](https://docs.devexpress.com/Blazor/401057/getting-started/create-an-application).
