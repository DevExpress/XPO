Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB.Exceptions
Imports XpoTutorial

Namespace WinFormsApplication.ViewModels
	Public Class EditOrderViewModel
		Implements ISupportParameter, IDocumentContent

		Private unitOfWork As UnitOfWork
		Private orderId? As Integer
		Private Property ISupportParameter_Parameter() As Object Implements ISupportParameter.Parameter
			Get
				Return orderId
			End Get
			Set(ByVal value As Object)
				If Equals(value, orderId) OrElse orderId.HasValue AndAlso Equals(value, orderId.Value) Then
					Return
				End If
				unitOfWork = If(unitOfWork, New UnitOfWork())
				orderId = DirectCast(value, Integer)
				Dim tmpOrder = unitOfWork.GetObjectByKey(Of Order)(orderId)
				Order = If(tmpOrder, New Order(unitOfWork))
				If Customers Is Nothing Then
					LoadCustomersAsync()
				End If
			End Set
		End Property
		Private Async Sub LoadCustomersAsync()
			Customers = Await unitOfWork.Query(Of Customer)().OrderBy(Function(c) c.ContactName).ToListAsync()
		End Sub
		Public Overridable Property Order() As Order
		Private privateCustomers As List(Of Customer)
		Public Overridable Property Customers() As List(Of Customer)
			Get
				Return privateCustomers
			End Get
			Protected Set(ByVal value As List(Of Customer))
				privateCustomers = value
			End Set
		End Property
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
		Protected Overridable Sub OnOrderChanged(ByVal oldValue As Order)
			If oldValue IsNot Nothing Then
				RemoveHandler oldValue.Changed, AddressOf OnOrderObjectChange
			End If
			Me.RaiseCanExecuteChanged(Sub(x) x.Save())
			If Order IsNot Nothing Then
				AddHandler Order.Changed, AddressOf OnOrderObjectChange
			End If
		End Sub
		Private Sub OnOrderObjectChange(ByVal sender As Object, ByVal e As ObjectChangeEventArgs)
			Me.RaiseCanExecuteChanged(Sub(x) x.Save())
		End Sub
		Public Function CanSave() As Boolean
			If unitOfWork Is Nothing OrElse Not orderId.HasValue Then
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
			Dim parent = Me.GetParentViewModel(Of OrderListViewModel)()
			If parent IsNot Nothing Then
				parent.Reload(Order.Oid)
			End If
			DirectCast(Me, IDocumentContent).DocumentOwner.Close(Me)
		End Sub
		Public Async Sub Reload()
			Dim isNewObject As Boolean = unitOfWork.IsNewObject(Order)
			unitOfWork = New UnitOfWork()
			Order = If(isNewObject, New Order(unitOfWork), Await unitOfWork.GetObjectByKeyAsync(Of Order)(Order.Oid))
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
			If Order IsNot Nothing Then
				RemoveHandler Order.Changed, AddressOf OnOrderObjectChange
			End If
			unitOfWork.Dispose()
			unitOfWork = Nothing
			orderId = Nothing
		End Sub
	End Class
End Namespace
