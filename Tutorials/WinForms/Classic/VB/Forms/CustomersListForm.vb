Imports DevExpress.Xpo
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Grid
Imports WinFormsApplication.XpoTutorial

Public Class CustomersListForm
    Public Sub New()
        ConnectionHelper.Connect(False)
        Using uow As New UnitOfWork()
            DemoDataHelper.Seed(uow)
        End Using
        InitializeComponent()
    End Sub
    Private fSession As Session
    Protected ReadOnly Property Session() As Session
        Get
            Return fSession
        End Get
    End Property
    Private Sub CustomersListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Reload()
    End Sub

    Private Sub Reload()
        fSession = New Session
        CustomersBindingSource.DataSource = New XPCollection(Of Customer)(Session)
    End Sub

    Private Sub CustomersGridView_RowClick(sender As Object, e As RowClickEventArgs) Handles CustomersGridView.RowClick
        If e.Clicks = 2 Then
            e.Handled = True
            Dim customerId As Integer = CType(CustomersGridView.GetRowCellValue(e.RowHandle, colOid), Integer)
            ShowEditForm(customerId)
        End If
    End Sub

    Private Sub ShowEditForm(customerId As Nullable(Of Integer))
        Using form As New EditCustomerForm(customerId)
            form.ShowDialog(Me)
            If form.CustomerID.HasValue Then
                Reload()
                CustomersGridView.FocusedRowHandle = CustomersGridView.LocateByValue("Oid", form.CustomerID.Value)
            End If
        End Using
    End Sub

    Private Sub BtnNew_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnNew.ItemClick
        ShowEditForm(Nothing)
    End Sub

    Private Sub BtnDelete_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnDelete.ItemClick
        Dim focusedObject As Object = CustomersGridView.GetFocusedRow()
        Session.Delete(focusedObject)
    End Sub
End Class
