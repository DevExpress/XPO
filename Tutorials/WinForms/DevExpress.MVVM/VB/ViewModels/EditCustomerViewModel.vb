Imports System.ComponentModel
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB.Exceptions
Imports XpoTutorial

Namespace WinFormsApplication.ViewModels
	Public Class EditCustomerViewModel
		Implements ISupportParameter, IDocumentContent

		Private unitOfWork As UnitOfWork
		Private customerId? As Integer
		Private Property ISupportParameter_Parameter() As Object Implements ISupportParameter.Parameter
			Get
				Return customerId
			End Get
			Set(ByVal value As Object)
				If Equals(value, customerId) OrElse customerId.HasValue AndAlso Equals(value, customerId.Value) Then
					Return
				End If
				unitOfWork = If(unitOfWork, New UnitOfWork())
				customerId = DirectCast(value, Integer)
				Dim customer_tmp = unitOfWork.GetObjectByKey(Of Customer)(customerId)
				Customer = If(customer_tmp, New Customer(unitOfWork))
			End Set
		End Property
		Public Overridable Property Customer() As Customer
		Protected Overridable Sub OnCustomerChanged(ByVal oldValue As Customer)
			If oldValue IsNot Nothing Then
				RemoveHandler oldValue.Changed, AddressOf OnCustomerObjectChange
			End If
			Me.RaiseCanExecuteChanged(Sub(x) x.Save())
			If Customer IsNot Nothing Then
				AddHandler Customer.Changed, AddressOf OnCustomerObjectChange
			End If
		End Sub
		Private Sub OnCustomerObjectChange(ByVal sender As Object, ByVal e As ObjectChangeEventArgs)
			Me.RaiseCanExecuteChanged(Sub(x) x.Save())
		End Sub
		Protected ReadOnly Property MessageBoxService() As IMessageBoxService
			Get
				Return Me.GetService(Of IMessageBoxService)()
			End Get
		End Property
		Protected ReadOnly Property DocumentManagerService() As IDocumentManagerService
			Get
				Return Me.GetService(Of IDocumentManagerService)()
			End Get
		End Property
		Public Function CanSave() As Boolean
			If unitOfWork Is Nothing OrElse Not customerId.HasValue Then
				Return False
			End If
			Dim objectsToSave = unitOfWork.GetObjectsToSave(False)
			Return (objectsToSave IsNot Nothing) AndAlso objectsToSave.Count > 0
		End Function
		Public Async Sub Save()
			Try
				Await unitOfWork.CommitChangesAsync()
			Catch e1 As LockingException
				MessageBoxService.ShowMessage("The object was modified by another user. Please reload data.", "XPO Tutorial", MessageButton.OK, MessageIcon.Stop)
				Return
			End Try
			Dim parent = Me.GetParentViewModel(Of CustomerListViewModel)()
			If parent IsNot Nothing Then
				parent.Reload(Customer.Oid)
			End If
			DirectCast(Me, IDocumentContent).DocumentOwner.Close(Me)
		End Sub
		Public Async Sub Reload()
			Dim isNewObject As Boolean = unitOfWork.IsNewObject(Customer)
			unitOfWork = New UnitOfWork()
			Customer = If(isNewObject, New Customer(unitOfWork), Await unitOfWork.GetObjectByKeyAsync(Of Customer)(Customer.Oid))
		End Sub
		Private Property IDocumentContent_DocumentOwner() As IDocumentOwner Implements IDocumentContent.DocumentOwner
		Private ReadOnly Property IDocumentContent_Title() As Object Implements IDocumentContent.Title
			Get
				Return String.Empty
			End Get
		End Property
		Private Sub IDocumentContent_OnClose(ByVal e As CancelEventArgs) Implements IDocumentContent.OnClose
			' do some validation here
		End Sub
		Private Sub IDocumentContent_OnDestroy() Implements IDocumentContent.OnDestroy
			' some cleanup
			If Customer IsNot Nothing Then
				RemoveHandler Customer.Changed, AddressOf OnCustomerObjectChange
			End If
			unitOfWork.Dispose()
			unitOfWork = Nothing
			customerId = Nothing
		End Sub
	End Class
End Namespace
