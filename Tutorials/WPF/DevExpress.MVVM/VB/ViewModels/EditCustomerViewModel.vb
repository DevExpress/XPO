Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB.Exceptions
Imports XpoTutorial
Imports System.Linq

Namespace WpfApplicationMvvm.ViewModels
	Public Class EditCustomerViewModel
		Inherits ViewModelBase

		Public Sub New()
			If Not IsInDesignMode Then
				UnitOfWork = New UnitOfWork()
			End If
		End Sub
		Public Property CurrentItem() As Customer
			Get
				Return GetProperty(Function() CurrentItem)
			End Get
			Set(ByVal value As Customer)
				SetProperty(Function() CurrentItem, value)
			End Set
		End Property
		Public Property CurrentOrder() As Order
			Get
				Return GetProperty(Function() CurrentOrder)
			End Get
			Set(ByVal value As Order)
				SetProperty(Function() CurrentOrder, value)
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
		Protected ReadOnly Property MessageBoxService() As IMessageBoxService
			Get
				Return GetService(Of IMessageBoxService)()
			End Get
		End Property
		Protected ReadOnly Property DocumentManagerService() As IDocumentManagerService
			Get
				Return GetService(Of IDocumentManagerService)()
			End Get
		End Property
		Protected Overrides Sub OnParameterChanged(ByVal parameter As Object)
			If UnitOfWork Is Nothing Then
				Return
			End If
			CurrentItem = UnitOfWork.GetObjectByKey(Of Customer)(parameter)
			If CurrentItem Is Nothing Then
				CurrentItem = New Customer(UnitOfWork)
			End If
		End Sub
		Protected Sub CreateDocument(ByVal arg As Object)
			Dim doc As IDocument = DocumentManagerService.FindDocument(arg, Me)
			If doc Is Nothing Then
				doc = DocumentManagerService.CreateDocument("EditOrderView", arg, Me)
				doc.Id = String.Format("DocId_{0}", DocumentManagerService.Documents.Count())
				Dim order As Order = TryCast(arg, Order)
				If order Is Nothing Then
					doc.Title = "Edit New Order"
				Else
					doc.Title = String.Format("Edit Order {0}", order.ProductName)
				End If
			End If
			doc.Show()
		End Sub
		<Command>
		Public Async Sub Save()
			Try
				Await UnitOfWork.CommitChangesAsync()
			Catch e1 As LockingException
				MessageBoxService.ShowMessage("The object was modified by another user. Please reload data.", "XPO Tutorial", MessageButton.OK, MessageIcon.Stop)
				Return
			End Try
			Dim spv As ISupportParentViewModel = DirectCast(Me, ISupportParentViewModel)
			Dim vm As CustomerListViewModel = DirectCast(spv.ParentViewModel, CustomerListViewModel)
			vm.Reload()
			DocumentManagerService.ActiveDocument.Close()
		End Sub
		<Command>
		Public Sub Cancel()
			DocumentManagerService.ActiveDocument.Close()
		End Sub
		<Command>
		Public Async Sub Reload()
			Dim isNewObject As Boolean = UnitOfWork.IsNewObject(CurrentItem)
			UnitOfWork = New UnitOfWork()
			CurrentItem = If(isNewObject, New Customer(UnitOfWork), Await UnitOfWork.GetObjectByKeyAsync(Of Customer)(CurrentItem.Oid))
		End Sub
		<Command>
		Public Sub EditOrder()
			CreateDocument(CurrentOrder)
		End Sub
		<Command>
		Public Sub AddOrder()
			CreateDocument(CurrentItem)
		End Sub
		<Command>
		Public Sub DeleteOrder()
			UnitOfWork.Delete(CurrentOrder)
		End Sub
	End Class
End Namespace
