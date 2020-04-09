Imports System
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports XpoTutorial

Namespace WinFormsApplication
	Friend Module Program
		<STAThread>
		Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			ConnectionHelper.Connect()
			Using uow As New UnitOfWork()
				DemoDataHelper.Seed(uow)
			End Using
			Application.Run(New MainView())
		End Sub
	End Module
End Namespace
