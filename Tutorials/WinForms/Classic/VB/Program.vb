Imports DevExpress.Xpo
Imports System
Imports System.Configuration
Imports System.Windows.Forms
Imports XpoTutorial

Namespace WinFormsApplication
	Friend Module Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			ConnectionHelper.Connect()
			Using uow As New UnitOfWork()
				DemoDataHelper.Seed(uow)
			End Using
			Application.Run(New MainForm())
		End Sub
	End Module
End Namespace
