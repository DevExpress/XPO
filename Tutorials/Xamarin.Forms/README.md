## Overview

This tutorial demonstrates how to create a Xamarin mobile application for iOS and Android. The application uses the [DevExpress ORM Library (XPO)](https://www.devexpress.com/products/net/orm/) to access and manage data and stores data in an SQLite database. 

<p align="center">
  <img width="540" src="/Tutorials/images/Xamarin.Forms/8.1.png">
</p>

<p align="center">
  <img width="540" src="/Tutorials/images/Xamarin.Forms/8.2.png">
</p>

## Prerequisites

* [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) with the **Mobile development with .NET** workload.
* (Optional) A paired Mac to build the application on iOS.

## Step 1: Create a Mobile App

1. Open Visual Studio and create a new project.
2. Search for the **Mobile App (Xamarin Forms)** template. 

    ![](/Tutorials/images/Xamarin.Forms/1.1.png)

    Click **Next** to proceed.

3. Set the project name to **XamarinFormsDemo** and click **Create**.

    ![](/Tutorials/images/Xamarin.Forms/1.2.png)

4. Select the **Master-Detail** application template and click **OK**.

    ![](/Tutorials/images/Xamarin.Forms/1.3.png)

5. In the **Solution Explorer**, remove the unnecessary files:

    * *Models\HomeMenuItem.cs*
    * *Services\MockDataStore.cs*
    * *Views\MenuPage.xaml*

    ![](/Tutorials/images/Xamarin.Forms/1.4.png) 

For more information, see the following:

- [Build your first Xamarin.Forms App](https://docs.microsoft.com/en-us/xamarin/get-started/first-app/)
- [Xamarin.Forms - Quick Starts](https://docs.microsoft.com/en-us/xamarin/get-started/quickstarts/)



## Step 2: Add the NuGet Packages

The application you build in this tutorial requires the following NuGet Packages:

- DevExpress.Xpo
- Microsoft.Data.Sqlite

From the Visual Studio **Tools** menu, select **NuGet Package Manager > Package Manager Console**.

Make sure **Package source** is set to **All** or **nuget.org** and run the following commands: 

```console
Install-Package DevExpress.Xpo
```


```console
Install-Package Microsoft.Data.Sqlite
```

## Step 3: Create ORM Data Model and Seed Initial Data

1. Change the project's _Item_ class (the _"/Models/Item.cs"_ file) as follows:

    ```cs
    using DevExpress.Xpo;

    namespace XamarinFormsDemo.Models {
        [Persistent]
        public class Item {
            [Key]
            public string Id { get; set; }
            [Size(256)]
            public string Text { get; set; }
            [Size(SizeAttribute.Unlimited)]
            public string Description { get; set; }
        }
    }
    ```


2. In the **Solution Explorer**, create the **Core** folder and add the *XpoHelper.cs* code file. 

    Replace its content with the code copied from the [corresponding file](https://github.com/DevExpress/XPO/tree/master/Tutorials/Xamarin.Forms/XamarinFormsDemo/Core/XpoHelper.cs). This file contains the `XpoHelper` class.
    
    The `XpoHelper` class creates and saves initial data in the database. 

    ![](/Tutorials/images/Xamarin.Forms/3.2.png) 

For more information, see the following:

* [Add Persistence to an Existing Hierarchy](https://docs.devexpress.com/XPO/2108/fundamentals/adding-persistence-to-an-existing-hierarchy)
* [Object Relational Mapping](https://docs.devexpress.com/XPO/2017/feature-center/object-relational-mapping)
* [Persisting Objects](https://docs.devexpress.com/XPO/2025/feature-center/data-exchange-and-manipulation/persisting-objects)


## Step 4: Implement CRUD Operations and Connect App to SQLite

1. In the **Solution Explorer**, select the **Services** folder and add the *XpoDataStore.cs* code file. Replace the code with the code from the [corresponding file](https://github.com/DevExpress/XPO/tree/master/Tutorials/Xamarin.Forms/XamarinFormsDemo/Services/XpoDataStore.cs).

    The `XpoDataStore` class implements the `IDataStore` interface declared in the *IDataStore.cs* file.

    ![](/Tutorials/images/Xamarin.Forms/4.1.png) 

    The following asynchronous XPO methods are used to implement CRUD operations in the `XpoDataStore` class: [Session.GetObjectByKeyAsync](https://docs.devexpress.com/XPO/DevExpress.Xpo.Session.GetObjectByKeyAsync.overloads), [Session.Delete](https://docs.devexpress.com/XPO/DevExpress.Xpo.Session.Delete.overloads), [UnitOfWork.CommitChangesAsync](https://docs.devexpress.com/XPO/DevExpress.Xpo.UnitOfWork.CommitChangesAsync.overloads).

2. Open the *App.xaml.cs* file and replace its content with the code copied from the [corresponding file](https://github.com/DevExpress/XPO/tree/master/Tutorials/Xamarin.Forms/XamarinFormsDemo/App.xaml.cs).

    The `App()` constructor's does the following:

    - specifies the path to the local application data where the SQLite data file must be stored
    - initializes XPO using the `XpoInit` method implemented in step 3
    - specifies the initially loaded application View.

3. **iOS-specific step.** In the **XamarinFormsDemo.iOS** project, replace the *Main.cs* file content with the code copied from the [corresponding file](https://github.com/DevExpress/XPO/tree/master/Tutorials/Xamarin.Forms/XamarinFormsDemo.iOS/Main.cs).


For more information, see the following:

* [How to: Connect to a Data Store](https://docs.devexpress.com/XPO/2123/concepts/how-to-connect-to-a-data-store)
* [FAQ: XPO Async/Await Method Support](https://www.devexpress.com/Support/Center/Question/Details/T683644/faq-xpo-async-await-method-support)
* [Unit of Work](https://docs.devexpress.com/XPO/2138/feature-center/connecting-to-a-data-store/unit-of-work)

## Step 5: Modify View Models

1. In the `BaseViewModel` ("*/ViewModels/BaseViewModel.cs*"), change the `DataStore` property declaration as follows:

    ```cs
    namespace XamarinFormsDemo.ViewModels {
        public class BaseViewModel : INotifyPropertyChanged {
            // change line
            public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new XpoDataStore();
            // change line end
        // ...
        }
    }
    ```

2. Open the *ItemsViewModel.cs* file and replace its content with the code copied from the [corresponding file](https://github.com/DevExpress/XPO/tree/master/Tutorials/Xamarin.Forms/XamarinFormsDemo/ViewModels/ItemsViewModel.cs). This ViewModel passes the View's CRUD commands (see step 6) to the data store and returns the result back to the View.

## Step 6: Modify Views

Open the *Views* folder in the Solution Explorer and replace the following files with the corresponding files from [this folder](https://github.com/DevExpress/XPO/tree/master/Tutorials/Xamarin.Forms/XamarinFormsDemo/Views/):

- *ItemDetailPage.xaml*
- *ItemDetailPage.xaml.cs*
- *ItemsPage.xaml*
- *ItemsPage.xaml.cs*
- *NewItemPage.xaml*
- *NewItemsPage.xaml.cs*
- *MainPage.xaml* 
- *MainPage.xaml.cs*

## Step 7: Run and Test the App

Press **F5** to build and run the application.

<p align="center">
  <img width="540" src="/Tutorials/images/Xamarin.Forms/8.1.png">
</p>


You can add new items in a separate form.

<p align="center">
  <img width="540" src="/Tutorials/images/Xamarin.Forms/8.2.png">
</p>

> In Release mode, Xamarin iOS and Android apps that use XPO for data access can crash with `TypeLoadException` or `MissingMethodException` if you build with certain linker options. Refer to the following article to resolve this issue:
> 
> [XPO - Recommended Xamarin Linker Options](https://supportcenter.devexpress.com/ticket/details/t885132)
