Imports DevExpress.Xpo
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Grid
Imports WinFormsApplication.XpoTutorial

Public Class OrdersListForm
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub CustomersListForm_Load(sender As Object, e As EventArgs)
        Reload()
    End Sub

    Private Sub Reload()
        OrdersInstantFeedbackView.Refresh()
    End Sub

    Private Sub CustomersGridView_RowClick(sender As Object, e As RowClickEventArgs) Handles OrdersGridView.RowClick
        If e.Clicks = 2 Then
            e.Handled = True
            Dim customerId As Integer = CType(OrdersGridView.GetRowCellValue(e.RowHandle, colOid), Integer)
            ShowEditForm(customerId)
        End If
    End Sub

    Private Sub ShowEditForm(orderId As Nullable(Of Integer))
        Using form As New EditOrderForm(orderId)
            form.ShowDialog(Me)
            If form.OrderID.HasValue Then
                Reload()
                OrdersGridView.FocusedRowHandle = OrdersGridView.LocateByValue("Oid", form.OrderID.Value,
                                                                           Sub(ByVal rowHandle) OrdersGridView.FocusedRowHandle = CInt(rowHandle))
            End If
        End Using
    End Sub
    Private Sub BtnNew_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnNew.ItemClick
        ShowEditForm(Nothing)
    End Sub

    Private Sub BtnDelete_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnDelete.ItemClick
        Using session As New Session
            Dim orderId As Object = OrdersGridView.GetFocusedRowCellValue(colOid)
            Dim order As Order = session.GetObjectByKey(Of Order)(orderId)
            session.Delete(order)
        End Using
        Reload()
    End Sub

    Private Sub OrdersInstantFeedbackView_ResolveSession(sender As Object, e As ResolveSessionEventArgs) Handles OrdersInstantFeedbackView.ResolveSession
        e.Session = New Session
    End Sub

    Private Sub OrdersInstantFeedbackView_DismissSession(sender As Object, e As ResolveSessionEventArgs) Handles OrdersInstantFeedbackView.DismissSession
        e.Session.Session.Dispose()
    End Sub
End Class
