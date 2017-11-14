![XPO for .NET Core Logo](https://user-images.githubusercontent.com/5479762/32771815-03632fa0-c935-11e7-9f19-2297bd4cc3f5.png)

# DevExpress XPO for .NET Core / .NET Standard 2.0 Demos

This repository contains demo projects demonstrating how to use [eXpressPersistent Objects™ (XPO)](https://www.devexpress.com/Products/NET/ORM/)  in [\.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) applications. You can use these projects to learn how to use XPO in console, ASP.NET Core or Xamarin applications. All required DevExpress references are included.

## Prerequisites
Download and install [.NET Core 2.0 SDK](https://www.microsoft.com/net/download/core).

## Get the Sources
Clone this repository:
```
git clone https://github.com/DevExpress/XpoNetCoreDemos.git
```
If you do not have [Git](https://git-scm.com/) installed, download and extract the ZIP archive using the GitHub web interface.

## Console Demo
The solution located in the `XpoConsoleCoreDemo` subfolder is a **.NET Standard 2.0** console application, demonstrating how to initialize the data layer and perform basic data operations. To run the application, execute the following commands in the **repository root folder** (XpoNetCoreDemos by default):
```
cd XpoConsoleCoreDemo\XpoConsoleCoreDemo
dotnet restore
dotnet run
```
The project is configured to use a local **SQLite** database. You can modify the code in the *Program.cs* file to configure another database connection (e.g., **MS SQL Server** or [any other supported database](https://documentation.devexpress.com/CoreLibraries/2114/DevExpress-ORM-Tool/Fundamentals/Database-Systems-Supported-by-XPO)).

## ASP.NET Core Demo
The solution located in the `XpoASPNETCoreDemo` subfolder is a **.NET Standard 2.0** console application that displays a simple view with basic operations (*create*, *delete*, *list*). To run the application, execute the following commands in the repository root folder:
```
cd XpoASPNETCoreDemo\DevExpress.Xpo.AspNetCoreDemo
dotnet restore
dotnet run
```
Then, open http://localhost:5000 in your web browser.

The project is configured for a local **SQLite** database. Modify the *Startup.cs* and *appsettings.json* files to configure another database connection (e.g., **MS SQL Server** or [any other supported database](https://documentation.devexpress.com/CoreLibraries/2114/DevExpress-ORM-Tool/Fundamentals/Database-Systems-Supported-by-XPO)).

## Xamarin Demo
The solution located in the `XpoXamarinFormsDemo` subfolder demonstrates the use of XPO in [Xamarin\.Forms](https://www.xamarin.com/forms). It contains the following projects:
 - *DevExpress.Xpo.XamarinFormsDemo.UI* - the common .NET Standard 2.0 project with business logic (data layer initialization, data manipulation) and page layouts;
 - *DevExpress.Xpo.XamarinFormsDemo.Android* - Android app project;
 - *DevExpress.Xpo.XamarinFormsDemo.iOS* - iOS app project;
 - *DevExpress.Xpo.XamarinFormsDemo.UWP* - UWP app project.

To try this demo, open the solution in [Visual Studio 2017 for Windows 15.4.0](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes#15.4) or [Visual Studio 2017 for Mac 7.2.0](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-mac-relnotes) or a newer version. In order to use [.NET Standard 2.0 in UWP](https://blogs.msdn.microsoft.com/dotnet/2017/10/10/announcing-uwp-support-for-net-standard-2-0/), you need to target "Windows 10 Fall Creators Update" as the minimum version of your UWP project.

The demo is configured to use the in-memory data provider with XML storage. Modify the *App.xaml.cs* file in the *DevExpress.Xpo.XamarinFormsDemo.UI* project to configure another database connection (e.g., **SQLite**, **MS SQL Server** or [any other supported database](https://documentation.devexpress.com/CoreLibraries/2114/DevExpress-ORM-Tool/Fundamentals/Database-Systems-Supported-by-XPO)).

## Get Support 
If you have any questions regarding these demo projects, contact us via the [DevExpress Support Center](https://www.devexpress.com/Support/Center/Question/Create).

## Learn More
This tutorial demonstrates how to create an XPO-based .NET Standard 2.0 console application that initializes the data layer and performs basic data operations: [Getting Started with \.NET Core](https://documentation.devexpress.com/CoreLibraries/119377/DevExpress-ORM-Tool/Getting-Started/Getting-Started-with-NET-Core).

## Your feedback is needed!
We would greatly appreciate it if you [participate in this short survey (6 questions, ~3 min)](https://www.devexpress.com/go/XPO_Try_NET_Core_Beta_Survey.aspx).



