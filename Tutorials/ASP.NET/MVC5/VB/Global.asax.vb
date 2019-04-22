Imports DevExpress.Web.Mvc
Imports DevExpress.Xpo
Imports System
Imports System.Web.Mvc
Imports System.Web.Routing
Imports XpoTutorial

Namespace AspNetMvcApplication
    ' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    ' visit http://go.microsoft.com/?LinkId=9394801

    Public Class MvcApplication
        Inherits System.Web.HttpApplication

        Protected Sub Application_Start()
            AreaRegistration.RegisterAllAreas()

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
            RouteConfig.RegisterRoutes(RouteTable.Routes)

            ModelBinders.Binders.DefaultBinder = New DevExpressEditorsBinder()

            ConnectionHelper.Connect()
            Using uow As New UnitOfWork()
                DemoDataHelper.Seed(uow)
            End Using

            AddHandler DevExpress.Web.ASPxWebControl.CallbackError, AddressOf Application_Error
        End Sub

        Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
            Dim exception As Exception = System.Web.HttpContext.Current.Server.GetLastError()
            'TODO: Handle Exception
        End Sub
    End Class
End Namespace