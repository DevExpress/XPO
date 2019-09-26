Imports DevExpress.Xpo
Imports WinFormsApplication.XpoTutorial

Public Class Form1
    Public Sub New()
        ConnectionHelper.Connect(False)
        Using uow As New UnitOfWork()
            DemoDataHelper.Seed(uow)
        End Using
        InitializeComponent()
    End Sub
End Class
