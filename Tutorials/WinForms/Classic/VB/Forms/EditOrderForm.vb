Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB.Exceptions
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraEditors
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Linq
Imports System.Collections
Imports XpoTutorial

Namespace WinFormsApplication.Forms
	Partial Public Class EditOrderForm
		Inherits RibbonForm

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Session As UnitOfWork
		Public Property OrderId() As Integer?

		Private Async Sub EditOrderForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
			Await Reload()
		End Sub

		Private Async Function Reload() As Task
			DisableButtons()
			Try
				If Session IsNot Nothing Then
					RemoveHandler Session.ObjectChanged, AddressOf Session_ObjectChanged
				End If
				Session = New UnitOfWork()
				AddHandler Session.ObjectChanged, AddressOf Session_ObjectChanged
				OrdersBindingSource.DataSource = If(OrderId.HasValue, Await Session.GetObjectByKeyAsync(Of Order)(OrderId.Value), New Order(Session))
				CustomerEditor.Properties.DataSource = Await Session.Query(Of Customer)().Select(Function(c) New With {
					Key c.Oid,
					Key c.ContactName
				}).ToListAsync()
			Finally
				EnableButtons()
			End Try
		End Function

		Private Sub Session_ObjectChanged(ByVal sender As Object, ByVal e As ObjectChangeEventArgs)
			If e.Reason = ObjectChangeReason.PropertyChanged Then
				btnSave.Enabled = True
			End If
		End Sub

		Private Async Sub btnSave_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles btnSave.ItemClick
			DisableButtons()
			Try
				Await Session.CommitChangesAsync()
				Dim order As Order = DirectCast(OrdersBindingSource.DataSource, Order)
				OrderId = order.Oid ' a new object gets Oid from the database
				Close()
			Catch e1 As LockingException
				XtraMessageBox.Show("XPO Tutorial", "The record was modified by another user. Please refresh data.", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Finally
				EnableButtons()
			End Try
		End Sub

		Private Sub btnClose_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles btnClose.ItemClick
			Close()
		End Sub

		Private Async Sub btnRefresh_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles btnRefresh.ItemClick
			Await Reload()
		End Sub

		Private Sub EnableButtons()
			Dim objectsToSave As ICollection = Session.GetObjectsToSave()
			btnSave.Enabled = objectsToSave.Count > 0
			btnRefresh.Enabled = True
		End Sub

		Private Sub DisableButtons()
			btnSave.Enabled = False
			btnRefresh.Enabled = False
		End Sub
	End Class
End Namespace
