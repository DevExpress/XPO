Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata
Imports System.Configuration
Imports System.Windows
Imports XpoTutorial

Namespace WpfApplication
	''' <summary>
	''' Interaction logic for App.xaml
	''' </summary>
	Partial Public Class App
		Inherits Application

		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
			MyBase.OnStartup(e)
			ConnectionHelper.Connect()
			Using uow As New UnitOfWork(XpoDefault.DataLayer)
				DemoDataHelper.Seed(uow)
			End Using
		End Sub
	End Class
End Namespace
