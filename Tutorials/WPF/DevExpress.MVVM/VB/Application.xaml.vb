Imports DevExpress.Xpf.Core
Imports DevExpress.Xpo
Imports System
Imports System.Windows
Imports System.Windows.Threading
Imports XpoTutorial

Namespace WpfApplicationMvvm
	Partial Public Class App
		Inherits Application

		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
			MyBase.OnStartup(e)
			ConnectionHelper.Connect()
			Using uow As New UnitOfWork()
				DemoDataHelper.Seed(uow)
			End Using
		End Sub
		Private Sub Application_DispatcherUnhandledException(ByVal sender As Object, ByVal e As DispatcherUnhandledExceptionEventArgs)
			e.Handled = True
			Dim exception As Exception = UnwrapException(e.Exception)
			DXMessageBox.Show(MainWindow, exception.Message, "XPO Tutorial - Error", MessageBoxButton.OK, MessageBoxImage.Error)
		End Sub
		Private Function UnwrapException(ByVal exception As Exception) As Exception
			If exception.InnerException Is Nothing Then
				Return exception
			Else
				Return UnwrapException(exception.InnerException)
			End If
		End Function
	End Class
End Namespace
