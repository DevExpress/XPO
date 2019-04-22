Imports System
Imports System.Web.Mvc
Imports DevExpress.Xpo

Namespace AspNetMvcApplication.Controllers

    Public MustInherit Class BaseController
        Inherits Controller

        Protected ReadOnly UnitOfWork As UnitOfWork
        Public Sub New()
            UnitOfWork = New UnitOfWork(XpoDefault.DataLayer)
        End Sub
        Public Sub SafeExecute(ByVal method As Action)
            Try
                method()
            Catch e As Exception
                ViewData("EditError") = e.Message
            End Try
        End Sub
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            MyBase.Dispose(disposing)
            If disposing Then
                UnitOfWork.Dispose()
            End If
        End Sub
    End Class
End Namespace