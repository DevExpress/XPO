## Overview

This tutorial explains how to create an ASP.NET Core Web API service that supports the [WebApiDataStoreClient](http://docs.devexpress.com/XPO/DevExpress.Xpo.DB.WebApiDataStoreClient) provider. For additional information about WebApiDataStoreClient, refer to the following help topic: [Transfer Data via REST API](http://docs.devexpress.com/XPO/402182/connect-to-a-data-store/transfer-data-via-rest-api).

## Prerequisites

* [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) with the following workloads:
  * **ASP.NET and web development**
  * **.NET Core cross-platform development**
* [.NET Core SDK 5.0 or later](https://www.microsoft.com/net/download/all)

## Step 1: Create an ASP.NET Core Web Api project

1. Open Visual Studio and create a new project.

2. Select the **ASP.NET Core Web Application** template and click **Next**.

3. Set the project name and click **Create**.

4. Select **ASP.NET Core 5.0** and **API** and click Create.

See also:

  * [Create web APIs with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/web-api)
  
## Step 2: Add the DevExpress XPO Package

Use any of the following approaches to install the XPO package:

**Package Manager Console**

* From the Visual Studio **Tools** menu, select **NuGet Package Manager > Package Manager Console**.
* Make sure **Package source** is set to **All**, **nuget.org** or **DevExpress 20.1 Local** and run the following command: 
    ```console
  Install-Package DevExpress.Xpo
  ```

**NuGet Package Manager**

* In the **Solution Explorer**, right-click the project name and select **Manage NuGet Packages**.
* Make sure **Package source** is set to **All**, **nuget.org** or **DevExpress 20.1 Local** on the right.
* In the left top corner under **Browse**, search for the `DevExpress.Xpo` package and select the latest version on the right.
* Click **Install** on the right and accept all the licenses in the **License Acceptance** dialogs.    

See also:

  * https://www.nuget.org/
  * https://nuget.devexpress.com/

## Step 3: Register DevExpress.Xpo.DB.WebApiDataStoreService

1. Open the *apsettings.json* file and add a connection string to a root element.
   ```json
    {
        ...
        "ConnectionStrings": {
            "YourConnectionStringName": "data source=(localdb)\mssqllocaldb;initial catalog=DxSample;user id=sa;password=dx"
        } 
    }
    ```
2. Open the *Startup.cs* file and add the following code to the **ConfigureServices** method.
    ```cs
    string connectionString = Configuration.GetConnectionString("YourConnectionStringName");
    IDataStore dataStore = XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.SchemaAlreadyExists);
    WebApiDataStoreService service = new WebApiDataStoreService(dataStore);
    services.AddSingleton(service);
    ```
3. Add XML formatters, because WebApiDataStoreClient sends data in the XML format.
    ```cs
    services.AddMvc().AddXmlSerializerFormatters();
    ```
3. Add the CORS policy to allow access from a different origin. You can add multiple origins. For each origin, enable the POST method and "Content-Type" header.
    ```cs
    services.AddCors(options =>
        options.AddPolicy("XPO", builder =>
            builder.WithOrigins("https://localhost:44317")
                .WithMethods("POST")
                .WithHeaders("Content-Type")));
    ```

## Step 4: Add a Web API controller

1. In the **Solution Explorer**, select the **Controllers** folder and create the *XpoController.cs* file.
2. Declare the XpoController class inherited from [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase).
3. Add the [ApiController](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.apicontrollerattribute) and [Route](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.routeattribute) attributes to the XpoController class.
    ```cs
    [ApiController]
    [Route("[controller]/[action]")]
    public class XpoController : ControllerBase {
    ```
4. Add a constructor with a parameter of the [WebApiDataStoreService](http://docs.devexpress.com/XPO/DevExpress.Xpo.DB.WebApiDataStoreService) type.
    ```cs
    readonly WebApiDataStoreService DataStoreService;
    public XpoController(WebApiDataStoreService dataStoreService) {
        this.DataStoreService = dataStoreService;
    }
    ```
5. Add the **UpdateSchema**, **SelectData**, and **ModifyData** methods decorated with the [HttpPost](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.httppostattribute) attribute.
    ```cs
    [HttpPost]
    [EnableCors("XPO")]
    public Task<OperationResult<UpdateSchemaResult>> UpdateSchema([FromQuery] bool doNotCreateIfFirstTableNotExist, [FromBody] DBTable[] tables) {
        return DataStoreService.UpdateSchemaAsync(doNotCreateIfFirstTableNotExist, tables);
    }
    [HttpPost]
    [EnableCors("XPO")]
    public Task<OperationResult<SelectedData>> SelectData([FromBody] SelectStatement[] selects) {
        return DataStoreService.SelectDataAsync(selects);
    }
    [HttpPost]
    [EnableCors("XPO")]
    public Task<OperationResult<ModificationResult>> ModifyData([FromBody] ModificationStatement[] dmlStatements) {
        return DataStoreService.ModifyDataAsync(dmlStatements);
    }
    ```
You can find the complete code in the following file: [XpoController.cs](https://github.com/DevExpress/XPO/blob/master/Tutorials/ASP.NET/WebApi/CS/Controllers/XpoController.cs).

See also:
[Transfer Data via REST API](https://docs.devexpress.com/XPO/402182/connect-to-a-data-store/transfer-data-via-rest-api)
[How to Implement OData v4 Service with XPO (.NET Core 3.1)](https://github.com/DevExpress-Examples/XPO_how-to-implement-odata4-service-with-xpo-netcore)   
