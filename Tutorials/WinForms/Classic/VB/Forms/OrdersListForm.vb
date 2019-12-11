Imports DevExpress.Xpo
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraGrid.Views.Grid
Imports WinFormsApplication.XpoTutorial

Partial Public Class OrdersListForm
		Inherits RibbonForm

		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub OrdersGridView_RowClick(ByVal sender As Object, ByVal e As RowClickEventArgs) Handles OrdersGridView.RowClick
			If e.Clicks = 2 Then
				e.Handled = True
				Dim orderID As Integer = DirectCast(OrdersGridView.GetRowCellValue(e.RowHandle, colOid), Integer)
				ShowEditForm(orderID)
			End If
		End Sub

		Private Sub ShowEditForm(ByVal orderID? As Integer)
			Dim form = New EditOrderForm(orderID)
			AddHandler form.FormClosed, Sub(s, e)
				If form.OrderID.HasValue Then
					Reload()
					OrdersGridView.FocusedRowHandle = OrdersGridView.LocateByValue("Oid", form.OrderID.Value, Sub(rowHandle) OrdersGridView.FocusedRowHandle = CInt(Math.Truncate(rowHandle)))
				End If
			End Sub
			Dim documentManager = DevExpress.XtraBars.Docking2010.DocumentManager.FromControl(MdiParent)
			If documentManager IsNot Nothing Then
				documentManager.View.AddDocument(form)
			Else
				Try
					form.ShowDialog()
				Finally
					form.Dispose()
				End Try
			End If
		End Sub
		Private Sub Reload()
			OrdersInstantFeedbackView.Refresh()
		End Sub

		Private Sub BtnNew_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles btnNew.ItemClick
			ShowEditForm(Nothing)
		End Sub

		Private Sub BtnDelete_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles btnDelete.ItemClick
			Using session As New Session()
				Dim orderId As Object = OrdersGridView.GetFocusedRowCellValue(colOid)
				Dim order As Order = session.GetObjectByKey(Of Order)(orderId)
				session.Delete(order)
			End Using
			Reload()
		End Sub

		Private Sub OrdersInstantFeedbackView_ResolveSession(ByVal sender As Object, ByVal e As ResolveSessionEventArgs) Handles OrdersInstantFeedbackView.ResolveSession
			e.Session = New Session()
		End Sub

		Private Sub OrdersInstantFeedbackView_DismissSession(ByVal sender As Object, ByVal e As ResolveSessionEventArgs) Handles OrdersInstantFeedbackView.DismissSession
			e.Session.Session.Dispose()
		End Sub
	End Class
