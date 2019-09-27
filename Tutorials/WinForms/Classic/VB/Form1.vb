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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim session As New Session
        CustomersBindingSource.DataSource = New XPCollection(Of Customer)(session)
    End Sub
End Class
