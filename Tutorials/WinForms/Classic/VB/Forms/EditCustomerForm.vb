Imports System
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB.Exceptions
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraEditors
Imports WinFormsApplication.XpoTutorial

Partial Public Class EditCustomerForm
		Inherits DevExpress.XtraBars.Ribbon.RibbonForm

		Public Sub New()
			InitializeComponent()
		End Sub
		Public Sub New(ByVal customerId? As Integer)
			Me.New()
			Me.CustomerID = customerId
		End Sub

		Private privateCustomerID? As Integer
		Public Property CustomerID() As Integer?
			Get
				Return privateCustomerID
			End Get
			Private Set(ByVal value? As Integer)
				privateCustomerID = value
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
			If CustomerID.HasValue Then
				CustomerBindingSource.DataSource = UnitOfWork.GetObjectByKey(Of Customer)(CustomerID.Value)
			Else
				CustomerBindingSource.DataSource = New Customer(UnitOfWork)
			End If
		End Sub

		Private Sub btnSave_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSave.ItemClick
			Try
				UnitOfWork.CommitChanges()
				CustomerID = DirectCast(CustomerBindingSource.DataSource, Customer).Oid
				Close()
			Catch e1 As LockingException
				XtraMessageBox.Show(Me, "The record was modified or deleted. Click Reload and try again.", "XPO Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			End Try
		End Sub

		Private Sub btnReload_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnReload.ItemClick
			Reload()
		End Sub

		Private Sub btnClose_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClose.ItemClick
			Close()
		End Sub
	End Class