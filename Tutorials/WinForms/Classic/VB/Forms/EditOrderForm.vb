Imports System
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB.Exceptions
Imports DevExpress.XtraEditors
Imports WinFormsApplication.XpoTutorial

Partial Public Class EditOrderForm
		Inherits DevExpress.XtraBars.Ribbon.RibbonForm

		Public Sub New()
			InitializeComponent()
		End Sub
		Public Sub New(ByVal orderId? As Integer)
			Me.New()
			Me.OrderID = orderId
		End Sub
		Private privateOrderID? As Integer
		Public Property OrderID() As Integer?
			Get
				Return privateOrderID
			End Get
			Private Set(ByVal value? As Integer)
				privateOrderID = value
			End Set
		End Property
		Private privateUnitOfWork As UnitOfWork
		Protected Property UnitOfWork() As UnitOfWork
			Get
				Return privateUnitOfWork
			End Get
			Private Set(ByVal value As UnitOfWork)
				privateUnitOfWork = value
			End Set
		End Property
		Private Sub EditCustomerForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			Reload()
		End Sub

		Private Sub Reload()
			UnitOfWork = New UnitOfWork()
			If OrderID.HasValue Then
				OrderBindingSource.DataSource = UnitOfWork.GetObjectByKey(Of Order)(OrderID.Value)
			Else
				OrderBindingSource.DataSource = New Order(UnitOfWork)
			End If
			CustomersBindingSource.DataSource = New XPCollection(Of Customer)(UnitOfWork)
		End Sub

		Private Sub btnSave_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSave.ItemClick
			Try
				UnitOfWork.CommitChanges()
				OrderID = DirectCast(OrderBindingSource.DataSource, Order).Oid
				Close()
			Catch e1 As LockingException
				XtraMessageBox.Show(Me, "The record was modified or deleted. Please click the Reload button and try again.", "XPO Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			End Try
		End Sub

		Private Sub btnReload_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnReload.ItemClick
			Reload()
		End Sub

		Private Sub btnClose_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClose.ItemClick
			Close()
		End Sub
	End Class
